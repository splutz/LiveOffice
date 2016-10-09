using System;
using System.Collections;
using System.Collections.Generic;


public class Search {
	private IList<Vertex> nodes;

	public Search(IList<Vertex> nodes) {
    this.nodes = nodes;
  }

  public IList<Vertex> search(String search) {

		IList<Vertex> list = new List<Vertex>();
     foreach(Vertex node in nodes) {
       // TODO: Use better searching with aliases, partial matches etc.
       if(node.getName() == search) {
         list.Add(node);
       }
     }
     return list;
  }
}
