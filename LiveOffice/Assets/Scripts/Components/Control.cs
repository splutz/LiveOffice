using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		float xAxisValue = Input.GetAxis("Horizontal");
		float zAxisValue = Input.GetAxis("Vertical");
		Camera.main.transform.Translate(new Vector3(xAxisValue, zAxisValue, 0.0f));
	}
}
