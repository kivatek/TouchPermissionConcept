using UnityEngine;
using System.Collections;

public class Changer : TouchPermissionClient, TouchEventHandler {

	// Use this for initialization
	void Start () {
		CalculateSignature();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override string GetSignatureSeed ()
	{
		return "changer";
	}

	public void UpdateCondition (string pCondition) {
	}

	public void ProcessTouchEvent (RaycastHit pRaycastHit)
	{
		GameObject go = GameObject.Find ("Game Controller");
		if (go != null) {
			go.SendMessage("ChangeCondition");
		}
	}
}
