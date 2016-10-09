using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneController : MonoBehaviour {
	
	private IList<Vertex> nodes;
	private IList<Edge> edges;

	// prefabs
	public GameObject site;
	public GameObject right_footprint;
	public GameObject left_footprint;
	public GameObject arrow;

	// PathFinding GameObjects
	private List<GameObject> sites = new List<GameObject>();
	private List<GameObject> prints = new List<GameObject>();

	private float padding = 10.0f; // padding between footprints
	private float sightline = 10.0f;

	// Use this for initialization
	void Start () {

		nodes = new List<Vertex>();
		edges = new List<Edge>();

		int i = 0;
		// sites
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Bathroom", null, new Position(-59.5f,17.5f), Direction.SOUTH))); // 0
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Mother's Lounge", null, new Position(-71.56f,6.96f), Direction.EAST))); // 1
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Phone 1", null, new Position(39.52f,-23.6f), Direction.SOUTH))); // 2
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Phone 2", null, new Position(73.7f,-23.6f), Direction.SOUTH))); // 3
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Phone 3", null, new Position(152.2f,-23.6f), Direction.SOUTH))); // 4
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Innovation Lab", "North Entrance", new Position(395.8f,-23.6f), Direction.SOUTH))); // 5
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Innovation Lab", "West Entrance", new Position(604.0f,162.9f), Direction.EAST))); // 6
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Ping Pong", null, new Position(-58.3f,-119.3f), Direction.EAST))); // 7
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Hopper", null, new Position(572.5f,-185.2f), Direction.WEST))); // 8
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Wright", null, new Position(572.5f,-320.6f), Direction.WEST))); // 9
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("da Vinci", "East Entrance", new Position(572.5f,-500.7f), Direction.WEST))); // 10

		// desks
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Ethan Le", new Position(-3.775f,-141.525f), Direction.NORTH))); // 11
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Michael Otmanski", new Position(54.225f,-141.525f), Direction.NORTH))); // 12
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Sujan Kanna", new Position(112.225f,-141.525f), Direction.NORTH))); // 13
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Paige Weldon", new Position(170.225f,-141.525f), Direction.NORTH))); // 14

		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Nikhil Bharadwaj", new Position(287.225f,-141.525f), Direction.NORTH))); // 15
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Andrea Miller", new Position(345.225f,-141.525f), Direction.NORTH))); // 16
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Kate Frydyk", new Position(403.225f,-141.525f), Direction.NORTH))); // 17
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "???", new Position(461.225f,-141.525f), Direction.NORTH))); // 18

		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "???", new Position(-3.775f,-273.525f), Direction.SOUTH))); // 19
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Pat Smolen", new Position(54.225f,-273.525f), Direction.SOUTH))); // 20
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Scott Radford", new Position(112.225f,-273.525f), Direction.SOUTH))); // 21
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Skyler Lutz", new Position(170.225f,-273.525f), Direction.SOUTH))); // 22

		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Praneet Saghal", new Position(287.225f,-273.525f), Direction.SOUTH))); // 23
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Chris Pinski", new Position(345.225f,-273.525f), Direction.SOUTH))); // 24
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Eric Johnsen", new Position(403.225f,-273.525f), Direction.SOUTH))); // 25
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Desk", "Mohammad Wahid", new Position(461.225f,-273.525f), Direction.SOUTH))); // 26

		// internal nodes
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("pass", null, new Position(-16.2f,-56.9f), Direction.UNSPECIFIED))); // 27 -- in front of ping pong room
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("pass", null, new Position(604f,-30.6f), Direction.UNSPECIFIED))); // 28 -- innovation corner
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("pass", null, new Position(572.5f,-57.1f), Direction.UNSPECIFIED))); // 29 -- innovation corner 2
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("pass", null, new Position(572.5f,-141.525f), Direction.UNSPECIFIED))); // 30 -- deere pod desk corner
		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("pass", null, new Position(572.5f,-273.525f), Direction.UNSPECIFIED))); // 31 -- deere pod desk corner 2

		int j = 0;
		addLane("Edge_" + j++, 0, 27);
		addLane("Edge_" + j++, 1, 27);
		addLane("Edge_" + j++, 2, 27);
		addLane("Edge_" + j++, 7, 27);
		addLane("Edge_" + j++, 2, 3);
		addLane("Edge_" + j++, 3, 4);
		addLane("Edge_" + j++, 4, 5);
		addLane("Edge_" + j++, 5, 28);
		addLane("Edge_" + j++, 5, 29);
		addLane("Edge_" + j++, 28, 29);
		addLane("Edge_" + j++, 28, 6);
		addLane("Edge_" + j++, 29, 30);
		addLane("Edge_" + j++, 30, 8);
		addLane("Edge_" + j++, 8, 31);
		addLane("Edge_" + j++, 31, 9);
		addLane("Edge_" + j++, 9, 10);

		addLane("Edge_" + j++, 31, 26);
		addLane("Edge_" + j++, 26, 25);
		addLane("Edge_" + j++, 25, 24);
		addLane("Edge_" + j++, 24, 23);

		addLane("Edge_" + j++, 23, 22); // praneet to skyler

		addLane("Edge_" + j++, 22, 21);
		addLane("Edge_" + j++, 21, 20);
		addLane("Edge_" + j++, 20, 19);

		addLane("Edge_" + j++, 30, 18);
		addLane("Edge_" + j++, 18, 17);
		addLane("Edge_" + j++, 17, 16);
		addLane("Edge_" + j++, 16, 15);
		addLane("Edge_" + j++, 15, 14);
		addLane("Edge_" + j++, 14, 13);
		addLane("Edge_" + j++, 13, 12);
		addLane("Edge_" + j++, 12, 11);

		addLane("Edge_" + j++, 11, 7);


		addLane("Edge_" + j++, 5, 16);
		addLane("Edge_" + j++, 5, 17);
		addLane("Edge_" + j++, 5, 18);

		addLane("Edge_" + j++, 2, 11);
		addLane("Edge_" + j++, 2, 12);
		addLane("Edge_" + j++, 2, 13);

		addLane("Edge_" + j++, 3, 11);
		addLane("Edge_" + j++, 3, 12);
		addLane("Edge_" + j++, 3, 13);
