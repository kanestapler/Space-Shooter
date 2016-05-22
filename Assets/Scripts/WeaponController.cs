using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float shotDelay;

	private AudioSource shotAudio;

	void Start () {
		shotAudio = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", shotDelay, fireRate);
	}

	void Fire() {
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		shotAudio.Play();
	}
}
