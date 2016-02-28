using UnityEngine;
using System.Collections;

public class HittingObjects : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "HealthDown")
        {
            GameLogic gl = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
            gl.LosePoints();
            HealthBarResizer hbr = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBarResizer>();
            hbr.SetSize(gl.Health/100f);
            GetComponentInChildren<ParticleSystem>().Play();
            Destroy(coll.gameObject);
        }
        else if(coll.gameObject.tag == "ExtraPoints")
        {
            GameLogic gl = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
            gl.AddPoints();
            GetComponentInChildren<EllipsoidParticleEmitter>().Emit();
            Destroy(coll.gameObject);
        }
    }
}
