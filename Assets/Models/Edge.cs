//=======================================================================
// Ben Resnick, 2016
//=======================================================================


using UnityEngine;
using System.Collections;
using System;

public class Edge {

	World world;
	public Node Out;
	public Node In;

	public Edge( World world, Node Out, Node In ) {
		this.world = world;
		this.Out = Out;
		this.In = In;
	}
}
