using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

	public float minX, maxX;
	// Use this for initialization
	void Start () {

		float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
		Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0,0, camDistance));
		Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1,1, camDistance));
		minX = bottomCorner.x;
		maxX = topCorner.x;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;
		
		if(pos.x < minX) pos.x = minX;
		if(pos.x > maxX) pos.x = maxX;

		transform.position = pos;
	
	}
}
