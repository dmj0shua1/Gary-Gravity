using UnityEngine;
using System.Collections;

public class MainCamSceneMenu : MonoBehaviour {

	public void GoToGame () {
		SimpleSceneFader.ChangeSceneWithFade("Game");
	}

}
