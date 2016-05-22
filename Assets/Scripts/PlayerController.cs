using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float sideTilt;
	public float frontTilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private Rigidbody rb;
	private AudioSource shotAudio;
	private float nextFire = 0.0f;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		shotAudio = GetComponent<AudioSource> ();
	}

	void Update() {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (
				shot, 
				shotSpawn.position,
				Quaternion.Euler(shotSpawn.rotation.x, shotSpawn.rotation.y, shotSpawn.rotation.z));
			shotAudio.Play ();
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		rb.velocity = (new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed);

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
		
		rb.rotation = Quaternion.Euler (
			(rb.velocity.z * frontTilt), 
			0, 
			(rb.velocity.x * -sideTilt));
	}
}
