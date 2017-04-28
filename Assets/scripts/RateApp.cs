using UnityEngine;
using System.Collections;

public class RateApp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void rAppbeh(){

#if UNITY_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.loopbook.garyg");
#elif UNITY_IPHONE
        Application.OpenURL("http://itunes.apple.com/app/id1068341133");
#endif
    }
}
