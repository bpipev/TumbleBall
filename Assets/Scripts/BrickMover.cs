﻿using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class BrickMover : MonoBehaviour {
    GameObject[] wall_parents;
    public float brick_start_position;
    private Object spike;
    // Use this for initialization
    void Start () {
        spike = Resources.Load("Traps/Prefabs/SpikeBase", typeof(GameObject));
        wall_parents = GameObject.FindGameObjectsWithTag("Parent_brick");
        InvokeRepeating("MoveWall", 0f, 1f);
    }

    void MoveWall()
    {
        foreach(GameObject wall_parent in wall_parents)
        {
            Wall wall = wall_parent.GetComponentInChildren<Wall>();
            if (!wall.IsMoving)
            {
                Rigidbody2D rb = wall_parent.GetComponent<Rigidbody2D>();
                PositionHelper ph = new PositionHelper();
                Vector3 position = ph.GenerateStartingPosition();
                wall_parent.transform.position = position;
                rb.velocity = new Vector3();
                wall.ScaleWall(position);
                wall.IsMoving = true;
                rb.AddForce(new Vector3(0f, 100f, 0f));
                GameObject instance = Instantiate(spike) as GameObject;
                instance.name = "SpikeBase";
                instance.transform.SetParent(wall_parent.transform, false);
                break;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject wall_parent in wall_parents)
        {
            Wall wall = wall_parent.GetComponentInChildren<Wall>();
            Rigidbody2D rb = wall_parent.GetComponent<Rigidbody2D>();
            Renderer r = wall_parent.GetComponentInChildren<Renderer>();
            if (wall.IsMoving && !r.isVisible && wall_parent.transform.position.y > 0f)
            {
                wall.IsMoving = false;
                if (wall_parent.transform.Find("SpikeBase") != null)
                    Destroy(wall_parent.transform.Find("SpikeBase").gameObject);
                rb.velocity = new Vector3();
            }
        }
    }
}
