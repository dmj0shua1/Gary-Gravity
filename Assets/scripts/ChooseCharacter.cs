using UnityEngine;
using System.Collections;

public class ChooseCharacter : MonoBehaviour {

    public GameObject chosenChar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChooseChar()
    {
        PlayerPrefs.SetString("chosenChar", chosenChar.name);
      
    }
}
