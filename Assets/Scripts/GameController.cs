using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnPosition;
	public int spawnsInWave;
	public float spawnWait;
	public float startWait;
	public Text scoreText;

	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		updateScoreText();
		StartCoroutine (SpawnWaves());
	}

	IEnumerator SpawnWaves() {

		while (true) {
			yield return new WaitForSeconds (startWait);
			for (int i = 0; i < spawnsInWave; i++) {
				Instantiate (
					hazard,
					new Vector3 (Random.Range (-spawnPosition.x, spawnPosition.x), spawnPosition.y, spawnPosition.z),
					Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
		}
	}

	public void addScore(int update) {
		score += update;
		updateScoreText ();
	}

	void updateScoreText() {
		scoreText.text = "Score: " + score.ToString ();
	}
}
