using UnityEngine;
using System.Collections;

public class SetLeftBoundary : MonoBehaviour {

    public bool IsLeftBoundary { get; set; }
	// Use this for initialization
	void Start () {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 left_side = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, camDistance));
        this.transform.position = new Vector3(left_side.x, 0, 0) - new Vector3(this.transform.localScale.x/2, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
