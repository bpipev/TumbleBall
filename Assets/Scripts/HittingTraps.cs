using UnityEngine;
using System.Collections;

public class HittingTraps : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Spike")
        {
            GameLogic gl = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
            gl.GameOver();
        }

    }
}
