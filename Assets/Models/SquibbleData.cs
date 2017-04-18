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
		// ((BasicCube) visualRepresentation).setData (this); // TODO fix this, no casting

		// TODO abstract this
		// TODO once fade is complete, destroy SquibbleData
		g.GetComponent<BasicCube>().fade();
		// g.GetComponent<BasicCube>().setData (this);
	}


	// TODO call this
	public void destroy() {
		// Object.Destroy (this);
		// manage this in LivingSongsController
	}
}
