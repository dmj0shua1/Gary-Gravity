using UnityEngine;
using System.Collections;

public class StartingPlayerPrefs : MonoBehaviour {

	// Use this for initialization
	void Start () {
	//gold
        if (PlayerPrefs.HasKey("PlayerGold"))
        {
            //do nothing
        }
        else
        {
            PlayerPrefs.SetInt("PlayerGold", 0);
            PlayerPrefs.Save();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
