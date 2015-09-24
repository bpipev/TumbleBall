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
            if (!b.IsMoving)
            {
                MeshRenderer m = brick.GetComponent<MeshRenderer>();
                Rigidbody2D rb = brick.GetComponent<Rigidbody2D>();
                float positive_or_negative = (Random.Range(0, 2) * 2 - 1);
                Vector3 position = new Vector3(0.5f + Random.Range(1, 6) * positive_or_negative, -6f, 0f);
                brick.transform.position = position;
                Vector3 scaleBy = new Vector3();
                float width_scale = 0f;
                if (brick.transform.localScale.x >= 1f)
                {
                    brick.transform.localScale = new Vector3(0.1f, 1f, 0.05f);
                    width_scale = 0.1f;
                    m.material.mainTextureScale = new Vector2(2f, 2f);
                }
                else
                {
                    positive_or_negative = (Random.Range(0, 2) * 2 - 1);
                    do
                    {
                        positive_or_negative = (Random.Range(0, 2) * 2 - 1);
                        width_scale = 0.1f * Random.Range(0, 10) * positive_or_negative;
                    } while (width_scale < 0.1f);
                    scaleBy = new Vector3(width_scale, 0f, 0f);
                    brick.transform.localScale += scaleBy;
                    m.material.mainTextureScale += new Vector2(scaleBy.x * 2 * 10, scaleBy.y);
                }
                
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
            Rigidbody2D rb = brick.GetComponent<Rigidbody2D>();
            Renderer r = brick.GetComponent<Renderer>();
            if (b.IsMoving && !r.isVisible && brick.transform.position.y > 0f)
            {
                b.IsMoving = false;
                rb.velocity = new Vector3();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Wall")
            //collision.gameObject.ve
    }
}
