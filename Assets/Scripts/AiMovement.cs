using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour {

	public Transform target;

	private float speed = 4000.0f;
	private float rotationSpeed = 15000.0f;

	private int breakAwayDistance = 100;
	private Vector3 breakAwayOffset;

	private Rigidbody rb;
	private WeaponController weaponController;

	private bool canEngage = false;

	void Start () {
		rb = GetComponent<Rigidbody>();

		weaponController = GetComponent<WeaponController>();

		if (target == null) {
			GameObject playerObject = GameObject.FindWithTag("Player");

			if (playerObject != null) {
				target = playerObject.transform;				
			}
		}

		Invoke("Engage", 5.0f);
	}
	
	void Update () {
		if (target != null) {
			float distance = Vector3.Distance(target.position, transform.position);

			if (distance < breakAwayDistance) {
				// If this is the first frame breaking away, set a random offset
				if (breakAwayDistance != 325) {
					breakAwayOffset = new Vector3(Random.Range(-45, 45), Random.Range(-45, 45), Random.Range(-45, 45));
				}

				breakAwayDistance = 325;

				BreakAway();
			} else {
				breakAwayDistance = 150;

				RotateTowardsTarget();
			}

			// TODO is there any reason why the AI wouldn't always be at full throttle?
			rb.AddForce(transform.forward * speed * Time.fixedDeltaTime);			

			Vector3 targetVector = target.position - transform.position;
			float angleBetween = Vector3.Angle(transform.forward, targetVector);

			if (canEngage && angleBetween <= 10 && Vector3.Distance(target.position, transform.position) <= 1250) {
				weaponController.Fire();
			}
		}
	}

	private void RotateTowardsTarget () {
		Vector3 targetAngle = Quaternion.LookRotation(target.position - transform.position).eulerAngles;
		Vector3 currentAngle = transform.rotation.eulerAngles;
		Vector3 torque = new Vector3(
			Mathf.DeltaAngle(currentAngle.x, targetAngle.x),
			Mathf.DeltaAngle(currentAngle.y, targetAngle.y),
			Mathf.DeltaAngle(currentAngle.z, targetAngle.z)).normalized;

		rb.AddRelativeTorque(torque * Time.deltaTime * rotationSpeed);
	}

	// Move away form the target as fast as possible, gaining gorund while preparing to turn to engage
	private void BreakAway () {
		Vector3 targetAngle = -Quaternion.LookRotation(target.position - transform.position).eulerAngles + breakAwayOffset;
		Vector3 currentAngle = transform.rotation.eulerAngles;
		Vector3 torque = new Vector3(
			Mathf.DeltaAngle(currentAngle.x, targetAngle.x),
			Mathf.DeltaAngle(currentAngle.y, targetAngle.y),
			Mathf.DeltaAngle(currentAngle.z, targetAngle.z)).normalized;

		rb.AddRelativeTorque(torque * Time.deltaTime * rotationSpeed);
	}

	private void Engage () {
		canEngage = true;
	}
}
