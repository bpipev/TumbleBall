using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PowerUpGeneration : MonoBehaviour {
    private ArrayList power_up_prefabs;
    private ArrayList power_ups;
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
        Invoke("InitializeObject", 5f);
        power_ups = new ArrayList();
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < power_ups.Count; i++)
        {
            GameObject go = power_ups[i] as GameObject;
            if (go != null)
            {
                if (go.transform.position.y > 0f)
                {
                    Renderer r = go.GetComponent<Renderer>();
                    if (!r.isVisible)
                    {
                        Destroy(power_ups[i] as GameObject);
                        power_ups.RemoveAt(i);
                    }
                }
            }
        }
    }

    void InitializeObject()
    {
        float randomTime = Random.Range(2f, 3f);
        int randomPowerup = Random.Range(0, power_up_prefabs.Count);
        CreateObject(randomTime, randomPowerup);
    }

    void CreateObject(float randomTime, int randomPowerup)
    {
        GameObject instance = Instantiate((Object)power_up_prefabs[randomPowerup]) as GameObject;
        PositionHelper ph = new PositionHelper();
        Vector3 position = ph.GenerateStartingPosition();
        instance.transform.position = position;
        instance.transform.localScale += new Vector3(1, 1, 1);
        instance.AddComponent<Rigidbody2D>();
        instance.AddComponent<CircleCollider2D>();
        CircleCollider2D cc = instance.GetComponent<CircleCollider2D>();
        cc.isTrigger = true;
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        rb.AddForce(new Vector3(0f, 150f, 0f));
        power_ups.Add(instance);
        Invoke("InitializeObject", randomTime);
    }
}
