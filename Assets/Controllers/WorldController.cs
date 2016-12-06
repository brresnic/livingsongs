using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WorldController : MonoBehaviour {

	World world;
	Dictionary<Node, GameObject> nodeLookup;
	int renderedNodes;
	public Material nodeMaterial;
	public CameraController camera;

	// Use this for initialization
	void Start () {
		world = new World();
		nodeLookup = new Dictionary<Node, GameObject> ();

		// Initialize first node
		GameObject nodeGA = CreateGONode (world.nodes[0].X, world.nodes[0].Y, world.nodes[0].Z);
		nodeLookup.Add (world.nodes[0], nodeGA);
		renderedNodes = 1;

		// Get Reference to Camera
		// TODO: what is the best practice here?
		camera = Camera.main.GetComponent<CameraController>( );
	}

	// Update is called once per frame
	void Update () {

		// When user presses space, spawn nodes 
		if (Input.GetKeyDown ("space")) {
			spawnNodes ();
		}

		// When user presses 1, 2, or 3
		// choose one of the selected node's children 
		// and point the camera towards it
//		if (Input.GetKeyDown (KeyCode.Keypad0)) {
//
//		}
	}

	// create three new nodes 
	// in a sphere surrounding the currently selected node
	// Then, move the camera to the newly selected nodes
	private void spawnNodes() {
		// create data for three nodes, and then their visual representation
		world.spawnNodes();
		for (int i = renderedNodes; i < world.nodes.Count; i++) {
			GameObject ga = CreateGONode (world.nodes[i].X,world.nodes[i].Y,world.nodes[i].Z);
			nodeLookup.Add (world.nodes[i], ga);

			// create visual representations of edges
			if (world.nodes [i].In != null) {
				CreateGOEdge (world.nodes [i].In);
			}
		}
		Debug.Log (world.SelectedNode.Position);
		Debug.Log ("wc-camera");
		Debug.Log (camera);
		// set camera to look at the selected node
		camera.LookAt (world.SelectedNode.Position);

		// TODO: tie this increment to data layer (world)
		renderedNodes = renderedNodes + 3;
	}

	private GameObject CreateGONode (int x, int y, int z) {

		// create the game object
		//GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		GameObject go = Instantiate(Resources.Load("VisualObjects/NoisePlanet")) as GameObject;
		go.name = "Node_" + x + "_" + y + "_" + z;
		go.transform.position = new Vector3(x, y, z);

		// set the material
		// go.GetComponent<MeshRenderer>().material = nodeMaterial;

		// load the audio clip
		AudioSource audioSource = go.AddComponent<AudioSource>();
		audioSource.clip = Resources.Load("hornhit") as AudioClip;

		// set the audio's mixer
		AudioMixer mixer = Resources.Load("graphAudioMix") as AudioMixer;
		Debug.Log (mixer.FindMatchingGroups ("Master")[0]);
		audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups ("Master")[0]; 

		// play the audio
		audioSource.Play();

		return go;
	}

	private void CreateGOEdge (Edge e) {

		// create, rotate, and position the edge 
		GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		go.transform.position = new Vector3(e.In.X,e.In.Y,e.In.Z);
		go.transform.LookAt (new Vector3 (e.Out.X, e.Out.Y, e.Out.Z));
		go.transform.Rotate (90, 0, 0);
		go.transform.localScale = new Vector3 (0.01f,(e.In.Position - e.Out.Position).magnitude/2,0.01f); 
		go.transform.Translate(0,(e.In.Position - e.Out.Position).magnitude/2,0);

		// set the material
		go.GetComponent<MeshRenderer>().material = nodeMaterial;
	}
}
