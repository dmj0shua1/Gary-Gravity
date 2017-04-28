using UnityEngine;
using System.Collections;

public class addGoldScript : MonoBehaviour {

    public int amount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addGold()
    {

        int curGold = PlayerPrefs.GetInt("PlayerGold");

        PlayerPrefs.SetInt("PlayerGold",curGold + amount);
    }
}
