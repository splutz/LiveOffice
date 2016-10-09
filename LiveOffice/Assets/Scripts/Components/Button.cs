using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public AnimationCurve ac;
	private float duration = 0.08f;
	private float jump = 0.05f;
	private Vector3 origin;
//	void Start() {
//		origin = transform.position;
//	}
//	// Use this for initialization
//	void OnMouseEnter() {
//		Vector3 beckoned = new Vector3 (origin.x, origin.y + jump, origin.z);
//		StartCoroutine (move (origin, beckoned));
//	}
//	void OnMouseExit() {
//		Vector3 resigned = new Vector3 (origin.x, origin.y - jump, origin.z);
//		StartCoroutine (move (origin, resigned));
//	}
//
//	void OnMouseDown() {
//		Debug.Log ("Clicked");
//	}
//
//	private IEnumerator move(Vector3 start, Vector3 end) {
//		float timer = 0.0f;
//		while (timer <= duration) {
//			transform.position = Vector3.Lerp (start, end, ac.Evaluate (timer / duration));
//			timer += Time.deltaTime;
//			yield return null;
//		}
//	}

}
