using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoteSpawner : MonoBehaviour {

    public float minRadiusMultiplier;
    public float maxRadiusMultiplier;

    public float onScreenMultiplier;

    public float initDist;

    public GameObject motePrefab;

    Vector3 lastSpawnLocation;



    public float forceMin;
    public float forceMax;

    public float spawnDistMultiplier;
    float newSpawnDist;

    public PlayerMote player;

    [Header("SpawnRanges")]
    [Header("SmallRange")]
    public float smallMin1;
    public float smallMin2;
    public float smallMax1;
    public float smallMax2;
    public int smallAmountMin;
    public int smallAmountMax;
    [Header("MidRange")]
    public float midMin1;
    public float midMin2;
    public float midMax1;
    public float midMax2;
    public int midAmountMin;
    public int midAmountMax;
    [Header("BigRange")]
    public float bigMin1;
    public float bigMin2;
    public float bigMax1;
    public float bigMax2;
    public int bigAmountMin;
    public int bigAmountMax;

    List<Mote> currentMotes = new List<Mote>();

    public static MoteSpawner instance;

    bool spawning;

    void Awake() {
        var others = FindObjectsOfType<MoteSpawner>();
        if(others.Length > 1) {
            Destroy(gameObject);
        }else {
            instance = this;
        }
    }

	// Use this for initialization
	void Start () {

        newSpawnDist = initDist;
        lastSpawnLocation = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null) {
            float dist = (lastSpawnLocation - player.transform.position).magnitude;
            //Debug.Log(dist);
            //update spawn dist
            if (newSpawnDist != initDist) {
                newSpawnDist = transform.position.y * spawnDistMultiplier;
            }
            if (dist > newSpawnDist && !spawning) {
                StartCoroutine(DoSpawn());
            }
        }
	}

    public IEnumerator DoSpawn(){

        spawning = true;

        int[] amounts = new int[]{
            Random.Range(bigAmountMin, bigAmountMax),
            Random.Range(midAmountMin, midAmountMax),
            Random.Range(smallAmountMin, smallAmountMax),
        };

        int total = amounts[0] + amounts[1] + amounts[2];

        List<float> sizes = new List<float>();


        //destroy any motes currently not on screen
        for(int i = currentMotes.Count - 1; i >= 0; i--){
            Mote m = currentMotes[i];
            Vector3 center = transform.position.withY(0f);
            float dist = (center - m.transform.position).magnitude - (m.cSize/2f);
            if(dist > CameraFollow.height * onScreenMultiplier) {
                RemoveMote(m);
            }
        }

        for(int i = 0; i < 3; i++) {
            for(int i2 = i; i2 < amounts[i]; i2++) {
                float size1 = 0f;
                float size2 = 0f;

                switch (i) {
                    case 0:
                        size1 = Random.Range(bigMin1, bigMax1);
                        size2 = Random.Range(bigMin2, bigMax2);

                        break;
                    case 1:
                        size1 = Random.Range(midMin1, midMax1);
                        size2 = Random.Range(midMin2, midMax2);
                        break;
                    case 2:
                        size1 = Random.Range(smallMin1, smallMax1);
                        size2 = Random.Range(smallMin2, smallMax2);
                        break;
                }
                sizes.Add(Mathf.Lerp(size1, size2, player.mote.GetSizeFrac()));
            }
        }

        int overLimit = (sizes.Count + currentMotes.Count) - 100;
        if(overLimit > 1) {
            for(int i2 = 0; i2 < overLimit; i2++) {
                sizes.RemoveAt(Random.Range(0, sizes.Count));
            }
        }

        for (int i = 0; i < sizes.Count; i++){
            Vector3 pos = Vector3.zero;

            int tries = 0;

            while(tries < 100) {
                float min = minRadiusMultiplier * transform.position.y;
                float max = maxRadiusMultiplier * transform.position.y;

                float r = Random.Range(min, max); 

                float playerAngle = Mathf.Atan2(-player.mote.softBody.linearVelocity.x, player.mote.softBody.linearVelocity.z) + (Mathf.PI/2f);
                float ang = Random.Range(playerAngle - (80f * Mathf.Deg2Rad), playerAngle + (80f * Mathf.Deg2Rad));

                pos = new Vector3(Mathf.Cos(ang), 0f, Mathf.Sin(ang)) * (r + (sizes[i]));
                pos += transform.position.withY(0f);

                if(Physics.OverlapSphere(pos, sizes[i]).Length == 0) {
                    break;
                }else {
                    tries++;
                }
            }
            if (tries >= 100) {
                continue;
            }

            GameObject go = (GameObject)(Instantiate(motePrefab, pos, Quaternion.identity));
            Mote m = go.GetComponent<Mote>();

            m.cSize = sizes[i];

            if(i < amounts[0]) { //this is a big mote, make sure its dormant and not going to steamroll the field
                AIMote ai = m.GetComponent<AIMote>();
                if (ai != null) ai.dormant = true;
            }
            AddMote(m);
            yield return null;
        }
        Vector3 avg = Vector3.zero;
        for (int i = 0; i < currentMotes.Count; i++) avg += currentMotes[i].transform.position;

        spawning = false;
        newSpawnDist = 0f;
        lastSpawnLocation = avg / currentMotes.Count;
    }

    public void AddMote(Mote m) {
        if (!currentMotes.Contains(m)) {
            currentMotes.Add(m);
        }

        if (currentMotes.Count >= 100) {

            Mote remove = null;
            //first check distance and if on screen
            float best = 0f;
            for (int i = 0; i < currentMotes.Count; i++) {
                if(currentMotes[i].playerDist > best) {
                    Vector3 center = transform.position.withY(0f);
                    float dist = (center - currentMotes[i].transform.position).magnitude - (currentMotes[i].cSize / 2f);
                    if (dist > CameraFollow.height * onScreenMultiplier) {
                        best = currentMotes[i].playerDist;
                        remove = currentMotes[i];
                    }
                }
            }

            //then just remove the smallest one, farthest away from player
            if(remove == null) {
                best = Mathf.Infinity;
                for (int i = 0; i < currentMotes.Count; i++) {
                    if(currentMotes[i].cSize < best) {
                        best = currentMotes[i].cSize;
                        remove = currentMotes[i];
                    }
                }
            }

            if(remove != null) {
                RemoveMote(remove);
            }
        }
    }

    public void RemoveMote(Mote m) {
        if (currentMotes.Contains(m)) {
            currentMotes.Remove(m);
            Destroy(m.gameObject);
        }
    }
}
