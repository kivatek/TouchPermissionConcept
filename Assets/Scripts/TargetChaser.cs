﻿using UnityEngine;
using System.Collections;

public class TargetChaser : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.LookAt(target.transform.position);
		}
	}
}
