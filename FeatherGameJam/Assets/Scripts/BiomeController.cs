using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeController : MonoBehaviour {

	public float timer = 0f;

	void Update() {
		timer += Time.deltaTime;
		if(timer >= 70f) Destroy(gameObject);
	}
}
