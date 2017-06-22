//=======================================================================
// Ben Resnick, 2017
//=======================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmfLite;

public class EchoSquibbleData : SquibbleData {

  private bool left; // if left, echo to the left, else right
	private int numEchos;
	private GameObject[] echos;

	public EchoSquibbleData(Vector3 _pos, bool _left, int _numEchos, float _size = 1) : base(_pos, _size)
  {
		left = _left;
		numEchos = _numEchos;
  }

  // this squibble has an echo effect
	public void applyEffects() {
    createEchos();
	}

	private void createEchos() {
    Vector3 echoPosition;
    for (int i = 1; i <= numEchos; i++) {
      if (left) {
        echoPosition = pos + new Vector3 (0, 0, (float).5 * i);
      }
      else {
        echoPosition = pos + new Vector3 (0, 0, (float)-.5 * i);
      }

      // TODO: create gameobject based on arbitrary parent visual representation
      GameObject cube = (GameObject)Instantiate(Resources.Load("BasicCube"));
      echos [i] = cube;
      cube.transform.position = echoPosition;
      cube.GetComponent<BasicCube> ().fade ();
    }
	}
}
