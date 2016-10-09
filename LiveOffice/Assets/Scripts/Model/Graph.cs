using System;
using System.Collections;
using System.Collections.Generic;

public class Graph {
  private IList<Vertex> vertexes;
  private IList<Edge> edges;

  public Graph(IList<Vertex> vertexes, IList<Edge> edges) {
    this.vertexes = vertexes;
    this.edges = edges;
  }

  public IList<Vertex> getVertexes() {
    return vertexes;
  }

  public IList<Edge> getEdges() {
    return edges;
  }
  
  
  
} 

