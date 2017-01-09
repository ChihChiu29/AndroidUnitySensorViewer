using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiLogger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onGui() {
		GUILayout.BeginArea(new Rect(10, 10, 100, 100));
		GUILayout.Button("Click me");
		GUILayout.Button("Or me");
		GUILayout.EndArea();

		GUILayout.Label("\n\n C O M P A S S");
		GUILayout.Label("Input.compass.enabled <<<===>>> " + Input.
			compass.enabled.ToString());
		GUILayout.Label("Input.compass.headingAccuracy <<<===>>> " +
			Input.compass.headingAccuracy.ToString());
		GUILayout.Label("Input.compass.magneticHeading <<<===>>> " +
			Input.compass.magneticHeading.ToString());
		GUILayout.Label("Input.compass.rawVector <<<===>>> " + Input.
			compass.rawVector.ToString());
		GUILayout.Label("Input.compass.timestamp <<<===>>> " + Input.
			compass.timestamp.ToString());
		GUILayout.Label("Input.compass.trueHeading <<<===>>> " + Input.
			compass.trueHeading.ToString());
	}
}
