//=======================================================================
// Ben Resnick, 2017
//=======================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingSongsController : MonoBehaviour {


	private Queue<SquibbleData> nextSquibbleDatas;
	private List<SquibbleData> activeSquibbleDatas;
	private LivingSongController currentSong;

	// Use this for initialization
	void Start () {
		nextSquibbleDatas = new Queue<SquibbleData>();
		activeSquibbleDatas = new List<SquibbleData>();

		//instantiate the default song

		currentSong = gameObject.AddComponent<LivingSongController> ();
		currentSong.setInitialParams (this);
		currentSong.play();
	}

	// Update is called once per frame
	void Update () {

		while(nextSquibbleDatas.Count > 0) {
			SquibbleData next = nextSquibbleDatas.Dequeue();

			instantiateSquibble(next); // Create a visual representation of the next Squibble
			trackSquibble(next); // Track squibble data in order to update as appropriate
		}
	}

	public void queueNextSquibble(SquibbleData d) {
		nextSquibbleDatas.Enqueue(d);
	}

	private void instantiateSquibble (SquibbleData d) {
		// TODO: create the corresponding GO as appropriate

		//PLACEHOLDER: generates a cube
		GameObject cube = (GameObject)Instantiate(Resources.Load("BasicCube"));
		d.setVisualRepresentation(cube);
	}

	private void trackSquibble (SquibbleData d) {

		// Store the SData in activeSDatas
		activeSquibbleDatas.Add(d);

		// TODO: perform additional tracking based on Squibble type
	}
}
