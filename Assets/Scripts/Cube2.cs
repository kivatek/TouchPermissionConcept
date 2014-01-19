using UnityEngine;
using System.Collections;

public class Cube2 : TouchPermissionClient, TouchEventHandler {

	// Use this for initialization
	void Start () {
		CalculateSignature();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override string GetSignatureSeed () {
		return "cube2";
	}
	
	public void UpdateCondition (string pCondition) {
		if (pCondition.Equals("condition-2")) {
			renderer.material.color = Color.green;
		} else {
			renderer.material.color = new Color(0, 0.5f, 0);
		}
	}

	public void ProcessTouchEvent (RaycastHit pRaycastHit)
	{
		BroadcastMessage("ToggleEffect");
	}
}
