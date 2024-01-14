using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject titleScreen;
    public Text finalScoreText;
    public Text highScoreText;

    [SerializeField] private AudioSource gameOverSound;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = "HIGH SCORE: " + highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        //gameOverSound = GetComponent<AudioSource>();
    }

    public void restartGame()
    {
        scoreText.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //titleScreen.SetActive(true);
    }

    public void gameOver()
    {
        if (!gameOverScreen.activeSelf)
        {
            if(playerScore > highScore)
            {
                highScore = playerScore;
                PlayerPrefs.SetInt("highScore", highScore);
                PlayerPrefs.Save();
            }
            finalScoreText.text = playerScore.ToString();
            gameOverScreen.SetActive(true);
            Debug.Log("play game over sound");
            gameOverSound.Play();
            scoreText.enabled = false;
        }
    }
}
