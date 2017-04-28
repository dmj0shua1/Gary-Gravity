using UnityEngine;
using System.Collections;

public class DestroyOnLoad : MonoBehaviour {

    public GameObject objDestroyable;

	// Use this for initialization
	void Start () {

        objDestroyable = GameObject.FindGameObjectWithTag("timePrinters");
        Destroy(objDestroyable.gameObject);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
