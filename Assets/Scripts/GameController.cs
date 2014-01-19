using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public string condition = "condition-1";

	// このコンポーネントがコアであることとTouchPermissionServerの利用頻度が高いことから参照を保持してしまう。
	private TouchPermissionServer touchPermissionServer_;

	// Use this for initialization
	void Start () {
		touchPermissionServer_ = GetComponentInChildren<TouchPermissionServer>();
		SendCondition();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			ProcessMouseButtonDown();
		}
	}

	public void SendCondition() {
		GameObject go = GameObject.Find("UI Root");
		if (go != null) {
			go.BroadcastMessage("UpdateCondition", condition);
		}
	}

	public void ChangeCondition () {
		if (condition.Equals("condition-1")) {
			condition = "condition-2";
		} else {
			condition = "condition-1";
		}
		SendCondition();
	}

	private void ProcessMouseButtonDown () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit raycastHit = new RaycastHit();
		if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity)) {
			if (EvaluateTouchPermission(raycastHit.collider.gameObject) == 1) {
				raycastHit.collider.gameObject.SendMessage("ProcessTouchEvent", raycastHit);
			}
		}
	}

	public int EvaluateTouchPermission(GameObject pObject) {
		if (touchPermissionServer_ != null) {
			return touchPermissionServer_.CheckPermission(condition, pObject);
		}
		return 0;
	}
}
