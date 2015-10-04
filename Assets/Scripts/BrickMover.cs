using UnityEngine;
using System.Collections;

public class BrickMover : MonoBehaviour {
    GameObject[] bricks;
    public float brick_start_position;
    public float brick_max_width_scale;
    // Use this for initialization
    void Start () {
        bricks = GameObject.FindGameObjectsWithTag("Parent_brick");
        InvokeRepeating("MoveBrick", 0f, 1f);
    }

    void MoveBrick()
    {
        foreach(GameObject brick in bricks)
        {
            Brick b = brick.GetComponent<Brick>();
            if (!b.IsMoving)
            {
                MeshRenderer m = brick.GetComponentInChildren<MeshRenderer>();
                Rigidbody2D rb = brick.GetComponent<Rigidbody2D>();
                float positive_or_negative = (Random.Range(0, 2) * 2 - 1);
                Vector3 position = new Vector3((float)Random.Range(0, 31)/10f * positive_or_negative, brick_start_position, 0f);
                brick.transform.position = position;
                Vector3 scaleBy = new Vector3();
                float width_scale = 0f;
                var wall = brick.transform.Find("Wall");
                float next_width_scale = wall.transform.localScale.x * 100 + width_scale;
                do
                {
                    if (next_width_scale >= brick_max_width_scale)
                    {
                        width_scale = Random.Range(1, (int)((brick_max_width_scale - wall.transform.localScale.x * 100) )) * -1f;
                    }
                    else if (next_width_scale < 10f)
                    {
                        width_scale = Random.Range(1, (int)((brick_max_width_scale - wall.transform.localScale.x * 100)));
                    }
                    else
                    {
                        positive_or_negative = (Random.Range(0, 2) * 2 - 1);
                        if(positive_or_negative == -1f)
                        {
                            width_scale = Random.Range(1, (int)((wall.transform.localScale.x * 100 - 10f))) * positive_or_negative;
                        }
                        else
                        {
                            width_scale = Random.Range(1, (int)((brick_max_width_scale - wall.transform.localScale.x * 100))) * positive_or_negative;
                        }
                    }
                    next_width_scale = wall.transform.localScale.x * 100 + width_scale;
                } while (next_width_scale < 10f || next_width_scale >= brick_max_width_scale);
                scaleBy = new Vector3(0.01f * width_scale, 0f, 0f);
                wall.transform.localScale += scaleBy;
                m.material.mainTextureScale += new Vector2(scaleBy.x * 2 * 10, scaleBy.y);
                rb.velocity = new Vector3();
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
            Renderer r = brick.GetComponentInChildren<Renderer>();
            if (b.IsMoving && !r.isVisible && brick.transform.position.y > 0f)
            {
                b.IsMoving = false;
                rb.velocity = new Vector3();
            }
        }
    }
}
