using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeadAngle : MonoBehaviour {

	public Transform leadObject;
	public Transform player;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
		player = GameObject.FindWithTag("Player").transform;
	}

	void Update () {
		if (player == null) {
			return;
		}

		float distanceToPlayer = Vector3.Distance(transform.position, player.position);

		float timeToTarget = distanceToPlayer / Laser.speed;

		leadObject.position = transform.position + rb.velocity * timeToTarget;
	}
}
