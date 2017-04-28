using UnityEngine;
using System.Collections;

public class objectrotator : MonoBehaviour {

	public int rotSpeedX=30;
	public int rotSpeedY=30;
	public int rotSpeedZ=30;
	// Update is called once per frame
	void Update () {

		//local y axis 1 degree
		transform.Rotate (Vector3.right * Time.deltaTime * rotSpeedZ);

		//world x axis
		transform.Rotate (Vector3.up * Time.deltaTime * rotSpeedY);

		//rotate z
		transform.Rotate (Vector3.back * Time.deltaTime * rotSpeedX);
	}
}
