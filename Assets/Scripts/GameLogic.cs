using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    private int score;
    private float restart_timer;
    private bool game_over = false;
    private GameObject restart_button;

    public int Score {
        get { return score; } 
        set { score = value; }
    }

    private int health = 100;

    public int Health {
        get { return health; }
        set { health = value; }
    }

	// Use this for initialization
	void Start () {
        Renderer r = GameObject.FindGameObjectWithTag("GameOver").GetComponent<Renderer>();
        r.enabled = false;
        restart_button = GameObject.FindGameObjectWithTag("RestartButton");
        restart_button.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	    if(Health <= 0 || game_over)
        {
            restart_timer += Time.deltaTime;
            Time.timeScale = 0f;
        }
	}

    public void Restart()
    {
        restart_timer = 0;
        Time.timeScale = 1f;
        game_over = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Renderer r = GameObject.FindGameObjectWithTag("GameOver").GetComponent<Renderer>();
        r.enabled = true;
        restart_button.SetActive(true);
        game_over = true;
    }

    public void LosePoints()
    {
        Health -= 10;
        if(Health == 0)
        {
            GameOver();
        }
    }

    public void AddPoints()
    {
        Score += 100;
        GameObject.FindGameObjectWithTag("Score").GetComponent<TextMesh>().text = "Score: " + score;
        Debug.Log("Add Points");
    }
}
