using UnityEngine;
using System.Collections;

public class DebugLog : MonoBehaviour {

    public string log;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void printCustomLog()
    {
        Debug.Log(log);
    }
}
