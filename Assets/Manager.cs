using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.Portrait;
		Input.gyro.enabled = true;
		Input.compass.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
