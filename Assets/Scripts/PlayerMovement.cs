using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public Text speedText;

	private Rigidbody rb;
	private float speed = 2000.0f;
	private float rotationSpeed = 1000.0f;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
		// Forward Thrust
		if (Input.GetKey("w")) {
			rb.AddForce(transform.forward * speed * Time.fixedDeltaTime);
		}

		// Strafing
		if (Input.GetKey("a")) {
			rb.AddForce(transform.right * -(speed / 4) * Time.fixedDeltaTime);
		} else if (Input.GetKey("d")) {
			rb.AddForce(transform.right * (speed / 4) * Time.fixedDeltaTime);
		}


		// Pitch
		if (Input.GetKey("i")) {
			rb.AddRelativeTorque(rotationSpeed * Time.fixedDeltaTime, 0, 0);
		} else if (Input.GetKey("k")) {
			rb.AddRelativeTorque(-rotationSpeed * Time.fixedDeltaTime, 0, 0);
		}

		// Yaw
		if (Input.GetKey("j")) {
			rb.AddRelativeTorque(0, -rotationSpeed * Time.fixedDeltaTime, 0);
		} else if (Input.GetKey("l")) {
			rb.AddRelativeTorque(0, rotationSpeed * Time.fixedDeltaTime, 0);
		}

		// Roll
		if (Input.GetKey("u")) {
			rb.AddRelativeTorque(0, 0, rotationSpeed * Time.fixedDeltaTime);
		} else if (Input.GetKey("o")) {
			rb.AddRelativeTorque(0, 0, -rotationSpeed * Time.fixedDeltaTime);
		}

		speedText.text = ((int) rb.velocity.magnitude).ToString() + " KPH";
	}
}
