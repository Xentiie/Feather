using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour {

	#region Sigleton

	public static GameManager instance;

	void Awake() {
		instance = this;
	}

	#endregion

	public GameObject feather;
	public ParticleSystem boumBigShock;
	[Space]
	public Texture2D fireCursorIcons;
	public ParticleSystem fireParticles;
	[Space]
	public Texture2D iceCursorIcons;
	public ParticleSystem iceParticles;
	[Space]
	public GameObject[] biomes;
	[Space]
	public Image firstTimePanel;
	[Space]
	public GameObject GameFinishedPanel;
	public TextMeshProUGUI TimeDisplay;
	public TextMeshProUGUI BestTime;

	[HideInInspector]
	public GameObject currentBiome;
	[HideInInspector]
	public bool isPlaying = true;

	void Start() {
		if(PlayerPrefs.GetInt("firstTime", 1) == 1) {
			firstTimePanel.gameObject.SetActive(true);
			Time.timeScale = 0f;
		} else 	Destroy(firstTimePanel.gameObject);

		int biomeIndex = UnityEngine.Random.Range(0, biomes.Length);
		GameObject newBiome = Instantiate(biomes[biomeIndex]);
		Vector3 newBiomePos = newBiome.transform.position;
		newBiomePos.x = feather.transform.position.x;
		newBiome.transform.position = newBiomePos;
		
		newBiome = Instantiate(biomes[biomeIndex]);
		newBiomePos = newBiome.transform.position;
		newBiomePos.x = feather.transform.position.x - 150;
		newBiome.transform.position = newBiomePos;
		Destroy(newBiome.transform.GetChild(3).gameObject);

		currentBiome = biomes[biomeIndex];
		
		TriggerFireOff();
		TriggerIceOff();
	}

	public void GameOver() {
		Time.timeScale = 0f;
		Destroy(feather);
		boumBigShock.transform.position = feather.transform.position;
		boumBigShock.Play();
		
		GameFinishedPanel.SetActive(true);

		if(PlayerPrefs.GetFloat("bestScore", 0) < Time.timeSinceLevelLoad) PlayerPrefs.SetFloat("bestScore", Time.timeSinceLevelLoad);
		TimeDisplay.SetText("Trip Time: " + Time.timeSinceLevelLoad);
		BestTime.SetText("Best Time: " + PlayerPrefs.GetFloat("bestScore", 0));
	}

	public void TriggerFireOn() {
		Cursor.SetCursor(fireCursorIcons, new Vector2(28,27), CursorMode.Auto);
		fireParticles.Play(true);
	}

	public void TriggerFireOff() {
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		fireParticles.Stop(true);
	}

	public void TriggerIceOn() {
		Cursor.SetCursor(iceCursorIcons, new Vector2(28,27), CursorMode.Auto);
		iceParticles.Play();
	}

	public void TriggerIceOff() {
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		iceParticles.Stop();
	}

	public void GenerateNewBiome() {
		int biomeIndex = UnityEngine.Random.Range(0, biomes.Length);
		GameObject newBiome = Instantiate(biomes[biomeIndex]);
		Vector3 newBiomePos = newBiome.transform.position;
		newBiomePos.x = feather.transform.position.x + 60;
		newBiome.transform.position = newBiomePos;
		currentBiome = biomes[biomeIndex];
		FindObjectOfType<ObstacleSpawner>().UpdateSpawnRate();
	}

	public void Quit() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void StartGame() {
		Time.timeScale = 1f;
		PlayerPrefs.SetInt("firstTime", 0);
		Destroy(firstTimePanel.gameObject);
	}

	public void RestartGame() {
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}

}
