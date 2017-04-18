using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCube : MonoBehaviour {

	Animator anim;
	SquibbleData data;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool("fading", false);
	}

	// Update is called once per frame
	void Update () {
		//		if (fade) {
		//			anim.SetBool("open", true);
		//		}
	}

	public void fade() {
		// Debug.Log ("switch state");
		// anim.SetBool("fading", true);
	}

	public void destroy() {
		// Debug.Log ("destroy");
		if (data != null) {
			data.destroy ();
		}
		Object.Destroy (gameObject);
	}

	public void setData(SquibbleData d) {
		data = d;
	}
}
