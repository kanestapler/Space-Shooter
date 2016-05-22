using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnPosition;

	// Use this for initialization
	void Start () {
		SpawnWaves ();
	}

	void SpawnWaves() {
		Instantiate (
			hazard,
			new Vector3(Random.Range(-spawnPosition.x, spawnPosition.x), spawnPosition.y, spawnPosition.z),
			Quaternion.identity);
	}
}
