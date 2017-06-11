using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadAngle : MonoBehaviour {

	public Transform leadObject;
	public Transform player;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		// TODO lead angle icon should be a GUI object so that it does not scale with distance

		if (player == null) {
			return;
		}

		float distanceToPlayer = Vector3.Distance(transform.position, player.position);

		float timeToTarget = distanceToPlayer / Laser.speed;

		leadObject.position = transform.position + rb.velocity * timeToTarget;
	}
}
