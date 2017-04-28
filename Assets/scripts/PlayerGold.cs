using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGold : MonoBehaviour {
    public int playerGold,injGold;
	// Use this for initialization
	void Start () {
	//check if gold key exists
        if (PlayerPrefs.HasKey("PlayerGold"))
        {
            playerGold = PlayerPrefs.GetInt("PlayerGold");
        }
        else
        {
            //make a key
            PlayerPrefs.SetInt("PlayerGold", 0);
            playerGold = PlayerPrefs.GetInt("PlayerGold");
        }
       
	}
	
	// Update is called once per frame
	void Update () {
       

	}

  
}
