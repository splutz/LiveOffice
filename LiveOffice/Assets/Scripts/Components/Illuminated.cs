using UnityEngine;
using System.Collections;

public class Illuminated : MonoBehaviour {

	public Light light;


	void Update() {
		if (isOn) {
			light.intensity = 8.0f;
		} else {
			light.intensity = 0.0f;
		}
	}

	private bool isOn = false;
	void OnMouseEnter() { isOn = true; }
	void OnMouseExit()  { isOn = false; }
}
