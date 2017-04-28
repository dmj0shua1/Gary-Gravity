using UnityEngine;
using System.Collections;

public class playerMoveUp : MonoBehaviour {
    public GameObject protag;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider moveUp)
    {
        //protag.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
        if (moveUp.gameObject.CompareTag("Player"))
        {
            SwipeMovement.moveUp = true;

        }
    }
}
