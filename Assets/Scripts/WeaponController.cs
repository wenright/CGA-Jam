using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject laser;
	public Transform barrel;

	public bool isPlayer = false;

	public float ROF = 0.15f;
	public float accuracy = 1.0f;

	private bool canFire = true;

	void Update () {
		if (isPlayer) {
			if (Input.GetButton("Fire1")) {
				Fire();
			}
		}
	}

	public void Fire () {
		if (canFire) {
			Vector3 randomness = new Vector3(Random.Range(-this.accuracy, this.accuracy), Random.Range(-this.accuracy, this.accuracy), Random.Range(-this.accuracy, this.accuracy));
			Vector3 angleOffset = new Vector3(0, 90, 90) + randomness;
			Instantiate(laser, barrel.position, transform.rotation * Quaternion.Euler(angleOffset));

			canFire = false;
			Invoke("ResetCanFire", ROF);
		}
	}

	private void ResetCanFire () {
		canFire = true;
	}
}
