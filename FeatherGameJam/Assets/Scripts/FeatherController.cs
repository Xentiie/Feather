using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeatherController : MonoBehaviour {
	
	private float speed = 0f;
	public Canvas canvas;
	[Space]
	public Image panel;
	public Color IceColor;
	public Color FireColor;
	[Space]
	public WindZone windzoneUp;
	public WindZone windzoneDown;

	private Color originalColor;

	void Start() {
		originalColor = panel.color;
	}

	// Update is called once per frame
	void Update () {
		Vector3 newPos = transform.position;

		if(Input.GetMouseButton(0)) {
			speed += Time.deltaTime;
			panel.color = Color.Lerp(panel.color, FireColor, Time.deltaTime * 2);
		}
		if(Input.GetMouseButtonDown(0)){
			GameManager.instance.TriggerFireOn();
			windzoneUp.gameObject.SetActive(true);
		} 
		if(Input.GetMouseButtonUp(0)) {
			GameManager.instance.TriggerFireOff();
			windzoneUp.gameObject.SetActive(false);
		} 
		

		if(Input.GetMouseButton(1)) {
			speed -= Time.deltaTime;
			panel.color = Color.Lerp(panel.color, IceColor, Time.deltaTime * 2);
		}
		if(Input.GetMouseButtonDown(1)){
			GameManager.instance.TriggerIceOn();
			windzoneDown.gameObject.SetActive(true);
		} 
		if(Input.GetMouseButtonUp(1)) {
			GameManager.instance.TriggerIceOff();
			windzoneDown.gameObject.SetActive(false);
		} 

		if(Input.GetMouseButton(0) == false && Input.GetMouseButton(1) == false) {
			if(speed >= 0)
				speed -= Time.deltaTime*2;
			else speed += Time.deltaTime*2;
			speed = Mathf.Clamp(speed, -1.2f, 2);

			panel.color = Color.Lerp(panel.color, originalColor, Time.deltaTime * 2);
		}

		speed = Mathf.Clamp(speed, -1.2f, 2);
		newPos.y += speed*10;

		newPos.x += Time.deltaTime * 400f;
		transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime/2);
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag == "NewBiomePls") {
			GameManager.instance.GenerateNewBiome();
		} else 
			GameManager.instance.GameOver();
		
	}

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "NewBiomePls") {
			GameManager.instance.GenerateNewBiome();
		} else 
			GameManager.instance.GameOver();
		
	}

}
