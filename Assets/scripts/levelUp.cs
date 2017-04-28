using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelUp : MonoBehaviour {

    public int score;
    public int[] lvl;
    public int lvlNum;
    scoreCounter scoreCounter;
    Text level;
    Text skillpoints;
    Text txtLvl, txtExpReq,txtExpCur;
    public float expTotal;
    Slider expSlider;
	// Use this for initialization
	void Start () {
        scoreCounter = GameObject.Find("subScoreCounter").GetComponent<scoreCounter>();
        if (!PlayerPrefs.HasKey("expEarned")) PlayerPrefs.SetFloat("expEarned", 0.0f);  
        if (!PlayerPrefs.HasKey("playerLevel")) PlayerPrefs.SetInt("playerLevel", 1);
        if (!PlayerPrefs.HasKey("skillPoints")) PlayerPrefs.SetInt("skillPoints", 0);
        lvlNum = 0;


        //display temporary code  

     /*   skillpoints = GameObject.Find("skillpoints").GetComponent<Text>();
        level= GameObject.Find("level").GetComponent<Text>();
        level.text = "Level: " + PlayerPrefs.GetInt("playerLevel").ToString() ;
        skillpoints.text = "Skillpoints: " + PlayerPrefs.GetInt("skillPoints").ToString();*/

        //print required xp and current level
        txtLvl = GameObject.Find("txtLvl").GetComponent<Text>();
        txtExpReq = GameObject.Find("txtExpReq").GetComponent<Text>();
        expSlider = GameObject.Find("expSlider").GetComponent<Slider>();
        txtExpCur = GameObject.Find("txtExpCur").GetComponent<Text>();

        checkReachedScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void checkReachedScore()
    {

        var expEarned = PlayerPrefs.GetFloat("expEarned");

        score = scoreCounter.count;
        var expReq = lvl[lvlNum];
        float scoreToExp = (score / 10.0f);
        expTotal = scoreToExp+expEarned;
        print("expTotal: "+expTotal.ToString());
        if (scoreToExp == expReq )
        {    
            lvlNum += 1;
            //display temporary code
            level.text = "Level: " + PlayerPrefs.GetInt("playerLevel").ToString();
            skillpoints.text = "Skillpoints: " + PlayerPrefs.GetInt("skillPoints").ToString();
        }
    }
    public void lvlUp()
    {

        if (expTotal >= lvl[PlayerPrefs.GetInt("playerLevel") - 1])
        {
            PlayerPrefs.SetInt("playerLevel", PlayerPrefs.GetInt("playerLevel") + 1);
            //notify code here
            PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") + 1);

        }

        print("expreq: "+(PlayerPrefs.GetInt("playerLevel") - 1).ToString());
        PlayerPrefs.SetFloat("expEarned", expTotal);
        txtLvl.text = "lvl "+ PlayerPrefs.GetInt("playerLevel").ToString();
        txtExpReq.text = lvl[PlayerPrefs.GetInt("playerLevel") - 1].ToString();
        txtExpCur.text = expTotal.ToString();

        //tempslider
        expSlider.maxValue = lvl[PlayerPrefs.GetInt("playerLevel") - 1];
        expSlider.value = expTotal;



    }

   
}
