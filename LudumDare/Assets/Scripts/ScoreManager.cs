using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text highScoreText;

    private float score = 0;

    private void Start() {
        highScoreText.text = "Highscore:" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = "Score:" + ((int)score).ToString();
    }

    private void OnDisable()
    {
        if (((int)score) > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", ((int)score));
        }
    }
}
