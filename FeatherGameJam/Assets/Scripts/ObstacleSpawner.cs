using System.Linq;
using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {

	private float[] positions = {1.05f, 3.05f, 5.1f, 7.3f, 9.1f, 12f};

	private float spawnRate = 3f;
	public float timer = 0f;

	private int ran;

	public GameObject[] obstacles;
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= spawnRate && UnityEngine.Random.Range(1, 3) == 2) {
			timer = 0f;
			foreach (GameObject obstacle in obstacles) {
				if(obstacle.name.Split('_')[1] == GameManager.instance.currentBiome.name) {
					ran = Random.Range(0, positions.Length);
					Spawn(obstacle);
					break;
				} 
			}
		}
	}

	public void UpdateSpawnRate() {
		spawnRate -= 0.2f;
	}

	public void Spawn(GameObject obstacle) {
		if(GameManager.instance.isPlaying) {
			Instantiate(obstacle).transform.position = new Vector3(GameManager.instance.feather.transform.position.x-10, 
				positions[ran], GameManager.instance.feather.transform.position.z);
		}
	}

}
