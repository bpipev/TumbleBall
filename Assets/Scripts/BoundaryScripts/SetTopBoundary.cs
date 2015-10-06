using UnityEngine;
using System.Collections;

public class SetTopBoundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 top = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, camDistance));
        this.transform.position = new Vector3(0, top.y, 0) + new Vector3(0, this.transform.localScale.x / 2, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
