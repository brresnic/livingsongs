//=======================================================================
// Ben Resnick, 2016
// 
// Inspired by Martin "quill18" Glaude 2015.
// http://quill18.com
//=======================================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World {

	public List<Node> nodes;
	Node selectedNode;

	public Node SelectedNode {
		get {
			return selectedNode;
		}
	}

	public World() {

		nodes = new List<Node>();
		nodes.Add(new Node(this,0,0,0));

		//accessing an element
		selectedNode = nodes[0];

		Debug.Log ("World created");
	}

	public void spawnNodes(int num = 3) {
		for (int i = 0; i < num; i++) {

			// calculate node position
			Vector3 randPos = Random.onUnitSphere;
			int x = selectedNode.X + Mathf.RoundToInt (randPos.x * 10);
			int y = selectedNode.Y + Mathf.RoundToInt (randPos.y * 10);
			int z = selectedNode.Z + Mathf.RoundToInt (randPos.z * 10);

			// create the node 
			Node newNode = new Node (this,x,y,z);
			nodes.Add (newNode);

			//create the edge
			Edge newEdge = new Edge (this, selectedNode, newNode);
			newNode.In = newEdge;


			if (i == num - 1)
				selectedNode = newNode;
		}
	}
		
	public Vector3 position() {
		return new Vector3 (selectedNode.X, selectedNode.Y, selectedNode.Z);
	}

}