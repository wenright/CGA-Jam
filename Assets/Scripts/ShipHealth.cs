using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour {

	public int health = 100;

	public bool isPlayer = false;
	public GameObject flashImage;

	void Start () {
		
	}
	
	public void Hit (int damage) {
		health -= damage;

		if (isPlayer && flashImage != null) {
			flashImage.SetActive(true);
			Invoke("HideFlash", 0.05f);
		}

		if (health <= 0) {
			// TODO ship explosion particle system
			Destroy(gameObject);
		}
	}

	private void HideFlash () {
		flashImage.SetActive(false);
	}
}
