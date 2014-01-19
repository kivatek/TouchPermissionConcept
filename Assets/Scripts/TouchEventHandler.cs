using UnityEngine;
using System.Collections;

public interface TouchEventHandler {

	void UpdateCondition (string pCondition);

	void ProcessTouchEvent (RaycastHit pRaycastHit);

}
