using UnityEngine;
using System.Collections;

public class BrickMover : MonoBehaviour {
    GameObject[] bricks;
    public float brick_start_position = -6f;
    public float brick_max_width_scale = 0.5f;
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
                float next_width_scale = brick.transform.localScale.x + width_scale;
                do
                {
                    if (next_width_scale >= brick_max_width_scale)
                    {
                        width_scale = 0.1f * Random.Range(0, (int)((brick_max_width_scale - brick.transform.Find("Wall").localScale.x) * 10)) * -1f;
                    }
                    else if (next_width_scale < 0.1f)
                    {
                        width_scale = 0.1f * Random.Range(0, (int)((brick_max_width_scale - brick.transform.Find("Wall").localScale.x) * 10));
                    }
                    else
                    {
                        positive_or_negative = (Random.Range(0, 2) * 2 - 1);
                        width_scale = 0.1f * Random.Range(0, (int)((brick_max_width_scale - brick.transform.Find("Wall").localScale.x) * 10)) * positive_or_negative;
                    }
                    next_width_scale = brick.transform.Find("Wall").localScale.x + width_scale;
                } while (next_width_scale < 0.1f || next_width_scale >= brick_max_width_scale);
                scaleBy = new Vector3(width_scale, 0f, 0f);
                brick.transform.Find("Wall").localScale += scaleBy;
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
