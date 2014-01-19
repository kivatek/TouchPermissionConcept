using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public class TouchPermissionServer : MonoBehaviour {

	private IDictionary<string, string> signatures_ = new Dictionary<string, string>();

	private MD5 md5_ = MD5.Create();

	// Use this for initialization
	void Start () {
		LoadPermissions();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns>The hashed string.</returns>
	/// <param name="pText"></param>
	private string ToHashedString(string pText) {
		return BitConverter.ToString(md5_.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pText))).ToLower().Replace("-","");
	}

	/// <summary>
	/// 
	/// </summary>
	public void LoadPermissions() {
		string changer = "changer";
		string cube1 = "cube1";
		string cube2 = "cube2";
		StringBuilder sb = new StringBuilder();
		sb.Append(ToHashedString(changer));
		sb.Append(",").Append(ToHashedString(cube1));
		signatures_.Add("condition-1", sb.ToString());
		Debug.Log ("1:" + sb.ToString());
		sb.Remove(0, sb.Length);
		sb.Append(ToHashedString(changer));
		sb.Append(",").Append(ToHashedString(cube2));
		signatures_.Add("condition-2", sb.ToString());
		Debug.Log ("2:" + sb.ToString());
	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns>The permission.</returns>
	/// <param name="pArgs"></param>
	public int CheckPermission(string pCondition, GameObject pObject) {
		string signatures = signatures_[pCondition];
		if (string.IsNullOrEmpty(signatures) == false) {
			TouchPermissionClient client = pObject.GetComponentInChildren<TouchPermissionClient>();
			if (client != null) {
				return client.CheckPermission(signatures);
			}
		}
		return 0;
	}
}
