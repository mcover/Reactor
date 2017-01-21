
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrawer : MonoBehaviour {
	private float thetaScale = 0.01f;        // radians: set lower to add more points
	private int numPts; //Total number of points in circle
	private float radiusEnd;
	private LineRenderer lineRenderer;

	private float radiansWidth;  // width of arc in radians
	private float thetaStart;  // starting angle start arc in radians

	public float lineThickness = 0.02f;
	public float radiusStop = 5f;
	public float radiusStep = 1f;
	public float arcCenter = 0f;  // degrees
	public float arcWidth = 360f;  // degrees
	public Color color = Color.white;
	public float collisionThickness = 0.2f;

	// Use this for initialization
	void Start () {
		
	}

	void Awake() {
		thetaStart = 2.0f * Mathf.PI * (arcCenter - arcWidth / 2f) / 360f;  // starting angle in radians
		radiansWidth = arcWidth / 180f;
		float sizeValue = (radiansWidth * Mathf.PI) / thetaScale; 
		numPts = (int)sizeValue;
		numPts++;  // one more to complete circle
		radiusEnd = 0f;  // initial radius
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetWidth(lineThickness, lineThickness);
		lineRenderer.SetVertexCount(numPts);
		lineRenderer.SetColors(color, color);
	}

	// Update is called once per frame
	void FixedUpdate() {
		radiusEnd += radiusStep;
		if (radiusEnd > radiusStop)
			return;
		
		float radius = radiusEnd;

		Vector3 pos;
		Vector3? lastPt = null;
		float theta = thetaStart;

		for (int i = 0; i < numPts; i++) {     
			float x = radius * Mathf.Cos (theta);
			float y = radius * Mathf.Sin (theta);          
			x += gameObject.transform.position.x;
			y += gameObject.transform.position.y;
			pos = new Vector3 (x, y, 0);

			lineRenderer.SetPosition (i, pos);
			theta += (radiansWidth * thetaScale);

			if (lastPt != null) {
				Vector3 dir = lastPt.Value - pos;

				RaycastHit[] castHits = Physics.SphereCastAll(pos, collisionThickness, dir.normalized, dir.magnitude);

                foreach (var hit in castHits)
                {
                    var HitMeFunctions = hit.collider.gameObject.GetComponents<IHitMe>();
                    foreach (var HitMeFunction in HitMeFunctions)
                    {
                        HitMeFunction.HitMe();
                    }
                }
			}

			lastPt = pos;
		}
	}
}