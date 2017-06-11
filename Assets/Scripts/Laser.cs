using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public GameObject hitParticleSystem;

	public const int speed = 500;

	private Vector3 lastPosition;

	void Start () {
		lastPosition = transform.position;
	}

	void Update () {
		transform.Translate(Vector3.up * speed * Time.deltaTime);

		RaycastHit hit;

		if (Physics.Linecast(lastPosition, transform.position, out hit)) {
			Hit(hit);
		}

		lastPosition = transform.position;
	}

	void Hit (RaycastHit hit) {
		// TODO damage target here
		if (hit.transform.tag == "Ship") {
			ShipHealth sh = hit.transform.gameObject.GetComponent<ShipHealth>();
			sh.Hit(25);
		}

		Instantiate(hitParticleSystem, hit.point, Quaternion.LookRotation(hit.normal));

		Destroy(gameObject);
	}
}
