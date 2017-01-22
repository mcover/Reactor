using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleDrawer))]

public class Emitter : MonoBehaviour, IHitMe {
   
    public AudioSource audioSource;
    public bool movable;
    public float time;
   
	// Update is called once per frame
	void Update () {
        float newTime = Time.time;
        //print(source & activated & ((newTime - time) >= frequency));
		//if (source) {//need to check time vs frequency as well
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
       // }
	}

    public void HitMe()
    {
        //play sound
        PlaySound();
        EmitWave();
    }

    void PlaySound()
    {
        //play sound
        //activate circle script in a corroutine
        Debug.LogFormat("hit {0}", this.name);
    }


    void EmitWave()
    {
        var wave = GetComponent<CircleDrawer>();
        wave.CreateWave();
    }
}
