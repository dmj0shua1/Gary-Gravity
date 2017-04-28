using UnityEngine;
using System.Collections;

public class animationBoolChanger : MonoBehaviour {

    public GameObject objectWithAnimator;
    Animator anim;
    public string parameterName;
    public bool conditionToSetForParameter;
	// Use this for initialization
	void Start () {
     

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeBoolean()
    {
        anim = objectWithAnimator.GetComponent<Animator>();
        anim.SetBool(parameterName, conditionToSetForParameter);
    }
}