//
//
//		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Entrance", null, new Position(2.0f,-4.0f), Direction.NORTH))); // 0
//		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Skyler", null, new Position(2.5f,2.3f), Direction.EAST))); // 1
//		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Coffee Machine", null, new Position(-3.5f,1.8f), Direction.NORTH))); // 2
//		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("Hopper", "East Entrance", new Position(2.0f,-1.0f), Direction.WEST))); // 3
//		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("DaVinci", "East Entrance", new Position(2.0f,0.75f), Direction.WEST))); // 4
//		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("DaVinci", "West Entrance", new Position(-2.0f,0.75f), Direction.EAST))); // 5
//
//		// internal nodes
//		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("pass", null, new Position(-2.4f,-3.4f), Direction.UNSPECIFIED))); // 6
//		nodes.Add(new Vertex("Node_" + i++, new VertexMetadata("pass", null, new Position(2.0f,2.5f), Direction.UNSPECIFIED))); // 7
//
//		int j = 0;
//		addLane("Edge_" + j++, 0, 6, 3);
//		addLane("Edge_" + j++, 0, 3, 3);
//		addLane("Edge_" + j++, 3, 4, 3);
//		addLane("Edge_" + j++, 4, 7, 3);
//		addLane("Edge_" + j++, 7, 1, 1);
//		addLane("Edge_" + j++, 2, 7, 1);
//		addLane("Edge_" + j++, 2, 5, 3);
//		addLane("Edge_" + j++, 5, 6, 3);
//


	}

	private void addLane(String laneId, int sourceLocNo, int destLocNo) {
		Vertex v1 = nodes [sourceLocNo];
		Vertex v2 = nodes [destLocNo];
		Vector2 v1pos = new Vector2 (v1.getMetadata ().position.x, v1.getMetadata ().position.y);
		Vector2 v2pos = new Vector2 (v2.getMetadata ().position.x, v2.getMetadata ().position.y);
		int duration = (int)Math.Abs ((double)Vector2.Distance (v1pos, v2pos));

		Edge lane = new Edge(laneId,v1, v2, duration);
		edges.Add(lane);
		Edge lane2 = new Edge(laneId + "_r",v2, v1, duration);
		edges.Add(lane2);
	}
	/*
	public string url = "http://localhost";
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
	*/

	public void Update() {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Starting pathfind...");
			clearPath ();
			find ();


		}
		if (Input.GetMouseButtonDown (1)) {
			/*
			WWW www = new WWW(url);
			StartCoroutine(WaitForRequest(www));
			*/
//			clearPath ();

		}

		// only render footprints we're close enough to see.
		foreach (GameObject footprint in prints) {
//			footprint.GetComponent<Renderer> ().enabled = Vector3.Distance (footprint.transform.position, Camera.main.transform.position) < sightline;
		}
	}

	private void clearPath() {
		foreach (GameObject site in sites) {
			Destroy (site);
		}
		foreach (GameObject footprint in prints) {
			Destroy (footprint);
		}
		sites.Clear ();
		prints.Clear ();
	}

	private void find() {
		
		Vertex source = nodes[2]; // phone 1
		Graph graph = new Graph(nodes, edges);
		Search search = new Search(nodes);
		IList<Vertex> results = search.search("da Vinci");
		if (results == null) {
			Debug.Log("no results :(");
			return;
		}
		int bestCost = int.MaxValue;
		IList<Vertex> bestPath = null;
		foreach (Vertex result in results) {
			DijkstraAlgorithm dijkstra = new DijkstraAlgorithm(graph);
			dijkstra.execute(source);
			IList<Vertex> path = dijkstra.getPath(result);
			int cost = dijkstra.cost(path);
			if (cost < bestCost) {
				bestCost = cost;
				bestPath = path;
			}
		}
		if (bestPath == null) {
			Debug.Log("no path :(");
			return;
		}


		Debug.Log("Cost: " + bestCost + ". Directions: ");
		// draw arrows for each node
		if (bestPath.Count > 0) {
			for (int i = 0; i < bestPath.Count - 1; i++) {
				VertexMetadata curr = bestPath [i].getMetadata ();
				VertexMetadata next = bestPath [i + 1].getMetadata ();
				Debug.Log ("Go to " + next.name);

				float distance = Vector3.Distance (new Vector3 (curr.position.x, 0, curr.position.y), new Vector3 (next.position.x, 0, next.position.y));
				float xdelta = Vector3.Distance (new Vector3 (curr.position.x, 0, 0), new Vector3 (next.position.x, 0, 0));
				float angle = -Mathf.Asin (xdelta / distance) * (float)180.0f / (float)Math.PI;
				Vector3 rotation = new Vector3 (0.0f, angle, 0.0f);

				GameObject obj = (GameObject)Instantiate (arrow, new Vector3 (curr.position.x, 1.5f, curr.position.y), Quaternion.Euler (rotation));
				sites.Add (obj);
			}
		}

		// draw footprints
		if (bestPath.Count > 0) {
			for (int i = 0; i < bestPath.Count - 1; i++) {
				VertexMetadata curr = bestPath [i].getMetadata ();
				VertexMetadata next = bestPath [i + 1].getMetadata ();
				float distance = Vector3.Distance (new Vector3 (curr.position.x, 0, curr.position.y), new Vector3 (next.position.x, 0, next.position.y));
				float footHeight = left_footprint.GetComponent<Renderer> ().bounds.size.z;

				int numFeet = (int)Mathf.Floor (distance / (footHeight + padding)) * 2;
				Debug.Log ("Let's draw " + numFeet + " footprints on the floor.");

				for (int f = 0; f < numFeet; f++) {
					float x = Mathf.Lerp (curr.position.x, next.position.x, (float)f / (float)numFeet);
					float z = Mathf.Lerp (curr.position.y, next.position.y, (float)f / (float)numFeet);
					Vector3 position = new Vector3 (x, 1.0f, z);

					float xdelta = Vector3.Distance (new Vector3 (curr.position.x, 0, 0), new Vector3 (next.position.x, 0, 0));
					float angle = -Mathf.Asin (xdelta / distance) * (float)180.0f / (float)Math.PI;
					Vector3 rotation = new Vector3 (0.0f, angle, 0.0f);
					GameObject print = null;
					if (f % 2 == 0) {
						print = (GameObject)Instantiate (left_footprint, position, Quaternion.Euler (rotation));
					} else {
						print = (GameObject)Instantiate (right_footprint, position, Quaternion.Euler (rotation));
					}
					prints.Add (print);
				}
			}
		}
		Debug.Log("Finally, face " + (bestPath[bestPath.Count - 1].getMetadata().direction));
	}
}
