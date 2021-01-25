using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public Ball initialBall;
    public Ball ballPrefab;

    public Player player;

    public static bool startGame;
    public static bool gameStarted;
    public static bool playGame = true;

    public static int count;
    public static int lives = 5;
    public static int score = 50;

    public Text endGame;
    public Text scoreText;
    public Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        //playAgain();
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        initializeBall();
    }

    // Update is called once per frame
    void Update()
    {
        //playAgain();
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        winGame();
        //playAgain();
        preStartGame();
        loseGame();
        //playAgain();
    }

    public void initializeBall()
    {
        Vector3 playerPos = player.gameObject.transform.position;
        Vector3 ballPos = new Vector3(playerPos.x, playerPos.y + .25f, 0);
        initialBall = Instantiate(ballPrefab, ballPos, Quaternion.identity);
    }

    public void preStartGame()
    {
        Vector3 playerPos = player.gameObject.transform.position;
        Vector3 ballPos = new Vector3(playerPos.x, playerPos.y + .25f, 0);
        if (Input.GetMouseButtonDown(0))
        {
            startGame = true;
        }
        if (!startGame)
        {
            initialBall.transform.position = ballPos;
        }
    }

    public void winGame()
    {
        GameObject[] bricks;
        bricks = GameObject.FindGameObjectsWithTag("brick");
        count = bricks.Length;
        if (count == 0)
        {
            endGame.text = "YOU WIN THE GAME!!!";
            endGamePanel.SetActive(true);
        }
    }

    public void loseGame()
    {
        if (lives <= 0) //initialBall == null 
        {
            lives = 0;
            endGame.text = "YOU LOSE!";
            endGamePanel.SetActive(true);
        }
    }

    public void playAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void quitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }

}