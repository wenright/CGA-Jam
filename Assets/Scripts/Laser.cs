﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public GameObject hitParticleSystem;

	public const int speed = 500;
	public int damage = 25;
	// TODO if using parent speed, lead object marker needs to be updated so that it is more accurate at that velocity
	public Vector3 parentSpeed = Vector3.zero;

	private Vector3 lastPosition;

	void Start () {
		lastPosition = transform.position;
	}

	void Update () {
		// TODO use parent speed to make firing at high speeds more realistic
		transform.Translate(Vector3.up * speed * Time.deltaTime);

		RaycastHit hit;

		if (Physics.Linecast(lastPosition, transform.position, out hit)) {
			Hit(hit);
		}

		lastPosition = transform.position;
	}

	void Hit (RaycastHit hit) {
		if (hit.transform.tag == "Ship" || hit.transform.tag == "Player") {
			ShipHealth sh = hit.transform.gameObject.GetComponent<ShipHealth>();
			sh.Hit(damage);
		}

		Instantiate(hitParticleSystem, hit.point, Quaternion.LookRotation(hit.normal));

		Destroy(gameObject);
	}
}
