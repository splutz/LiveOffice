using UnityEngine;
using System.Collections;

public class Shatter : MonoBehaviour {

	// Use this for initialization
	void OnMouseDown() {

		BoxCollider collider = GetComponent<BoxCollider> ();
		collider.enabled = false;
		StartCoroutine (die ());
	}
	private IEnumerator die() {
		yield return new WaitForSeconds (1.0f);
		Destroy (gameObject);
	}
}
