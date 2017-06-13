using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject laser;
	public Transform barrel;

	public AudioClip laserSound;
	public AudioSource audioSource;

	public bool isPlayer = false;

	public float ROF = 0.15f;
	public float accuracy = 1.0f;

	private bool canFire = true;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		if (isPlayer) {
			if (Input.GetButton("Fire1")) {
				Fire();
			}
		}
	}

	public void Fire () {
		if (canFire) {
			audioSource.PlayOneShot(laserSound, 0.5f);

			Vector3 randomness = new Vector3(Random.Range(-this.accuracy, this.accuracy), Random.Range(-this.accuracy, this.accuracy), Random.Range(-this.accuracy, this.accuracy));
			Vector3 angleOffset = new Vector3(0, 90, 90) + randomness;

			GameObject laserInstance = Instantiate(laser, barrel.position, transform.rotation * Quaternion.Euler(angleOffset)) as GameObject;
			laserInstance.GetComponent<Laser>().parentSpeed = rb.velocity;

			canFire = false;
			Invoke("ResetCanFire", ROF);
		}
	}

	private void ResetCanFire () {
		canFire = true;
	}
}
