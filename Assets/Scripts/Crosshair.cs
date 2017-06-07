using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        float length = 100;
        float thickness = 0.1f;
        GUI.Box(new Rect(Screen.width / 2 - length/2, Screen.height / 2 - thickness/2, length, thickness), "");
        GUI.Box(new Rect(Screen.width / 2 - thickness/2, Screen.height / 2 - length/2, thickness, length), "");
    }
}
