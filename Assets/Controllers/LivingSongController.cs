//=======================================================================
// Ben Resnick, 2017
//=======================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmfLite;

//TODO make this a generic class or interface, support multiple songs
public class LivingSongController : MonoBehaviour {

	// private midi
	// private sequencer
	private LivingSongsController lsControl;
	private MidiTrackSequencer seq; 
	private TextAsset source;
	private bool paramsSet;

	void start() {
		paramsSet = false;
	}

	public void setInitialParams (LivingSongsController l) {

		//get reference to parent controller
		lsControl = l;

		//TODO generate this data via midi
		lsControl.queueNextSquibble (new SquibbleData (new Vector3(1,1,1)));
		lsControl.queueNextSquibble (new SquibbleData (new Vector3(2,2,1)));
		lsControl.queueNextSquibble (new SquibbleData (new Vector3(3,3,1)));

		// load source
		source = Resources.Load("miditest") as TextAsset;
		Debug.Log (source);


		//initialize midi
		int bpm = 120;
		MidiFileContainer song = MidiFileLoader.Load (source.bytes); //midi song data
		seq = new MidiTrackSequencer (song.tracks[0], song.division, bpm); //midi sequencer

		// get start events
		foreach (MidiEvent e in seq.Start ()) {
			// Do something with a MidiEvent.
			Debug.Log (e);
		}

		paramsSet = true;
	}
	

	public void play() {
		// Start playing the midi
	}
		
	void Update() {
		if (paramsSet) {
			if (seq.Playing) {

				// returns a set of midi events which occurred between 
				// the previous frame and the current one
				List<MidiEvent> events = seq.Advance (Time.deltaTime);
				if (events != null) {
					foreach (MidiEvent e in events) {
					
						// Do something with a MidiEvent.
						Debug.Log (e);
					}
				}
			}
		}
	}

	public void createSquibble() {
		// Squibble s = new Squibble(params);
		// lsControl.queueNextSquibble(s);
	}
}
