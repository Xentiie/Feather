using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	private GameObject feather;

	void Start() {
		feather = GameManager.instance.feather;
	}

	void LateUpdate() {
		if(feather == null)
			return;
		Vector3 newPos = feather.transform.position;
		newPos.x = feather.transform.position.x + 3;
		newPos.z = -10;
		newPos.y = Mathf.Clamp(newPos.y, 4f, 7f);
		transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime*2);
	}

}
