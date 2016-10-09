using UnityEngine;
using System.Collections;

public class AnnotationScript : MonoBehaviour {
	
	// Update is called once per frame
	private float radius = 10.0f;
	private Transform original;
	public AnimationCurve ac;
	void Update () {

		float distance = Vector3.Distance (transform.position, Camera.main.transform.position);
		if (original == null && distance < radius) {
			Debug.Log ("In Range");
			// we're in range, start the co-routine
			original = transform;
			StartCoroutine (present (ac, 0.5f));
		} 
		if (complete) {
			transform.position = Camera.main.transform.position;
		}
	}

	private bool complete = false;
	private IEnumerator present(AnimationCurve ac, float time) {
		float timer = 0.0f;
		while (timer <= time) {
			transform.position = Vector3.Lerp (original.position, Camera.main.transform.position, ac.Evaluate (timer / time));
			timer += Time.deltaTime;
			yield return null;
		}
		complete = true;
	}
}
