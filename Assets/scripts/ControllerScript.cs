using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ControllerScript : MonoBehaviour

{
    public GameObject ballPrefab;
    private BallScript newBall;

    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;

    public int score1;
    public int score2;

    public PaddleScript[] paddles;

    // Start is called before the first frame update
    void Start()
    {
        score1 = 0;
        score2 = 0;

        scoreText1 = GameObject.FindGameObjectWithTag("score1").GetComponent<TextMeshProUGUI>();
        scoreText2 = GameObject.FindGameObjectWithTag("score2").GetComponent<TextMeshProUGUI>();


        updateScores();
        spawnBall(0);

    }

    private void spawnBall(int dir)
    {
        GameObject curBall = Instantiate(ballPrefab, transform);
        newBall = curBall.GetComponent<BallScript>();
        newBall.transform.position = Vector3.zero;
        if (dir != 0)
        {
            newBall.slowDown(dir);
        }
    }

    private void updateScores()
    {
        scoreText1.text = score1.ToString();
        scoreText2.text = score2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if ((score1 >= 11) && (score1 - score2 >= 2))
        {
            SceneManager.LoadScene("p1win");
        }

        if ((score2 >= 11) && (score2 - score1 >= 2))
        {
            SceneManager.LoadScene("p2win");
        }
    }

    public void player1Score()
    {
        score1++;
        updateScores();
        foreach (PaddleScript paddle in paddles)
        {
            paddle.changeSize(1);
        }
        
        if (score1 >= 9)
        {
            spawnBall(-1);
            spawnBall(1);
        }
        else
        {
            spawnBall(0);
        }
    }

    public void player2Score()
    {
        score2++;
        updateScores();
        foreach (PaddleScript paddle in paddles)
        {
            paddle.changeSize(2);
        }

        if (score2 >= 9)
        {
            spawnBall(-1);
            spawnBall(1);
        }
        else
        {
            spawnBall(0);
        }
    }
}
