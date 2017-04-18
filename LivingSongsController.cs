//=======================================================================
// Ben Resnick, 2016
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
		nextSquibbleDatas = new Queue();
		activeSquibbleDatas = new List();

		// TODO: read in the default midi file
		

		// Create a song based on the midi 
		// currentSong = new LivingSong(this, midi);
		// play the current song
		// currentSong.play();

	}

	// Update is called once per frame
	void Update () {
		
		while(nextSquibbleDatas.count > 0) {
			SquibbleData next = nextSquibbleDatas.Dequeue();

			instantiateSquibble(next); // Create a visual representation of the next Squibble
			trackSquibble(next); // Track squibble data in order to update as appropriate
		}
	}

	public void queueNextSquibble(SquibbleData s) {
		nextSquibbleDatas.Enqueue(s);
	}

	private void instantiateSquibble () {
		// TODO: create the corresponding GO as appropriate

	 	// TODO: give the SquibbleData a reference to the GO
	}

	private void trackSquibble () {
		
		// Store the SData in activeSDatas
		activeSquibbleDatas.Add(SquibbleData);

		// TODO: perform additional tracking based on Squibble type
	}
}