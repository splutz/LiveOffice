//using System;
//using System.Collections;
//using System.Collections.Generic;
//
//public class TestDijkstraAlgorithm {
//
//  private IList<Vertex> nodes;
//  private IList<Edge> edges;
//
//  public static void main(String[] args) {
//    new TestDijkstraAlgorithm().testVendor();
//  }
//  public void testVendor() {
//    nodes = new ArrayList<Vertex>();
//    edges = new ArrayList<Edge>();
//    int i = 0;
//    nodes.add(new Vertex("Node_" + i++, new VertexMetadata("Entrance", null, new Position(0,0), Direction.UNSPECIFIED))); // 0
//    nodes.add(new Vertex("Node_" + i++, new VertexMetadata("Innovation Lab", "West Entrance", new Position(2,2), Direction.EAST))); // 1
//    nodes.add(new Vertex("Node_" + i++, new VertexMetadata("Hopper", "East Entrance", new Position(2,6), Direction.WEST))); // 2
//    nodes.add(new Vertex("Node_" + i++, new VertexMetadata("Hamilton", "East Entrance", new Position(2,10), Direction.WEST))); // 3
//    nodes.add(new Vertex("Node_" + i++, new VertexMetadata("Hub", "Southeast Entrance", new Position(2,20), Direction.NORTHWEST))); // 4
//    nodes.add(new Vertex("Node_" + i++, new VertexMetadata("Skyler Lutz's Desk", null, new Position(10,20), Direction.SOUTH))); // 5
//    nodes.add(new Vertex("Node_" + i++, new VertexMetadata("Vendor", null, new Position(5,30), Direction.SOUTH))); // 6
//    nodes.add(new Vertex("Node_" + i++, new VertexMetadata("Edison", "East Entrance", new Position(7,31), Direction.WEST))); // 7
//    nodes.add(new Vertex("Node_" + i++, new VertexMetadata("Edison", "West Entrance", new Position(4,31), Direction.EAST))); // 8
//    nodes.add(new Vertex("Node_" + i++, new VertexMetadata("Library", null, new Position(5,40), Direction.NORTH))); // 9
//    nodes.add(new Vertex("Node_" + i++, new VertexMetadata("Gaston's Candle", null, new Position(6,45), Direction.NORTH))); // 10
//
//    int j = 0;
//    addLane("Edge_" + j++, 0, 1, 3);
//    addLane("Edge_" + j++, 1, 2, 3);
//    addLane("Edge_" + j++, 2, 3, 3);
//    addLane("Edge_" + j++, 3, 4, 3);
//    addLane("Edge_" + j++, 3, 5, 5);
//    addLane("Edge_" + j++, 4, 6, 3);
//
//    Vertex source = nodes.get(0); // entrance
//    Graph graph = new Graph(nodes, edges);
//    Search search = new Search(nodes);
//    List<Vertex> results = search.search("Vendor");
//    if (results == null) {
//      System.out.println("no results :(");
//      return;
//    }
//    int bestCost = Integer.MAX_VALUE;
//    List<Vertex> bestPath = null;
//    for (Vertex result : results) {
//      DijkstraAlgorithm dijkstra = new DijkstraAlgorithm(graph);
//      dijkstra.execute(source);
//      List<Vertex> path = dijkstra.getPath(result);
//      int cost = dijkstra.cost(path);
//      if (cost < bestCost) {
//        bestCost = cost;
//        bestPath = path;
//      }
//    }
//    if (bestPath == null) {
//      System.out.println("no path :(");
//      return;
//    }
//
//    System.out.println("Directions: ");
//    for (Vertex vertex : bestPath) {
//      System.out.println("Go to " + vertex);
//    }
//    System.out.println("Finally, face " + (bestPath.get(bestPath.size() - 1).getMetadata().direction));
//    
//  }
//
//  private void addLane(String laneId, int sourceLocNo, int destLocNo,
//      int duration) {
//    Edge lane = new Edge(laneId,nodes.get(sourceLocNo), nodes.get(destLocNo), duration);
//    edges.add(lane);
//  }
//} 
//
