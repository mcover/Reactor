using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
    public float distance = 10;
    public float scaleFactor= 0.2f;
    public Quaternion direction;
    public bool moving;
    public float waveSpeed;

    private Vector2 initialPosition;
    //private Vector2 position;
    private Vector3 scale = new Vector3(.5f,.5f,0);
    private Vector3 finalPosition;
    private float initialTime;
    private float timeToMove;
	// Use this for initialization
	void Start () {
       // position = transform.position;
        initialPosition = transform.position;
        scale = transform.localScale;
        timeToMove = waveSpeed * distance;
        //transform.Rotate(direction.eulerAngles);
        finalPosition = new Vector3(0,0, distance);
        initialTime = Time.time;
        transform.localScale = new Vector3(.5f, .5f,0);
    }

    public void SetProperties(float newDistance, float newScaleFactor, Quaternion newDirection, float speed)
    {
        distance = newDistance;
        scaleFactor = newScaleFactor;
        direction = newDirection;
        waveSpeed = speed;
        //calculate final position here?
        timeToMove = speed * distance;
        //transform.localRotation = direction;
        finalPosition = new Vector3(0,0, distance);//will this even work??
        Debug.Log("setting properties");
    }
    private void Update()
    {
        //check new position
        Vector3 newPosition = transform.position;
        float difference = Vector3.Distance(newPosition, initialPosition);
        if (difference < distance) //until we go as far as we're supposed to
        {
            //interpolate distance lerp
            //need final position
            //interpolate scale
            print("getting into code");
            Debug.LogFormat("finalPosition {0}  position {1} ", finalPosition, newPosition);
            //print("position " + position);
            transform.position = Vector3.MoveTowards(newPosition, finalPosition, 10);
            //transform.localScale = new Vector3(scale.x * scaleFactor, scale.y * scaleFactor, 0);
            //make sure z stays 0
            //transform.position = position;
            //move
            //scale
        } else
        {
            Destroy(gameObject); //once we're further destroy ourselves
        }

    }
}
