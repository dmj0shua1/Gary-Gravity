using UnityEngine;
using System.Collections;


public class timeStampTest : MonoBehaviour {

  
	// Use this for initialization
	void Start () {
        long period = 10L * 60L * 1000L * 10000L; // In ticks
        long timeStamp = System.DateTime.Now.Ticks + period;

        //PlayerPrefs.SetLong("timeStamp", timeStamp);
        // Later that day (after re-reading timestamp)...
        if (System.DateTime.Now.Ticks >= timeStamp)
        {
            // Trigger something
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
