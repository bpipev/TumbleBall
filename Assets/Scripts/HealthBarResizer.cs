using UnityEngine;
using System.Collections;

public class HealthBarResizer : MonoBehaviour {

    private Vector3 starting_size;

	// Use this for initialization
	void Start () {
        starting_size = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetSize(float percentage)
    {
        transform.localScale = new Vector3(percentage * starting_size.x, starting_size.y, starting_size.z);
    }
}
