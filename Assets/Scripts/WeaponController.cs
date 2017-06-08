using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject laser;
	public Transform barrel;

	public bool isPlayer = false;

	private bool canFire = true;
	private float ROF = 0.15f;

	void Update () {
		if (isPlayer) {
			if (Input.GetButton("Fire1")) {
				Fire();
			}
		}
	}

	public void Fire () {
		if (canFire) {
			float randomRange = 1.0f;
			Vector3 randomness = new Vector3(Random.Range(-randomRange, randomRange), Random.Range(-randomRange, randomRange), Random.Range(-randomRange, randomRange));
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
