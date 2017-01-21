using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {
    public int frequency;
    public float time;
    public int width;
    public bool activated = false;
    public float direction;
    public AudioSource audioSource;
    public bool movable;
    public float waveSpeed;

	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
            //check time
            //if frequency time has passed shoot wave of width in direction
        }
	}

    void sendWave(){
        //create wave object from prefab of width
        //add movement script with speed and direction
    }
}
