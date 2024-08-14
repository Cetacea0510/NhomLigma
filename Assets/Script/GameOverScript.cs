using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverObject;

    public void Start()
    {
        gameOverObject.SetActive(false);
    }
    public void RedoGame()
    {
        SceneManager.LoadScene("Hieu2");
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
