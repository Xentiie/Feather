using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	private float y;
	private float z;

	void Start() {
		y = transform.position.y;
		z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = new Vector3(GameManager.instance.feather.transform.position.x, y, z);
		transform.position = newPos;
	}
}
