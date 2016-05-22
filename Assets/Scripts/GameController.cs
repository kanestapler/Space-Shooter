using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnPosition;
	public int spawnsInWave;
	public float spawnWait;
	public float startWait;

	// Use this for initialization
	void Start () {
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
}
