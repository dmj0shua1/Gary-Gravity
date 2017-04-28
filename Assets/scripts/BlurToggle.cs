using UnityEngine;
using System.Collections;

public class BlurToggle : MonoBehaviour {

	// Use this for initialization
	void Start () {
       

	}
	
	// Update is called once per frame
	void Update () {

	}
	public void TurnBlurOn(){
		GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled = true;
	}
	public void TurnBlurOff(){
		GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled = false;
	}
}

