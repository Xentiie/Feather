using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	private float originalPos;
	private float[] positions = {1.05f, 3.05f, 5.1f, 7.3f, 9.1f, 12f};

	void Start() {
		transform.position = new Vector3(GameManager.instance.feather.transform.position.x-10, positions[Random.Range(0, positions.Length)], GameManager.instance.feather.transform.position.z);
		originalPos = transform.position.x;
	}

	void Update() {
		Vector3 newPos = transform.position;
		newPos.x += Time.deltaTime*24;
		transform.position = newPos;
		if(transform.position.x >= originalPos+100) Destroy(gameObject);
	}
}
