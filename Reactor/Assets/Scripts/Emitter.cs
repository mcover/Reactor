using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleDrawer))]

public class Emitter : MonoBehaviour, IHitMe {
   
    public AudioSource audioSource;
    public bool movable;
    public float time;

    public int goalHits = 3;
    private List<GameObject> hits = new List<GameObject>();
   
	// Update is called once per frame
	public virtual void Update () {
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

    public virtual void HitMe(GameObject hitter)
    {
        //play sound
        PlaySound();
        if (!hits.Contains(hitter))
        {
            hits.Add(hitter);
            if (hits.Count >= goalHits)
            {
                Debug.LogFormat("Objects {0} hit by {1} objects", name, hits.Count);
                //Destroy(gameObject);
            }
        }
        EmitWave();
    }

    void PlaySound()
    {
        //play sound
        //activate circle script in a corroutine
        //Debug.LogFormat("hit {0}", this.name);
        audioSource.Play();
    }

    void EmitWave()
    {
        var wave = GetComponent<CircleDrawer>();
        wave.CreateWave();
    }

    void OnDestroy()
    {
        Debug.LogFormat("Destroying {0}",name);
    }
}
