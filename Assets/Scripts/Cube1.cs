using UnityEngine;
using System.Collections;

public class Cube1 : TouchPermissionClient, TouchEventHandler {

	// Use this for initialization
	void Start () {
		CalculateSignature();
	}
	
	// Update is called once per frame
	void Update () {

	}

	protected override string GetSignatureSeed () {
		return "cube1";
	}

	public void UpdateCondition (string pCondition) {
		if (pCondition.Equals("condition-1")) {
			renderer.material.color = Color.cyan;
		} else {
			renderer.material.color = new Color(0, 0.5f, 0.5f);
		}
	}

	public void ProcessTouchEvent (RaycastHit pRaycastHit)
	{
		BroadcastMessage("ToggleEffect");
	}
}
