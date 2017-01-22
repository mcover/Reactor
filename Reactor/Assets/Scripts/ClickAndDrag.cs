using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour {
    private Vector2 screenPoint;
    private Vector2 offset;
  
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
            || Input.mousePosition.x > Screen.width
            || Input.mousePosition.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }
}
