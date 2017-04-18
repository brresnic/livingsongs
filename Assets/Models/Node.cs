//=======================================================================
// Ben Resnick, 2016
//=======================================================================


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Node {


	World world;

	public List<Edge> Outs;
		
	public Edge In;

	public int X { get; protected set; }
	public int Y { get; protected set; }
	public int Z { get; protected set; }
	public Vector3 Position;

	public Node( World world, int x, int y, int z, Edge _in = null, Edge _out = null) {
		this.X = x;
		this.Y = y;
		this.Z = z;
		this.In = _in;
		if (_out != null) {
			this.Outs.Add(_out);
		}
		this.Position = new Vector3 (x, y, z);
	}
}
