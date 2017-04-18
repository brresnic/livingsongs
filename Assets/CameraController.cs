//=======================================================================
// Ben Resnick, 2016
//=======================================================================

using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;

	Quaternion startRotation, endRotation;
	float period, time, distanceToNewPoint;
	Vector3 startPoint, endPoint;

	//values for internal use
	private Quaternion _lookRotation;
	private Vector3 direction, normalizedDirection;

	public void LookAt(Vector3 point) {

		//set params for the animation 					
		time = 0f;
		period = 2f;  // length of the animation
		enabled = true;

		// Store the start and end values
		startRotation = transform.rotation; // find the vector pointing from our position to the target
		distanceToNewPoint = (point - transform.position).magnitude;
		normalizedDirection = (point - transform.position).normalized; // create the rotation we need to look at the target
		endRotation = Quaternion.LookRotation(normalizedDirection);
		startPoint = transform.position;
		this.endPoint = transform.position + normalizedDirection*(distanceToNewPoint * 0.7f);
	}

	void Update() {
		if(enabled) {
			time += Time.deltaTime;
			if(time >= period) {
				transform.LookAt(endPoint);
				enabled = false;
			}
			else {
				// Rotate us over time according to speed until we are in the required rotation
				transform.rotation = Quaternion.Slerp(startRotation, endRotation, time/period);
				// Move over time towards the target position
				transform.position = Vector3.Lerp (startPoint, endPoint, time/period);
			}
		}
	}
}





