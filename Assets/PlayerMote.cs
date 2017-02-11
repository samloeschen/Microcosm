using UnityEngine;
using System.Collections;

public class PlayerMote : MonoBehaviour {

    [Header("MoteShooting")]
    public float shootSizeMin;
    public float shootSizeMax;
    public float shootForceMin;
    public float shootForceMax;



    [Header("Control")]
    public float timeToMaxForce;
    float holdTimer = 0f;

    public float spawnDist;

    //components

    public Mote mote;
    // Use this for initialization

    public static PlayerMote instance;

    void Awake() {

        var others = FindObjectsOfType<PlayerMote>();
        if(others.Length > 1) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
        mote = GetComponent<Mote>();
    }
	void Update () {
        if (Input.GetMouseButton(0)) {
            holdTimer += Time.deltaTime / timeToMaxForce;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            PlayerMove();
            holdTimer = 0f;
        }
    }

    void OnDestroy() {
        if (mote.death) {
            ScreenFader fader = Camera.main.GetComponent<ScreenFader>();
            fader.EndScene(0);
        }
    }

    void PlayerMove() {
        float dist = Camera.main.transform.position.y - transform.position.y;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist));
        Vector3 dir = -(mousePos - transform.position).normalized;
        mote.MoveMote(dir, holdTimer);
    }
}
