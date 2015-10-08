using UnityEngine;
using System.Collections;

public class SetBottomBoundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 top = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, camDistance));
        this.transform.position = new Vector3(0, top.y, 0) - new Vector3(0, this.transform.localScale.x, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GameObject gl = GameObject.FindGameObjectWithTag("GameLogic");
            gl.SendMessage("GameOver");
        }

    }
}
