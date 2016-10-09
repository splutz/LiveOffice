using System;

public class VertexMetadata {
  public String name;
  public String subtitle;
  public Position position;
  public Direction direction;
  public VertexMetadata(String name, String subtitle, Position position, Direction direction) {
    this.name = name;
    this.subtitle = subtitle;
    this.position = position;
    this.direction = direction;
  }
}

