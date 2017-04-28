using UnityEngine;
using System.Collections;

 public class ChangeLane : MonoBehaviour {
 
     public bool toChangeLane, toLeft, toRight;
     public bool isChangingLane;
     public Vector3 targetPosition;
     public float laneDistance;
     
     
     private CharacterController dogCtrl;
     
     void Awake()
     {
         dogCtrl = GetComponent<CharacterController>();
         targetPosition = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
     }
     
     void Update()
     {
         if(toChangeLane)
         {
             if(toLeft)
             {
                 targetPosition = new Vector3(transform.position.x - laneDistance, transform.position.y, transform.position.z);
                 toLeft = false;
             }
             else if(toRight)
             {
                 targetPosition = new Vector3(transform.position.x + laneDistance, transform.position.y, transform.position.z);
                 toRight = false;
             }
             isChangingLane = true;
             toChangeLane = false;
         }
         
         else if(isChangingLane)
         {
             MoveToPoint();
         }
     }
     
     void MoveToPoint()
     {
         Vector3 movDiff = targetPosition - transform.position;
         if(movDiff.magnitude > .1f)
         {
             movDiff = movDiff.normalized * 15f;
             dogCtrl.Move(movDiff * Time.deltaTime);
         }
         else
         {
             transform.position = targetPosition;
             isChangingLane = false;
         }
         Debug.Log(movDiff.magnitude);
         //targetPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
     }
     
 }
