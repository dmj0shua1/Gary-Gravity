using UnityEngine;
using System.Collections;

public class camascend : MonoBehaviour {

	public int MoveSpeed = 0;
	bool touched = false;
	void Update () {
		
		transform.Translate ((Vector3.up * (Time.deltaTime * MoveSpeed)), Space.World);
	}

}
