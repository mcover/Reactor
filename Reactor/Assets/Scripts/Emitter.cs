using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {
    public float frequency;
    private float time;
    public int width;
    public bool activated = false;
    public float direction;
    public AudioSource audioSource;
    public bool movable;
    public float waveSpeed;
    public bool source;

	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float newTime = Time.time;
		if (activated &((time-newTime) >=frequency)) {
            //shoot wave (could be wave of distance 0)
            //play sound
            time = Time.time;
        }
	}

    void sendWave(){
        //create wave object from prefab of width
        //add movement script with speed and direction
    }

    void OnMouseDown()
    {
        if (source)
        {
            activated = !activated;
            print(activated);
        }
    }
    
}
