using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public Transform target;

	void Start(){
		GameObject.Find ("Main Camera/Frame").transform.localScale = new Vector3 (Controller.S.cameraMinSight,Controller.S.cameraMinSight,1);
	}
	
	void Update () {
		Vector3 destination = target.transform.position;
		
		//Keep the same z value for the camera
		destination.z = Camera.main.transform.position.z;
		//Offset to ensure that you don't end up with half tiles on the edge of the screen
		//destination.x += 0.5f;
		transform.position = destination;
	}
}
