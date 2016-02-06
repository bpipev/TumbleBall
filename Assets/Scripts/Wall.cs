using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    public bool IsMoving { get; set; }
    public float brick_max_width_scale;
    private float ball_diameter;
    // Use this for initialization
    void Start () {
        ball_diameter = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>().radius * 2;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void ScaleWall(Vector3 wall_middle)
    {
        var wall = this;
        MeshRenderer m = this.GetComponentInChildren<MeshRenderer>();

        wall.transform.localScale = new Vector3(0.1f, 0f, 0.05f);
        m.material.mainTextureScale = new Vector2(0.1f * 2 * 10, 1f);
        
        Vector3 scaleBy = new Vector3();
        
        float width_scale = 0f;
        
        if (Mathf.Abs(wall_middle.x) > ball_diameter)
            brick_max_width_scale = 6f;
        else
            brick_max_width_scale = 6f - ball_diameter * 2;

        brick_max_width_scale *= 10;
        
        width_scale = Random.Range(1, (int)((brick_max_width_scale - wall.transform.localScale.x * 100)));
        scaleBy = new Vector3(0.01f * width_scale, 0f, 0f);
        wall.transform.localScale += scaleBy;
        m.material.mainTextureScale += new Vector2(scaleBy.x * 2 * 10, scaleBy.y);
    }
}
