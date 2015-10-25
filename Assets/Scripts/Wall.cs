using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    public bool IsMoving { get; set; }
    public float brick_max_width_scale;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void ScaleWall(Vector3 wall_middle)
    {
        float positive_or_negative = 1f;
        Vector3 scaleBy = new Vector3();
        MeshRenderer m = this.GetComponentInChildren<MeshRenderer>();
        float width_scale = 0f;
        var wall = this;

        float ball_width = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().size.x;

        brick_max_width_scale = 0f;
        
        if (Mathf.Abs(wall_middle.x) > ball_width)
            brick_max_width_scale = 6f;
        else
            brick_max_width_scale = 6f - ball_width * 2;

        brick_max_width_scale *= 10;

        float next_width_scale = wall.transform.localScale.x * 100 + width_scale;
        do
        {
            if (next_width_scale >= brick_max_width_scale)
            {
                width_scale = Random.Range(1, (int)((brick_max_width_scale - wall.transform.localScale.x * 100))) * -1f;
            }
            else if (next_width_scale < 10f)
            {
                width_scale = Random.Range(1, (int)((brick_max_width_scale - wall.transform.localScale.x * 100)));
            }
            else
            {
                positive_or_negative = (Random.Range(0, 2) * 2 - 1);
                if (positive_or_negative == -1f)
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
    }
}
