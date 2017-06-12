using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShipHealth : MonoBehaviour {

	public int health = 100;

	public bool isPlayer = false;
	public GameObject flashImage;

	public GameObject explosionObject;

	public Slider healthBar;

	void Start () {
		
	}
	
	public void Hit (int damage) {
		health -= damage;

		if (isPlayer && flashImage != null) {
			flashImage.SetActive(true);
			Invoke("HideFlash", 0.05f);

			if (healthBar != null) {
				healthBar.value = this.health;
			}
		}

		if (health <= 0) {
			Instantiate(explosionObject, transform.position, transform.rotation);

			if (isPlayer) {
				Camera.main.transform.parent = null;

				// I just picked these numbers at random. Maybe use an RNG and tween into position, or even slow down time?
				Vector3 newPosition = Camera.main.transform.position + new Vector3(-32, 42, -25);
				Camera.mina.transform.DOMove(newPosition, 2.0f).SetEase(Ease.OutQuad);
				Camera.main.transform.LookAt(transform);

				HideFlash();
			}

			Destroy(gameObject);
		}
	}

	private void HideFlash () {
		flashImage.SetActive(false);
	}
}
