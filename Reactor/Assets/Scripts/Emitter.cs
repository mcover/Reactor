using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {
    public float frequency;
    private float time;
    public int width;
    public bool activated = false;
    public Quaternion direction;
    public AudioSource audioSource;
    public bool movable;
    public float waveSpeed;
    public bool source;
    public float distance = 100;
    public GameObject Wave30;
    public GameObject Wave360;

	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float newTime = Time.time;
        //print(source & activated & ((newTime - time) >= frequency));
		if (source & activated & ((newTime - time) >=frequency)) {
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!source)
        {
            //need an offset
            //send a wave
           // if (width == 30)
            //{
             //   GameObject newWave = Instantiate(Wave30, transform.position, direction) as GameObject;
              //  newWave.GetComponent<Wave>().SetProperties(distance, 5, direction, waveSpeed);
           // }
           // else if (width == 360)
            //{
             //   GameObject newWave = Instantiate(Wave360, transform.position, direction) as GameObject;
              //  newWave.GetComponent<Wave>().SetProperties(distance,5,direction,waveSpeed);
           // }
        }
        //play sound
    }

}
