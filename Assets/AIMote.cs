using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIMote : MonoBehaviour {

    SphereCollider trigger;
    Mote mote;

    float predatorWeight = 8f;
    float predactorDirectionWeight = 4f;
    float preyWeight = 2f;
    float preyDirectionWeight = 4f;

    float newDirectionTimeMin = 0.5f;
    float newDirectionTimeMax = 5f;
    float newDirectionTime;
    float newDirectionTimer;
    Vector3 lastDirection;

    float moveTimeMin = 1f;
    float moveTimeMax = 8f;
    float moveTime;
    float moveTimer;

    float simulateDistMultiplier = 0.4f;
    float simulateDist;

    float sizeThresholdDivisor = 8f; //the smallest thing we'll go for is our size divided by this

    [HideInInspector]
    public bool dormant;

    void Awake() {
        trigger = GetComponent<SphereCollider>();
        mote = GetComponent<Mote>();
    }

    void Start () {
        moveTime = Random.Range(moveTimeMin, moveTimeMax);
        newDirectionTime = Random.Range(newDirectionTimeMin, newDirectionTimeMax);
        lastDirection = GetNewDirection();
	}
	
	// Update is called once per frame
	void Update () {

        simulateDist = CameraFollow.height * simulateDistMultiplier;
        if (!dormant) {

            Vector3 center = Camera.main.transform.position.withY(0f);
            float dist = (center - transform.position).magnitude - (mote.cSize / 2f);

            if (dist <= simulateDist) {

                moveTimer += Time.deltaTime / moveTime;
                if (moveTimer >= 1f) {
                    mote.MoveMote(lastDirection, 0f);
                    moveTime = Random.Range(moveTimeMin, moveTimeMax);
                    moveTimer = 0f;
                }

                newDirectionTimer += Time.deltaTime / newDirectionTime;
                if (newDirectionTimer >= 1f) {
                    lastDirection = GetNewDirection();
                    newDirectionTime = Random.Range(newDirectionTimeMin, newDirectionTimeMax);
                    newDirectionTimer = 0f;
                }
            }
        }
    }

    void UpdateTriggerRadius() {
        trigger.radius = mote.cSize;
    }

    List<Mote> GetLocalMotes(float radius) {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius);
        List<Mote> motes = new List<Mote>();
        for(int i = 0; i < hit.Length; i++) {
            Mote m = hit[i].GetComponent<Mote>();
            if(m != null) {
                motes.Add(m);
            }
        }
        return motes;
    }

    Vector3 GetNewDirection() {
        float radius = mote.cSize * 10f;
        List<Mote> motes = GetLocalMotes(radius);
        Vector3 moveDir = Vector3.zero;
        if (motes.Count > 1) {
            for (int i = 0; i < motes.Count; i++) {
                Mote m = motes[i];
                float weight = 0f;
                Vector3 heading = (m.transform.position - transform.position).normalized; //heading points to other mote
                if (m.cSize > mote.cSize / sizeThresholdDivisor) {
                    if (m.cSize > mote.cSize) { //can eat me
                        weight = Mathf.Lerp(0f, predatorWeight, 1f - (heading.sqrMagnitude / (radius * radius)));
                        moveDir += (-heading * weight);
                    }
                    if (m.cSize < mote.cSize) { //i can eat it
                        weight = Mathf.Lerp(0f, preyWeight, 1f - (heading.sqrMagnitude / (radius * radius)));
                        moveDir += (heading * weight);
                    }
                }
            }
            return moveDir.normalized;
        }else {
            //if there's nothing around us just pick a random direction
            return new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        }
    }
}
