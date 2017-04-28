using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class highScore : MonoBehaviour {

    Text scoreText,hscoreText,txtScore;
    public int score, hscore;
    GameObject objFBHolder;
    FBholder fbholder;
    int scoreForFb;
	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        hscoreText = GameObject.Find("txtHs").GetComponent<Text>();
        txtScore = GameObject.Find("txtScore").GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CheckAndSet()
    {
        score = int.Parse(scoreText.text);
        if (PlayerPrefs.HasKey("Highscore"))
        {
          
            hscore = PlayerPrefs.GetInt("Highscore");

            if (score > hscore)
            {
                hscoreText.text = score.ToString();
                PlayerPrefs.SetInt("Highscore", score);
                txtScore.text = "new highscore";
                scoreForFb = score;
                

            }
            else
            {
                hscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
                scoreForFb = hscore;
            }
            SetScore();
        }
        else
        {

            PlayerPrefs.SetInt("Highscore", score);
            hscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
            scoreForFb = score;
            SetScore();
        }
    }

    void SetScore()
    {
        if (FB.IsLoggedIn) {
          
        var scoreData = new Dictionary<string, string>();
        scoreData["score"] = UnityEngine.Random.Range(scoreForFb, scoreForFb).ToString();
        FB.API("/me/scores", Facebook.HttpMethod.POST, delegate(FBResult result)
        {
            Debug.Log("Score submit result: " + result.Text);
        }, scoreData);
                        }

    }


}
