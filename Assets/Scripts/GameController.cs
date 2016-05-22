using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnPosition;
	public int spawnsInWave;
	public float spawnWait;
	public float startWait;
	public Text scoreText;
	public Text gameOverText;
	public Text restartText;

	private int score;
	private bool gameOver;

	// Use this for initialization
	void Start () {
		score = 0;
		gameOver = false;
		UpdateScoreText();
		gameOverText.text = "";
		restartText.text = "";
		StartCoroutine (SpawnWaves());
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
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

				if (gameOver) {
					break;
				}
			}
			if (gameOver) {
				restartText.text = "Press 'R' to restart";
				break;
			}
		}
	}

	public void AddScore(int update) {
		score += update;
		UpdateScoreText ();
	}

	void UpdateScoreText() {
		scoreText.text = "Score: " + score.ToString ();
	}

	public void GameOver() {
		gameOver = true;
		gameOverText.text = "Game Over!";
	}
}
