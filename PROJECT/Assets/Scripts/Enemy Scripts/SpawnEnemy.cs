using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Background;
    public GameOver GameOver;
    public GameObject Enemy;
    float timer = 0f;
    float spawnTime = 5f; // 5 seconds between spawns
    public float max_y;
    public float min_y;
    public int playerScore;
    public Text scoreText; // scoreText displays the score while player is playing
    public Text ScoreText; // ScoreText displays the score on gameover menu
    public void GameOverFunction()
    {
        GameOver.Setup(playerScore);
    }
    // Start is called before the first frame update
    [ContextMenu("Increase Score")]
    public void addScore()
    {
        {
            playerScore += 1;
            scoreText.text = playerScore.ToString();
        }

    }
    public void gameOver()
    {
        Background.SetActive(true);
    }
    void Start()
    {
        spawn_Enemy();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            spawn_Enemy();
            timer = 0f; // reset the timer
        }
    }
    void spawn_Enemy()
    {
        Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(max_y, min_y), -1), transform.rotation);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
