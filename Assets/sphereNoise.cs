using UnityEngine;
using System.Collections;
//using LibNoise.Unity;
//using LibNoise.Unity.Generator;
//using LibNoise.Unity.Operator;

public class NoisySphere : MonoBehaviour {

//
//	private Mesh gameMesh;
//	Vector3[] vertices;
//	Vector3[] verticesN;
//	public float radius = 1f;
//	public RidgedMultifractal noise = new RidgedMultifractal();
//	public float frequency = 10f;
//	public float noisemod = 1f;
//	private MeshCollider meshCollider;
//
//
//	void Start () {
//		gameMesh = GetComponent<MeshFilter>().mesh;
//		meshCollider = GetComponent<MeshCollider>();
//		Vector3[] vertices = gameMesh.vertices;
//		Vector3[] verticesN = gameMesh.vertices;
//		noise.Frequency = frequency;
//
//
//		for (int i = 0; i < vertices.Length; i++) 
//		{
//			verticesN[i] = (vertices[i].normalized * (radius + (float)noise.GetValue(verticesN[i].normalized)*noisemod));
//		}
//		gameMesh.vertices = verticesN;
//		gameMesh.RecalculateNormals();
//		gameMesh.RecalculateBounds();
//		meshCollider.sharedMesh = gameMesh;
//	}
}