using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowGraph : MonoBehaviour {

	// Use this for initialization
	void Start () {
		loadGraphElements ();
	}

	void loadGraphElements() {

		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = new Vector3 (1, 1, 1);
		sphere.transform.parent = gameObject.transform;
		DrawLine(new Vector3 (0, 0, 0), new Vector3 (1, 1, 1),Color.blue);
		//Debug.DrawLine(new Vector3 (0, 0, 0), new Vector3 (1, 1, 1),Color.blue);
		print ("fuck this shit unity");
		Debug.LogWarning ("message unity");
	}

	void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
	{
		GameObject myLine = new GameObject();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetColors(color, color);
		lr.SetWidth(0.1f, 0.1f);
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
		GameObject.Destroy(myLine, duration);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
