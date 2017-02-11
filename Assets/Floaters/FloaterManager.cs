using UnityEngine;
using System.Collections;

public class FloaterManager : MonoBehaviour {


    public float radiusMin, radiusMax;
    public GameObject[] floaterPrefabs;
    public float minTime, maxTime;
    float timer, cTime;
	// Use this for initialization
	void Start () {
        cTime = Random.Range(minTime, maxTime);
	}

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime/cTime;
        if(timer >= 1f) {
            cTime = Random.Range(minTime, maxTime);
            timer = 0f;
            SpawnFloater();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            SpawnFloater();
        }
	}
    void SpawnFloater() {
        float r = Random.Range(radiusMin, radiusMax);
        float ang = Random.Range(0f, Mathf.PI);
        Vector3 pos = new Vector3(Mathf.Cos(ang) * r, transform.position.y - Random.Range(10f, 20f), Mathf.Sin(ang) *r);

        GameObject prefab = floaterPrefabs[0];
        Instantiate(prefab, pos, Quaternion.Euler(90f, 0f, Random.Range(0f, 360f)), transform.parent);  
    }
}
