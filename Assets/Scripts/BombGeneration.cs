using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class BombGeneration : MonoBehaviour {
    private ArrayList power_up_prefabs;
    private ArrayList bombs;
    public string[] prefab_names;
    GameObject[] wall_parents;
    // Use this for initialization
    void Start () {
        power_up_prefabs = new ArrayList();
        foreach (string name in prefab_names)
        {
            power_up_prefabs.Add(Resources.Load(name, typeof(GameObject)));
        }
        wall_parents = GameObject.FindGameObjectsWithTag("Parent_brick");
        Invoke("GenerateBomb", 5f);
        bombs = new ArrayList();
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < bombs.Count; i++)
        {
            GameObject go = bombs[i] as GameObject;
            if (go != null)
            {
                if (go.transform.position.y > 0f)
                {
                    Renderer r = go.GetComponent<Renderer>();
                    if (!r.isVisible)
                    {
                        Destroy(bombs[i] as GameObject);
                        bombs.RemoveAt(i);
                    }
                }
            }
        }
    }

    void GenerateBomb()
    {
        float randomTime = Random.Range(2f, 8);
        int random_powerup = Random.Range(0, power_up_prefabs.Count);
        GameObject instance = Instantiate((Object)power_up_prefabs[random_powerup]) as GameObject;
        instance.name = "Bomb";
        PositionHelper ph = new PositionHelper();
        Vector3 position = ph.GenerateStartingPosition();
        instance.transform.position = position;
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(0f, 150f, 0f));
        bombs.Add(instance);
        Invoke("GenerateBomb", randomTime);
    }
}
