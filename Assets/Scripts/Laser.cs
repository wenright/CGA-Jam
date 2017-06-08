using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	private int speed = 100;
	private int lifetime = 5;

	void Start () {
		Destroy(gameObject, lifetime);
	}

	void Update () {
		transform.Translate(Vector3.up * speed * Time.deltaTime);
	}
}
