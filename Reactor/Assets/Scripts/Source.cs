using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : Emitter
{
    public bool activated = false;
    public float frequency = 1;

    Light lightComp;
    GameObject lightGameObject;

    void Start()
    {
        lightGameObject = new GameObject("Source Light");
        lightGameObject.transform.parent = transform;
        updateLight();
        lightComp = lightGameObject.AddComponent<Light>();
        lightComp.enabled = true;
        lightComp.intensity = 8;
        StartCoroutine(pulse());
        //Debug.LogFormat("Screen Dimensions: {0},{1}", Screen.width, Screen.height);
    }

    void updateLight()
    {
        lightGameObject.transform.localPosition = new Vector3(0.0f, 0.0f, -1f);
    }

    IEnumerator pulse()
    {
        while (true)
        {

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

    public override void Update()
    {
        base.Update();

        lightComp.enabled = activated;
    }


    public override void HitMe(GameObject hitter)
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

    //Left click
    void OnMouseDown()
    {
        //Debug.Log("clicked");
        activated = !activated;
    }
}