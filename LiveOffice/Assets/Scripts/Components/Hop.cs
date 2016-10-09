using UnityEngine;
using System.Collections;

public class Hop : MonoBehaviour {

	// Update is called once per frame
	void Start () {
		StartCoroutine (Jump ());
	}

	private IEnumerator Jump() {

		GetComponent<Rigidbody>().AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);
		yield return new WaitForSeconds(1.5f);

		StartCoroutine (Jump ());
	}
}
