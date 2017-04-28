using UnityEngine;
using System.Collections;

public class objectScaler : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{


		float depth = gameObject.transform.lossyScale.z;
		float width = gameObject.transform.lossyScale.x;
		float height = gameObject.transform.lossyScale.y;

		Vector3 lowerLeftPoint = Camera.main.WorldToScreenPoint( new Vector3( gameObject.transform.position.x - width/2, gameObject.transform.position.y - height/2, gameObject.transform.position.z - depth/2 ) );
		Vector3 upperRightPoint = Camera.main.WorldToScreenPoint( new Vector3( gameObject.transform.position.x + width/2, gameObject.transform.position.y + height/2, gameObject.transform.position.z - depth/2 ) );
		Vector3 upperLeftPoint = Camera.main.WorldToScreenPoint( new Vector3( gameObject.transform.position.x - width/2, gameObject.transform.position.y + height/2, gameObject.transform.position.z - depth/2 ) );
		Vector3 lowerRightPoint = Camera.main.WorldToScreenPoint( new Vector3( gameObject.transform.position.x + width/2, gameObject.transform.position.y - height/2, gameObject.transform.position.z - depth/2 ) );

		float xPixelDistance = Mathf.Abs( lowerLeftPoint.x - upperRightPoint.x );
		float yPixelDistance = Mathf.Abs ( lowerLeftPoint.y - upperRightPoint.y );

		print( "This is the X pixel distance: " + xPixelDistance + " This is the Y pixel distance: " + yPixelDistance );
		print ("This is the lower left pixel point: " + lowerLeftPoint);
		print(" This is the upper left point: " + upperLeftPoint );
		print ("This is the lower right pixel point: " + lowerRightPoint);
		print(" This is the upper right pixel point: " + upperRightPoint);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
