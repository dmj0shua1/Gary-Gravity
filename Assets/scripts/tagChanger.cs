using UnityEngine;
using System.Collections;

public class tagChanger : MonoBehaviour {

    
    GameObject targetObject;
    public string objectTargetName,newTag;
    public bool automatic;

	// Use this for initialization
	void Start () {
        if (automatic)
        {
            targetObject = GameObject.Find(objectTargetName);
            targetObject.tag = objectTargetName;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeTag()
    {
        targetObject = GameObject.Find(objectTargetName);
        targetObject.tag = objectTargetName;
    }
}
