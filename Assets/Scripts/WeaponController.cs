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
			Instantiate(laser, barrel.position, transform.rotation * Quaternion.Euler(0, 90, 90));

			canFire = false;
			Invoke("ResetCanFire", ROF);
		}
	}

	private void ResetCanFire () {
		canFire = true;
	}
}
