using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {


    public static AudioPlayer instance;


    void Awake() {
        var others = FindObjectsOfType<AudioPlayer>();
        if (others.Length > 1) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
