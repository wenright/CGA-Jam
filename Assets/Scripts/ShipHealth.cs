using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour {

	public int health = 100;

	void Start () {
		
	}
	
	public void Hit (int damage) {
		health -= damage;

		if (health <= 0) {
			// TODO ship explosion particle system
			Destroy(gameObject);
		}
	}
}
