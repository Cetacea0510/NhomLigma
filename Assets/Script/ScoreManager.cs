using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    int score = 0;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scoreText.text = "Score:" + score.ToString(); 
    }
    public void AddPoint()
    {
        score += 250;
        scoreText.text = "Score:" + score.ToString();
    }
}
