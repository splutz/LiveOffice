using UnityEngine;
using System;
using System.Collections;

public class Look : MonoBehaviour {
	
	private float duration = 1.0f;
	public AnimationCurve ac;

	private Quaternion original;

	private bool collided = false;
	private bool found = false;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "MainCamera") {
			
			StartCoroutine (find ());
			collided = true;
		}
	}
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "MainCamera") {
			collided = false;
			found = false;


			StartCoroutine (normalize (transform.rotation, original));
		}
	}

	void Update () {
		
		if (collided && found) {
			Vector3 position = Camera.main.transform.position;
			float dist = Vector3.Distance (position, transform.position);
			Vector3 delta = position - transform.position; 

			float xangle = Mathf.Asin (delta.x / dist) * 180.0f / (float)Mathf.PI * 0.2f;
			float zangle = -Mathf.Asin (delta.z / dist) * 180.0f / (float)Mathf.PI * 0.2f;

			transform.localRotation = Quaternion.Euler (new Vector3 (xangle, 0, zangle));
			Debug.Log (transform.localRotation.eulerAngles);
			Debug.Log (original.eulerAngles);
		} else {
			original = transform.rotation;
		}
	}

	private IEnumerator find() {
		float timer = 0.0f;

		while (timer <= duration) {
			Vector3 position = Camera.main.transform.position;
			float dist = Vector3.Distance (position, transform.position);
			Vector3 delta = position - transform.position; 

			float xangle = Mathf.Asin (delta.x / dist) * 180.0f / (float)Mathf.PI * 0.2f;
			float zangle = -Mathf.Asin (delta.z / dist) * 180.0f / (float)Mathf.PI * 0.2f;

			transform.localRotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (new Vector3 (xangle, 0, zangle)), ac.Evaluate (timer / duration));
			timer += Time.deltaTime;
			yield return null;
		}
		found = true;
	}

	private IEnumerator normalize(Quaternion start, Quaternion end) {
		float timer = 0.0f;
	
		while (timer <= duration) {
			transform.localRotation = Quaternion.Lerp (start, end, ac.Evaluate (timer / duration));
			timer += Time.deltaTime;
			yield return null;
		}
	}

}
