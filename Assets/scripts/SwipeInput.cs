using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwipeInput : MonoBehaviour {
	public GameObject target;
	private Vector3 fp;   //First touch position
	private Vector3 lp;   //Last touch position
	private float dragDistance;  //minimum distance for a swipe to be registered
	private List<Vector3> touchPositions = new List<Vector3>(); //store all the touch positions in list
	public int speed;
	public GameObject protag = null;
	// Use this for initialization
	void Start(){
		dragDistance = Screen.height*20/100; //dragDistance is 20% height of the screen 
	}
	
	// Update is called once per frame
	void Update(){

		foreach (Touch touch in Input.touches)  //use loop to detect more than one swipe
		{ //can be ommitted if you are using lists 
			/*if (touch.phase == TouchPhase.Began) //check for the first touch
    {
        fp = touch.position;
        lp = touch.position;
 
    }*/

			if (touch.phase == TouchPhase.Moved) //add the touches to list as the swipe is being made
			{
				touchPositions.Add(touch.position);
			}

			if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
			{
				//lp = touch.position;  //last touch position. Ommitted if you use list
				fp =  touchPositions[0]; //get first touch position from the list of touches
				lp =  touchPositions[touchPositions.Count-1]; //last touch position 

				//Check if drag distance is greater than 20% of the screen height
				if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
				{//It's a drag
					//check if the drag is vertical or horizontal 
					if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
					{   //If the horizontal movement is greater than the vertical movement...
						if ((lp.x>fp.x))  //If the movement was to the right)
						{   //Right swipe
							Debug.Log("Right Swipe");
							//protag.transform.Translate (Vector3.left * speed * Time.deltaTime);
						}
						else
						{   //Left swipe
							Debug.Log("Left Swipe"); 
							MoveTowardsTarget ();
						}
					}
					else
					{   //the vertical movement is greater than the horizontal movement
						if (lp.y>fp.y)  //If the movement was up
						{   //Up swipe
							Debug.Log("Up Swipe"); 
							//protag.transform.Translate (Vector3.up * speed * Time.deltaTime);
						}
						else
						{   //Down swipe
							Debug.Log("Down Swipe");
							//protag.transform.Translate (Vector3.down * speed * Time.deltaTime);
						}
					}
				} 
			}
			else
				
			{  Debug.Log("Its a tap!"); //It's a tap as the drag distance is less than 20% of the screen height
				
			}
		}
	}

	//move towards a target at a set speed.
	private void MoveTowardsTarget() {
		//the speed, in units per second, we want to move towards the target
		float speed = 1;
		//move towards the center of the world (or where ever you like)
		Vector3 targetPosition = target.transform.position;

		Vector3 currentPosition = this.transform.position;
		//first, check to see if we're close enough to the target
		if(Vector3.Distance(currentPosition, targetPosition) > .1f) { 
			Vector3 directionOfTravel = targetPosition - currentPosition;
			//now normalize the direction, since we only want the direction information
			directionOfTravel.Normalize();
			//scale the movement on each axis by the directionOfTravel vector components

			this.transform.Translate(
				(directionOfTravel.x * speed * Time.deltaTime),
				(directionOfTravel.y * speed * Time.deltaTime),
				(directionOfTravel.z * speed * Time.deltaTime),
				Space.World);
		}
	}

}
