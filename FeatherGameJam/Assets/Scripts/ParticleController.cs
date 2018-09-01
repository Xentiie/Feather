using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

	public Camera cam;

	void Update () {
   		Vector3 temp = Input.mousePosition;
   		temp.z = 10f;
   		this.transform.position = cam.ScreenToWorldPoint(temp);
 	}
}
