using UnityEngine;
using System.Collections;

public class Floater : MonoBehaviour {

    public Vector3 dir;
    public float speedMin, speedMax;
    public float maxDist;
    float speed;
    int rotDir;
    public float rotSpeedMin, rotSpeedMax;
    float rotSpeed;

	// Use this for initialization
	void Start () {
        //dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        dir = new Vector3(-transform.localPosition.x, -transform.localPosition.y, 0f);
        rotDir = Random.value < 0.5f ? 1 : -1;
        rotSpeed = Random.Range(rotSpeedMin, rotSpeedMax);
        speed = Random.Range(speedMin, speedMax);
	}

    // Update is called once per frame
    void Update() {
        transform.localPosition += dir * speed * Time.deltaTime;
        transform.eulerAngles = transform.eulerAngles.withZ(transform.eulerAngles.z + (rotDir * rotSpeed * Time.deltaTime));
        float dist = transform.localPosition.magnitude;
        if(dist > maxDist) {
            Destroy(gameObject);
        }
    }
}
