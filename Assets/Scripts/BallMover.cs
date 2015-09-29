using UnityEngine;
using System.Collections;

public class BallMover : MonoBehaviour {
	
	public float rollingSpeed;
	public float jumpHeight;
	public float direction;
	// Update is called once per frame
	void Update () {
		direction = Input.acceleration.x * rollingSpeed;
		GetComponent<Rigidbody2D>().AddForce (new Vector2(direction,0));
		
		foreach (Touch touch in Input.touches) {
			GetComponent<Rigidbody2D>().AddForce (new Vector2(0,jumpHeight));
		}
		
		
	}
}
