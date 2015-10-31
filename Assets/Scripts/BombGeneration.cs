using UnityEngine;
using System.Collections;

public class BombGeneration : MonoBehaviour {
    private Object bomb;
    GameObject[] wall_parents;
    // Use this for initialization
    void Start () {
        bomb = Resources.Load("PowerUps/Prefabs/Bomb Red", typeof(GameObject));
        wall_parents = GameObject.FindGameObjectsWithTag("Parent_brick");
        InvokeRepeating("GenerateBomb", 0f, 5f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void GenerateBomb()
    {
        foreach (GameObject wall_parent in wall_parents)
        {
            Wall wall = wall_parent.GetComponentInChildren<Wall>();
            if (!wall.IsMoving)
            {
                GameObject instance = Instantiate(bomb) as GameObject;
                instance.name = "Bomb";
                instance.transform.SetParent(wall_parent.transform, false);
                instance.transform.position -= new Vector3(-3f, 0f, 0f);
                return;
            }
        }
    }
}
