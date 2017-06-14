using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public Text speedText;

	private Rigidbody rb;
	private float speed = 5500.0f;
	private float rotationSpeed = 2000.0f;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
		// Forward Thrust
		if (Input.GetButton("Thrust")) {
			rb.AddForce(transform.forward * speed * Time.fixedDeltaTime);
		}

		// Pitch
		if (Input.GetButton("PitchDown")) {
			rb.AddRelativeTorque(rotationSpeed * Time.fixedDeltaTime, 0, 0);
		} else if (Input.GetButton("PitchUp")) {
			rb.AddRelativeTorque(-rotationSpeed * Time.fixedDeltaTime, 0, 0);
		}

		// Yaw
		if (Input.GetButton("YawLeft")) {
			rb.AddRelativeTorque(0, -rotationSpeed * Time.fixedDeltaTime, 0);
		} else if (Input.GetButton("YawRight")) {
			rb.AddRelativeTorque(0, rotationSpeed * Time.fixedDeltaTime, 0);
		}

		// Roll
		if (Input.GetButton("RollLeft")) {
			rb.AddRelativeTorque(0, 0, rotationSpeed * Time.fixedDeltaTime);
		} else if (Input.GetButton("RollRight")) {
			rb.AddRelativeTorque(0, 0, -rotationSpeed * Time.fixedDeltaTime);
		}

		speedText.text = ((int) rb.velocity.magnitude).ToString() + " KPH";
	}
}
