using UnityEngine;
using System;
using System.Collections;
using System.Security.Cryptography;

abstract public class TouchPermissionClient : MonoBehaviour {

	private string permissionSignature_;
	
	abstract protected string GetSignatureSeed();

	/// <summary>
	/// 
	/// </summary>
	/// <returns>The signature.</returns>
	protected void CalculateSignature() {
		MD5 md5 = MD5.Create();
		permissionSignature_ = BitConverter.ToString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(GetSignatureSeed()))).ToLower().Replace("-","");
	}

	public int CheckPermission (string pSignatures) {
		if (pSignatures.Contains(permissionSignature_)) {
			return 1;
		}
		return 0;
	}
}
