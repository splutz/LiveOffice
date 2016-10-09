using System;
using System.Collections;
using System.Collections.Generic;

public class DijkstraAlgorithm {

  private List<Vertex> nodes;
  private List<Edge> edges;
  private HashSet<Vertex> settledNodes;
  private HashSet<Vertex> unSettledNodes;
  private Dictionary<Vertex, Vertex> predecessors;
  private Dictionary<Vertex, int> distance;

  public DijkstraAlgorithm(Graph graph) {
    // create a copy of the array so that we can operate on this array
    this.nodes = new List<Vertex>(graph.getVertexes());
    this.edges = new List<Edge>(graph.getEdges());
  }

  public void execute(Vertex source) {
    settledNodes = new HashSet<Vertex>();
    unSettledNodes = new HashSet<Vertex>();
	distance = new Dictionary<Vertex, int>();
	predecessors = new Dictionary<Vertex, Vertex>();
	distance.Add(source, 0);
    unSettledNodes.Add(source);
    while (unSettledNodes.Count > 0) {
      Vertex node = getMinimum(unSettledNodes);
      settledNodes.Add(node);
      unSettledNodes.Remove(node);
      findMinimalDistances(node);
    }
  }

	private void findMinimalDistances(Vertex node) {
		IList<Vertex> adjacentNodes = getNeighbors(node);
		foreach (Vertex target in adjacentNodes) {
			if (getShortestDistance(target) > getShortestDistance(node)
				+ getDistance(node, target)) {
				distance.Remove (target);
				distance.Add(target, getShortestDistance(node)
					+ getDistance(node, target));
				predecessors.Remove (target);
				predecessors.Add(target, node);
				unSettledNodes.Add(target);
			}
		}

	}

  private int getDistance(Vertex node, Vertex target) {
    foreach (Edge edge in edges) {
      if (edge.getSource().equals(node)
          && edge.getDestination().equals(target)) {
        return edge.getWeight();
      }
    }
		throw new SystemException (); // ("Should not happen");
  }

  public int cost(IList<Vertex> path) {
    if (path.Count == 0) return 0;
    int c = 0;
    for(int i = 0; i < path.Count - 1; i++) {
      c += getDistance(path[i], path[i + 1]);
    }
    return c;
  }

  private List<Vertex> getNeighbors(Vertex node) {
    List<Vertex> neighbors = new List<Vertex>();
    foreach (Edge edge in edges) {
      if (edge.getSource().equals(node)
          && !isSettled(edge.getDestination())) {
        neighbors.Add(edge.getDestination());
      }
    }
    return neighbors;
  }

  private Vertex getMinimum(HashSet<Vertex> vertexes) {
    Vertex minimum = null;
    foreach (Vertex vertex in vertexes) {
      if (minimum == null) {
        minimum = vertex;
      } else {
        if (getShortestDistance(vertex) < getShortestDistance(minimum)) {
          minimum = vertex;
        }
      }
    }
    return minimum;
  }

  private bool isSettled(Vertex vertex) {
    return settledNodes.Contains(vertex);
  }

  private int getShortestDistance(Vertex destination) {
		if (distance.ContainsKey (destination)) {
			return distance [destination];
		} else {
			return int.MaxValue;
		}
  }

  /*
   * This method returns the path from the source to the selected target and
   * NULL if no path exists
   */
  public IList<Vertex> getPath(Vertex target) {
    LinkedList<Vertex> path = new LinkedList<Vertex>();
    Vertex step = target;
    // check if a path exists
    if (predecessors[step] == null) {
      return null;
    }
	path.AddLast(step);
	while (predecessors.ContainsKey(step)) {
      step = predecessors[step];
	  path.AddLast(step);
    }
    // Put it into the correct order
	IList<Vertex> rev = new List<Vertex>();
	int count = path.Count;
	for (int i = 0; i < count; i++) {
		rev.Add (path.Last.Value);
		path.RemoveLast ();
	}
			
    return rev;
  }


} 

