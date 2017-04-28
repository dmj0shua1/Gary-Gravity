using UnityEngine;
using System.Collections;

public class exit : MonoBehaviour {

	// Use this for initialization

    public GameObject exitDialog,mainmenu;
    bool isShown;
	void Start () {
  


	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && mainmenu.activeSelf == true)
        {
           
            isShown = !isShown;
            exitDialog.SetActive(isShown);
        }
	}

    public void quit()
    {
        Application.Quit();

    }
}
