using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {
   
    public bool activated = false;
    public AudioSource audioSource;
    public bool movable;
    public bool source;
    public float frequency;
    public float time;
   
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        float newTime = Time.time;
        //print(source & activated & ((newTime - time) >= frequency));
		if (source & activated) {//need to check time vs frequency as well
            //shoot wave (could be wave of distance 0)
           // print("making wave");
            //need offset
           // if (width == 30)
            //{
              //  GameObject wave = Instantiate(Wave30, transform.position, direction) as GameObject;
               // wave.GetComponent<Wave>().SetProperties(distance, 5, direction, waveSpeed);
            //}
            //else if (width == 360)
            //{
             //   GameObject wave = Instantiate(Wave360, transform.position, direction) as GameObject;
              //  wave.GetComponent<Wave>().SetProperties(distance, 5, direction, waveSpeed);
           // }
            //set up wave properties here
            //play sound
          //  time = Time.time;
        }
	}

    void OnMouseDown()
    {
        if (source)
        {
            activated = !activated;
        }
    }
    public void TriggerEmitter()
    {
        //play sound
        //activate circle script in a corroutine
    }
}
