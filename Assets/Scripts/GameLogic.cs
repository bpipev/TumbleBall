using UnityEngine;

public class GameLogic : MonoBehaviour {

    private int score;

    public int Score {
        get { return score; } 
        set { score = value; }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void AddPoints()
    {
        Score += 100;
        GameObject.FindGameObjectWithTag("Score").GetComponent<TextMesh>().text = "Score: " + score;
        Debug.Log("Add Points");
    }
}
