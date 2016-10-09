using UnityEngine;
using System.Collections;

public class SpawnMenu : MonoBehaviour {

	private float duration = 1.0f;
	public GameObject menu;
	public AnimationCurve ac;
	void OnMouseDown() {
		Debug.Log ("mouse down!");
		BoxCollider collider = GetComponent<BoxCollider> ();
		collider.enabled = false;
		menu = (GameObject)Instantiate (menu, new Vector3 (0.0f, -0.0f, 0.0f), Quaternion.Euler (Vector3.up));
		menu.transform.position = transform.position + new Vector3 (0.0f, -2.5f, 0.0f);

		StartCoroutine (move (menu.transform.position, new Vector3(1.8f, 1.8f, -1.12f), menu.transform.rotation, Quaternion.Euler(new Vector3(-90.0f, 0, -90.0f))));
	}

	private IEnumerator move(Vector3 s, Vector3 e, Quaternion start, Quaternion end) {
		float timer = 0.0f;

		while (timer <= duration) {
			menu.transform.position = Vector3.Lerp (s, e, ac.Evaluate (timer / duration));
			menu.transform.rotation = Quaternion.Lerp (start, end, ac.Evaluate (timer / duration));
			timer += Time.deltaTime;
			yield return null;
		}
	}
}
