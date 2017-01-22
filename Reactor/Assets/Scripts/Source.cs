using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : Emitter
{
    public bool     activated = false;
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
        Debug.LogFormat("Screen Dimensions: {0},{1}", Screen.width, Screen.height);
    }

    void updateLight() {
        lightGameObject.transform.localPosition = new Vector3(0.0f,0.0f,-1f);
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

    public override void Update() {
        base.Update();
        
        lightComp.enabled = activated;
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

    //void OnMouseOver()
    //{
    //    Debug.LogFormat("Mouse Over: {0}", name);
    //    Debug.LogFormat("Mouse Button 1: {0}", Input.GetMouseButtonDown(0));
    //    Debug.LogFormat("Mouse Button 2: {0}", Input.GetMouseButtonDown(1));
    //    Debug.LogFormat("Mouse Button 3: {0}", Input.GetMouseButtonDown(2));
    //}
}