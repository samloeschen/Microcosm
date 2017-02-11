using UnityEngine;
using System.Collections;

 
 public class CameraFollow : MonoBehaviour {

    public Mote playerMote;

    public float maxSpeed1; //normal follow speed
    public float maxSpeed2; //follow speed when near border
    public float speedChangeSpeed;

    float speed;
    

    public float speedDist;

    public float smoothing;

    public float heightMultiplier;
    public float heightSpeed;
    public static float height;

    Vector3 cPos;
    Vector3 lastPos;

    Vector3 primeTarget;
    void Start() {
        height = playerMote.startSize * heightMultiplier;
        transform.position = transform.position.withY(height);
        primeTarget = new Vector3(playerMote.transform.position.x, 0f, playerMote.transform.position.z);

    }

    // Update is called once per frame
    void Update() {
        if (playerMote != null) {
            float targetHeight = playerMote.cSize * heightMultiplier;
            height = Mathf.MoveTowards(height, targetHeight, heightSpeed * Time.deltaTime);

            Vector2 center = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Vector2 playerPos = Camera.main.WorldToScreenPoint(playerMote.transform.position);

            float targetSpeed = 0f;
            if((playerPos - center).magnitude > Screen.width / 8f) {
                targetSpeed = maxSpeed2;
            }else {
                targetSpeed = maxSpeed1;
            }
            speed = Mathf.MoveTowards(speed, targetSpeed, speedChangeSpeed * Time.deltaTime);
            Vector3 pos = new Vector3(playerMote.transform.position.x, 0f, playerMote.transform.position.z);
            primeTarget = Vector3.MoveTowards(primeTarget, pos, speed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, primeTarget, 1f - Mathf.Pow(smoothing, Time.deltaTime));
            transform.position = transform.position.withY(height);

        }
    }
}
