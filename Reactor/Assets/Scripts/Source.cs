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

    void OnMouseDown()
    {
        Debug.Log("clicked");
        activated = !activated;
    }

}