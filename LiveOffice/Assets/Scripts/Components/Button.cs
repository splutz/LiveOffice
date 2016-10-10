using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	private Vector3 origin;
	private float upAmount = 2.0f;
	private float speed = 15.0f;

	private Vector3 dnPos;
	private Vector3 upPos;
	private Vector3 currPos;

	void Start() {
		dnPos = transform.localPosition;
		upPos = transform.localPosition + Vector3.up * upAmount;
		currPos = dnPos;
	}

	void Update() {
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, currPos, speed * Time.deltaTime);
	}

	void OnMouseEnter() { currPos = upPos; }
	void OnMouseExit()  { currPos = dnPos; }
	void OnMouseDown() {
		Debug.Log ("clicked");

	}
}
