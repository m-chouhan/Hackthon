using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

	public GameObject edgePrefab;
	public GameObject nodePrefab;
	class GraphNode : MonoBehaviour {

		int ID;
		Vector3 position = new Vector3();
		bool visited = false;
		List<GraphNode> nodeList = new List<GraphNode>();
		GameObject nodeObject;
		public GraphNode(Vector3 position) {
			this.position = position;
		}

		//fetch information from server
		void Update() {}

		public GraphNode EdgeTo(GraphNode target) {
			nodeList.Add(target);
			return target;
		}

		public Vector3 getPosition() { return position;}
		public void setPosition(Vector3 position) {	this.position = position; }
		public void setVisited(bool visited) { this.visited = visited; } 
		public bool isVisited() { return visited; }
		public List<GraphNode> getNodeList() { return nodeList; }
		public GameObject getObject() { return nodeObject;	}
		public void setGameObject(GameObject myObject) { this.nodeObject = myObject; }

	}

	void InstantiateGraph(GraphNode node,GameObject parent) {

		if (node.isVisited()) return;

		GameObject sphere = Instantiate(nodePrefab);
		sphere.transform.position = node.getPosition();
		sphere.transform.parent = parent.transform;
		node.setGameObject(sphere);
		//sphere.transform.parent = gameObject.transform;
		node.setVisited(true);
		foreach (var nextNode in node.getNodeList()) {
			DrawLine (node.getPosition(),nextNode.getPosition());
			InstantiateGraph(nextNode,parent);
		}
	}

	void DrawLine(Vector3 start,Vector3 end) {
		GameObject myLine = Instantiate (edgePrefab);
		myLine.transform.position = start;
		LineRenderer lr = myLine.GetComponent<LineRenderer> ();
		lr.startWidth = 0.1f;
		lr.endWidth = 0.1f;	
		lr.SetPosition (0, start);
		lr.SetPosition (1, end);
	}

	// Use this for initialization
	void Start () {

		edgePrefab = Instantiate(Resources.Load("Line")) as GameObject;
		nodePrefab = Instantiate (Resources.Load ("Sphere")) as GameObject;
		GraphNode node1 = new GraphNode (new Vector3(0,0,0));
		GraphNode node2 = new GraphNode (new Vector3(0,0,10));
		node1.EdgeTo(node2).EdgeTo(new GraphNode(new Vector3(5,5,0)));
		InstantiateGraph(node1,gameObject);

	}
	void someFun() {

		//yield return new WaitForSeconds(duration);
		//GameObject.Destroy (myLine);

		//		GL.PushMatrix();
		//		GL.LoadOrtho();
		//		GL.Begin(GL.LINES);
		//
		//		GL.Color(Color.blue);
		//		GL.Vertex(start);
		//		GL.Vertex(end);
		//		GL.End();
		//		GL.PopMatrix();
	}	
	// Update is called once per frame
	void Update () {
		
	}
}
