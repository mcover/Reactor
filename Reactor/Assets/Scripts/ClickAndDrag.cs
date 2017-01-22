using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour {
    private Vector2 screenPoint;
    private Vector2 offset;
    private Vector2 previousCursorPosition;
    private bool    isRotating;
    public float destroyOffset = 5;

    // Update is called once per frame
    void OnMouseDown () {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
	}
    void OnMouseDrag() {
        Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition+ offset;
    }

    void OnMouseUp()
    {
        //Destroy objects if cursor is released off screen
        //Not sure if this works if we move the camera?
        //Debug.LogFormat("Position on release: {0},{1}", Input.mousePosition.x, Input.mousePosition.y);
        if (Input.mousePosition.x < 0
            || Input.mousePosition.y < 0
            || Input.mousePosition.x > Screen.width-destroyOffset
            || Input.mousePosition.y > Screen.height-destroyOffset)
        {
            Destroy(gameObject);
        }
    }

    //Capture right click events
    void OnGUI()
    {
        //Right click
        if (Event.current.button == 1)
        {
            //OnMouseDown
            if (Event.current.type == EventType.MouseDown)
            {
                Camera currentCamera = Camera.main;        // take the current camera SceneView or gameView doesn't matter
                if (currentCamera == null)
                    return;

                Vector3 mousePosition = Input.mousePosition;
                Ray screenRay = currentCamera.ScreenPointToRay(mousePosition);

                RaycastHit rayhit;
                if (!Physics.Raycast(screenRay, out rayhit))
                {
                    return;
                }

                if (rayhit.collider == GetComponent<Collider>())
                {
                    //Debug.LogFormat("Dragging: {0}", name);
                    isRotating = true;
                }
            }

            //OnMouseUp
            if (Event.current.type == EventType.MouseUp)
            {
                //Debug.LogFormat("Stopped rotating");
                isRotating = false;
            }
        }
    }

    //Handle drag rotation
    void Update()
    {
        if (isRotating)
        {
            Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 differenceCursorPosition = curScreenPoint - previousCursorPosition;
            //Debug.LogFormat("previousCursorPosition = : {0}", previousCursorPosition);
            //Debug.LogFormat("curScreenPoint = : {0}", curScreenPoint);
            //Debug.LogFormat("Rotating, offset, rotation = : {0}", differenceCursorPosition);
            float angleToRotate = differenceCursorPosition.x + differenceCursorPosition.y;
            Debug.LogFormat("Rotating, angle = : {0}", angleToRotate);
            transform.rotation *= Quaternion.AngleAxis(angleToRotate, new Vector3(0,0,1));
            GetComponent<CircleDrawer>().arcCenter += angleToRotate;
        }

        //Debug.LogFormat("old = : {0}", previousCursorPosition);
        previousCursorPosition = Input.mousePosition;
        //Debug.LogFormat("new = : {0}", previousCursorPosition);
    }
}
