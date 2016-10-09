using System;
using System.Collections;
using System.Collections.Generic;

public class Location {
  private IList<Vertex> nodes;

  public Location(IList<Vertex> nodes) {
    this.nodes = nodes;
  }

  public Vertex locate(Position position) {

    float bestDistance = float.MaxValue;
    Vertex best = null;
    foreach(Vertex node in nodes) {
      VertexMetadata meta = node.getMetadata();
      float distance = (position.x - meta.position.x) * (position.x - meta.position.x) + (position.y - meta.position.y) * (position.y - meta.position.y);
      if(distance < bestDistance) {
        bestDistance = distance;
        best = node;
      }
    }
    return best;
  }
}
