using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOver;
    public void Start()
    {
        gameOver.SetActive(false);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
