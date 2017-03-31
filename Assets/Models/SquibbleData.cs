//=======================================================================
// Ben Resnick, 2017
//=======================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquibbleData {

	//TODO: make this an abstract class
	private GameObject visualRepresentation;
	private Vector3 pos; // position of the visual object

	public SquibbleData(Vector3 _pos) {
		pos = _pos;
	}

	public void setVisualRepresentation(GameObject g) {
		visualRepresentation = g;
		visualRepresentation.transform.position = pos;

		// TODO abstract this
		// TODO once fade is complete, destroy SquibbleData
		g.GetComponent<basicCubeScript>().fade();
	}
}
