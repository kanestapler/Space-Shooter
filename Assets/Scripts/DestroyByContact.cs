using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject astroidExplosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Boundary")) {
			return;
		}

		Instantiate (astroidExplosion, transform.position, transform.rotation);

		if (other.CompareTag ("Player")) {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}

		Destroy (other.gameObject);
		Destroy (gameObject);
	}

}
