using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadAngle : MonoBehaviour {

	public Transform leadObject;
	public Transform player;

	// TODO this should be taken from weapon manager itself
	private int laserSpeed = 250;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		float distanceToPlayer = Vector3.Distance(transform.position, player.position);

		float timeToTarget = distanceToPlayer / laserSpeed;

		leadObject.position = transform.position + rb.velocity * timeToTarget;
	}
}
