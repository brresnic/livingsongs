//=======================================================================
// Ben Resnick, 2017
//=======================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquibbleData : MonoBehaviour {

	//TODO: make this an abstract class
	protected GameObject visualRepresentation;
	protected Vector3 pos; // position of the visual object
	protected float size;

	public SquibbleData(Vector3 _pos, float _size = 1) {
		pos = _pos;
		size = _size;

    	// create a default visual representation
    	GameObject cube = (GameObject)Instantiate(Resources.Load("BasicCube"));
    	setVisualRepresentation(cube);
	}

	public void setVisualRepresentation(GameObject g) {
		visualRepresentation = g;
		visualRepresentation.transform.position = pos;
		// ((BasicCube) visualRepresentation).setData (this); // TODO fix this, no casting

		// TODO abstract this
		// TODO once fade is complete, destroy SquibbleData
		g.GetComponent<BasicCube>().fade();
		// g.GetComponent<BasicCube>().setData (this);
		applyEffects();
	}

	// This method overwritten by child classes
	public void applyEffects() {

	}

	public void updatePosition(Vector3 _pos) {
		pos = _pos;
		visualRepresentation.transform.position = pos;
	}

	// TODO call this
	public void destroy() {
		// Object.Destroy (this);
		// manage this in LivingSongsController
	}
}
