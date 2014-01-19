using UnityEngine;
using System.Collections;

public class EffectController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartEffect () {
		particleSystem.Play ();
	}

	public void PauseEffect () {
		particleSystem.Pause ();
	}

	public void StopEffect () {
		particleSystem.Stop ();
	}

	public void ToggleEffect () {
		if (particleSystem.isPlaying) {
			PauseEffect ();
		} else {
			StartEffect ();
		}
	}
}
