using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mote : MonoBehaviour {


    MeshRenderer mr;
    SphereCollider trigger;

    public Texture2D[] noiseTextures;

    public float minSize, maxSize;
    public float startSize;
    public float cSize;
    [HideInInspector]
    public TxSoftBody softBody;

    float siphonRateMin = 1f;
    float siphonRateMax = 10f;
    float siphonForceMultiplier = 50f;

    float lastSize;

    public bool death;
    float killDistMin = 200f;
    float killDistMax = 400f;

    public float velocityBrake = 100f;
    float forceToMiddleVelocity = 100f;
    float startPressure;
    float startPlastic;

    //forces
    float maxVelocity;
    public float maxVelocityMin;
    public float maxVelocityMax;


    public float forceMultiplier1;
    public float forceMultiplier2;

    //mote shooting
    float shootSizeMultiplier = 0.05f;


    float shootForceMultiplier = 5f;
    float shootDirectionMultiplier = 10f;

    [HideInInspector]
    public Mote originMote = null;

    public GameObject motePrefab; //for shooting

    [HideInInspector]
    public float playerDist;

    void Awake() {
        softBody = GetComponent<TxSoftBody>();
        cSize = startSize;
        softBody.onCollision += SoftBody_onCollision;
    }

    void OnDestroy() {
        softBody.onCollision -= SoftBody_onCollision;
    }


    void Start() {
        startPressure = softBody.m_internalPressure;
        ScaleMote(cSize);
        mr = GetComponent<MeshRenderer>();
        trigger = GetComponent<SphereCollider>();
        mr.material.SetFloat("_Freq", Random.Range(0.01f, 0.05f));

        Texture2D tex = noiseTextures[Random.Range(0, noiseTextures.Length)];
        mr.material.SetTexture("_NoiseTex", tex);
    }

    void CheckDist() {
        if (PlayerMote.instance != null) {
            playerDist = (PlayerMote.instance.transform.position - transform.position).sqrMagnitude;
            playerDist -= Mathf.Pow(cSize, 2f);
            float killDist = CameraFollow.height * 100f + cSize;
            if (playerDist > killDist * killDist) {
                Death();
            }
        }
    }

    void Update() {
        if (lastSize != cSize) {
            ScaleMote(cSize);
        }
        lastSize = cSize;
        cSize = Mathf.Clamp(cSize, minSize, maxSize);

        CheckDist();
        LimitY();
        LimitVelocity();
        UpdateTriggerRadius();

    }

    private void SoftBody_onCollision(TxBody.Contact contact) {
        //which body is other
        TxBody body = null;
        if (contact.bodyA != softBody) {
            body = contact.bodyA;
        } else if (contact.bodyB != softBody) {
            body = contact.bodyB;
        }
        Mote m = body.GetComponent<Mote>();
        if (m != null) {
            if (!m.death && m.cSize < cSize && m.originMote != this) {
                Siphon(m);
            }
        }
    }

    void ScaleMote(float scale) {
        for (int i = 0; i < softBody.linkCount; i++)
            softBody.linkPlastic[i] = softBody.truss.linkLength[i] * scale;
        softBody.m_internalPressure = startPressure * (Mathf.Pow(scale, 3f));
        softBody.massScale = Mathf.Max(1f, cSize);
    }

    public float GetSizeFrac() {
        return Mathf.InverseLerp(minSize, maxSize, cSize);
    }

    public void Siphon(Mote otherMote) {
        float sizeDiff = cSize - otherMote.cSize;
        float maxDiff = maxSize - minSize;
        float rate = Mathf.Lerp(siphonRateMin, siphonRateMax, sizeDiff / maxDiff) * Time.deltaTime;
        otherMote.cSize -= rate;
        cSize += rate / 2f;

        Vector3 attractDir = -(otherMote.transform.position - transform.position).normalized;
        float siphonForce = (cSize - otherMote.cSize) * siphonForceMultiplier;
        otherMote.softBody.ApplyImpulse(siphonForce * attractDir * Time.deltaTime);
        if (otherMote.cSize < minSize) {
            if (!otherMote.death) {
                otherMote.Death();
                otherMote.death = true;
            }
        }
    }
    public void Death() {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut() {
        float opacity = mr.material.GetFloat("_FresnelOpacity");
        float t = 0f;
        while (t < 1f) {
            t += Time.deltaTime;
            cSize = Mathf.Lerp(1f, 0.01f, t);
            mr.material.SetFloat("_FresnelOpacity", Mathf.Lerp(opacity, 0f, t));
            yield return null;
        }
        MoteSpawner.instance.RemoveMote(this);
        Destroy(gameObject);
    }

    void LimitY() {
        Vector3 dir = -Mathf.Sign(transform.position.y) * Vector3.up;
        float damp = Mathf.Abs(transform.position.y) * 0.2f;
        if (transform.position.y != 0f) {

            float force = Mathf.Abs(transform.position.y) / 1f * forceToMiddleVelocity;
            softBody.ApplyImpulse(dir * force * Time.deltaTime);
        }
    }

    void LimitVelocity() {
        maxVelocity = Mathf.Lerp(maxVelocityMin, maxVelocityMax, GetSizeFrac());
        if(softBody.linearVelocity.magnitude > maxVelocity) {
            softBody.ApplyImpulse(-softBody.linearVelocity * velocityBrake);
        }
    }

    void UpdateTriggerRadius() {
        trigger.radius = cSize;
    }

    public void MoveMote(Vector3 dir, float lerp) {
        
        //calculate force
        lerp = Mathf.Clamp01(lerp);
        float multiplier = Mathf.Lerp(forceMultiplier1, forceMultiplier2, lerp);
        float force = cSize * multiplier;


        //apply force
        softBody.ApplyImpulse(dir * force);

        //create shoot mote
        float size = cSize * shootSizeMultiplier;
        Vector3 pos = (transform.position + -dir * ((cSize / 2f))).withY(-0.5f);
        GameObject go = (GameObject)Instantiate(motePrefab, pos, Random.rotation);
        Mote m = go.GetComponent<Mote>();
        m.cSize = size;
        m.softBody.ApplyImpulse(softBody.linearVelocity * 150f);
        m.softBody.ApplyImpulse((-dir * force * shootForceMultiplier));
        m.originMote = this;

        MoteSpawner.instance.AddMote(m);


        cSize -= size;

    }
}