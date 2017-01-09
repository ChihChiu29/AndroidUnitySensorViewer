using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiLogger : MonoBehaviour {

	public Vector2 scrollPosition;
	private Vector2 _v1, _v2;

	private GUIStyle style;

	private bool enableRefresh = true;
	private List<string> contents = new List<string>();

	// Use this for initialization
	void Start () {
		InvokeRepeating("EnableRefresh", 0.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			if (TouchPhase.Began == Input.GetTouch(0).phase) {
				_v1 = _v2 = Input.GetTouch(0).position;
			} else if (TouchPhase.Moved == Input.GetTouch(0).phase) {
				_v2 = _v1;
				_v1 = Input.GetTouch(0).position;
				scrollPosition.y -= (_v1.y > _v2.y ? -1 : 1) * Vector2.
					Distance(_v1, _v2);
			}
		} else {
			if (Input.GetMouseButtonDown(0)) {
				_v1 = _v2 = new Vector2(Input.mousePosition.x, Input.
					mousePosition.y);

			} else if (Input.GetMouseButton(0)) {
				_v2 = _v1;
				_v1 = new Vector2(Input.mousePosition.x, Input.
					mousePosition.y);
				scrollPosition.y += (_v1.y > _v2.y ? -1 : 1) * Vector2.
					Distance(_v1, _v2);
			}
		}
	}

	void OnGUI() {
		// Throttle content update events.
		if (enableRefresh) {
			enableRefresh = false;
			contents = new List<string> ();
			generateContent ();
		}

		style = new GUIStyle(GUI.skin.label);
		style.fontSize = 28;

		GUILayout.BeginVertical();
		scrollPosition = GUILayout.BeginScrollView(
			scrollPosition,
			GUILayout.Width(Screen.width),
			GUILayout.Height(Screen.height)
		);

		foreach (string line in contents) {
			print (line);
		}

		GUILayout.EndScrollView();
		GUILayout.EndVertical();
	}

	private void generateContent() {
		printIntoBuffer("===== ACCELERATION =====");
		printIntoBuffer("Input.acceleration = \n(" + Input.acceleration.x + ", " + Input.acceleration.y + ", " + Input.acceleration.z + ")");


		printIntoBuffer("\n===== GYROSCOPE =====");
		printIntoBuffer("Input.gyro.attitude = " + Input.gyro.attitude.ToString());
		printIntoBuffer("Input.gyro.enabled = " + Input.gyro.enabled.ToString());
		printIntoBuffer("Input.gyro.gravity = " + Input.gyro.gravity.ToString());
		printIntoBuffer("Input.gyro.rotationRate = " + Input.gyro.rotationRate.ToString());
		printIntoBuffer("Input.gyro.rotationRateUnbiased = " + Input.gyro.rotationRateUnbiased.ToString());
		printIntoBuffer("Input.gyro.updateInterval = " + Input.gyro.updateInterval.ToString());
		printIntoBuffer("Input.gyro.userAcceleration = " + Input.gyro.userAcceleration.ToString());


		printIntoBuffer("\n===== COMPASS =====");
		printIntoBuffer("Input.compass.enabled = " + Input.compass.enabled.ToString());
		printIntoBuffer("Input.compass.headingAccuracy = " + Input.compass.headingAccuracy.ToString());
		printIntoBuffer("Input.compass.magneticHeading = " + Input.compass.magneticHeading.ToString());
		printIntoBuffer("Input.compass.rawVector = " + Input.compass.rawVector.ToString());
		printIntoBuffer("Input.compass.timestamp = " + Input.compass.timestamp.ToString());
		printIntoBuffer("Input.compass.trueHeading = " + Input.compass.trueHeading.ToString());

		printIntoBuffer("\n===== SYSTEM =====");
		printIntoBuffer("SystemInfo.deviceModel = " + SystemInfo.deviceModel);
		printIntoBuffer("SystemInfo.deviceUniqueIdentifier = " + SystemInfo.deviceUniqueIdentifier);
		printIntoBuffer("SystemInfo.graphicsDeviceID = " + SystemInfo.graphicsDeviceID.ToString());
		printIntoBuffer("SystemInfo.graphicsDeviceName = " + SystemInfo.graphicsDeviceName);
		printIntoBuffer("SystemInfo.graphicsDeviceVendor = " + SystemInfo.graphicsDeviceVendor);
		printIntoBuffer("SystemInfo.graphicsDeviceVendorID = " + SystemInfo.graphicsDeviceVendorID.ToString());
		printIntoBuffer("SystemInfo.graphicsDeviceVersion = " + SystemInfo.graphicsDeviceVersion);
		printIntoBuffer("SystemInfo.graphicsMemorySize = " + SystemInfo.graphicsMemorySize.ToString());
		printIntoBuffer("SystemInfo.graphicsShaderLevel = " + SystemInfo.graphicsShaderLevel.ToString());
		printIntoBuffer("SystemInfo.npotSupport = " + SystemInfo.npotSupport.ToString());
		printIntoBuffer("SystemInfo.operatingSystem = " + SystemInfo.operatingSystem);
		printIntoBuffer("SystemInfo.processorCount = " + SystemInfo.processorCount.ToString());
		printIntoBuffer("SystemInfo.processorType = " + SystemInfo.processorType);
		printIntoBuffer("SystemInfo.supportedRenderTargetCount = " + SystemInfo.supportedRenderTargetCount.ToString());
		printIntoBuffer("SystemInfo.supports3DTextures = " + SystemInfo.supports3DTextures.ToString());
		printIntoBuffer("SystemInfo.supportsAccelerometer = " + SystemInfo.supportsAccelerometer.ToString());
		printIntoBuffer("SystemInfo.supportsComputeShaders = " + SystemInfo.supportsComputeShaders.ToString());
		printIntoBuffer("SystemInfo.supportsGyroscope = " + SystemInfo.supportsGyroscope.ToString());
		printIntoBuffer("SystemInfo.supportsImageEffects = " + SystemInfo.supportsImageEffects.ToString());
		printIntoBuffer("SystemInfo.supportsInstancing = " + SystemInfo.supportsInstancing.ToString());
		printIntoBuffer("SystemInfo.supportsLocationService = " + SystemInfo.supportsLocationService.ToString());
		printIntoBuffer("SystemInfo.supportsRenderToCubemap = " + SystemInfo.supportsRenderToCubemap.ToString());
		printIntoBuffer("SystemInfo.supportsShadows = " + SystemInfo.supportsShadows.ToString());
		printIntoBuffer("SystemInfo.supportsSparseTextures = " + SystemInfo.supportsSparseTextures.ToString());
		printIntoBuffer("SystemInfo.supportsVibration = " + SystemInfo.supportsVibration.ToString());
		printIntoBuffer("SystemInfo.systemMemorySize = " + SystemInfo.systemMemorySize.ToString());
	}

	private void printIntoBuffer(string newContent) {
		contents.Add (newContent);
	}

	private void print(string content) {
		GUILayout.Label (content, style);
	}

	private void EnableRefresh() {
		enableRefresh = true;
	}
}
