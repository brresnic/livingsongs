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

		// load source
		source = Resources.Load("oyster4d") as TextAsset;
		Debug.Log (source);

		//initialize midi
		int bpm = 165;
		MidiFileContainer song = MidiFileLoader.Load (source.bytes); //midi song data
		seq = new MidiTrackSequencer (song.tracks[0], song.division, bpm); //midi sequencer

		// get start events
		foreach (MidiEvent e in seq.Start ()) {
			if (e.status == 144) { //note on event
				createSquibble (e);
			}
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
						if (e.status == 144) { //note on event
							createSquibble (e);
						}
					}
				}
			}
		}
	}

	public void createSquibble(MidiEvent e) {
		float normalizedNoteChange = (((float) e.data1) - 60);
     // Debug.Log(normalizedNoteChange);


		//Vector3 pos = new Vector3(normalizedNoteChange,normalizedNoteChange,1);
    Vector3 pos = generateCirclePosition(normalizedNoteChange);
		lsControl.queueNextSquibble (new SquibbleData (pos));

	}



   Vector3 generateCirclePosition(float n) {
      int numObjects = 10;
      Vector3 center = new Vector3(0,0,0);
      float ang = (n % 10)/10 * 180;
      float radius = 5;
           // Debug.Log("dot");
     // Debug.Log(ang);
      Vector3 pos;
      pos.z = center.z + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
      pos.x = center.x + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
      pos.y = center.y;
      Debug.Log(Mathf.Sin(ang * Mathf.Deg2Rad));
      Debug.Log(Mathf.Cos(ang * Mathf.Deg2Rad));

      return pos;
      //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center-pos);
      //Instantiate(prefab, pos, rot);

   }

}
