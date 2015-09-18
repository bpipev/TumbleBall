using UnityEngine;
using System.Collections;

public class BrickMover : MonoBehaviour {
    GameObject[] bricks;
    // Use this for initialization
    void Start () {
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        InvokeRepeating("MoveBrick", 0f, 1f);
    }

    void MoveBrick()
    {
        foreach(GameObject brick in bricks)
        {
            Brick b = brick.GetComponent<Brick>();
            Rigidbody rb = brick.GetComponent<Rigidbody>();
            if (!b.IsMoving)
            {
                brick.transform.position = new Vector3(0f, -6f, 0f);
                b.IsMoving = true;
                rb.AddForce(new Vector3(0f, 100f, 0f));
                break;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject brick in bricks)
        {
            Brick b = brick.GetComponent<Brick>();
            Rigidbody rb = brick.GetComponent<Rigidbody>();
            Renderer r = brick.GetComponent<Renderer>();
            if (b.IsMoving && !r.isVisible && brick.transform.position.y > 0f)
            {
                b.IsMoving = false;
                rb.velocity = new Vector3();
            }
        }
    }
}
