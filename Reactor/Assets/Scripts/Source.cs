using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : Emitter
{
    public bool     activated = false;
    public float frequency = 1;

    void Start()
    {
        StartCoroutine(pulse());
    }

    IEnumerator pulse()
    {
        while (true) {

            if (activated)
            {
                PlaySound();
                var wave = GetComponent<CircleDrawer>();
                wave.CreateWave();
            }
            if (frequency == 0)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(frequency);
            }
        }
    }

    public override void HitMe()
    {
        //play sound
        //PlaySound();
    }

    void PlaySound()
    {
        //play sound
        //activate circle script in a corroutine
        audioSource.Play();
    }

    void OnMouseDown()
    {
        Debug.Log("clicked");
        activated = !activated;
    }

}