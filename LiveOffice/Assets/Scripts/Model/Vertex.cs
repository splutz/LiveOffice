using System;

public class Vertex {
  private String id;
  private VertexMetadata metadata;
  
  public Vertex(String id, VertexMetadata metadata) {
    this.id = id;
    this.metadata = metadata;
  }
  public String getId() {
    return id;
  }
  public String getName() {
    return metadata.name;
  }
  public VertexMetadata getMetadata() {
    return metadata;
  }

  public bool equals(Object obj) {
    if (this == obj)
      return true;
    if (obj == null)
      return false;
    Vertex other = (Vertex) obj;
		return Object.ReferenceEquals (this, other);
  }
		
  public String toString() {
    return metadata.name;
  }
  
} 

