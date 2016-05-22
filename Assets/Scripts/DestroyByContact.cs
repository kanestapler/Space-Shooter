using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject astroidExplosion;
	public GameObject playerExplosion;
	public int pointsWhenExploded;

	private GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Can not find GameController");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Boundary")) {
			return;
		}

		Instantiate (astroidExplosion, transform.position, transform.rotation);

		if (other.CompareTag ("Player")) {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}

		gameController.addScore (pointsWhenExploded);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}

}
