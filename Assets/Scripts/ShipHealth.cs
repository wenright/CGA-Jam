using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShipHealth : MonoBehaviour {

	public int health = 100;

	public bool isPlayer = false;
	public GameObject flashImage;
	public GameObject gameOverText;
	public GameObject hud;

	public GameObject explosionObject;
	public GameObject shipCorpseObject;

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
			// Instantiate a corpse and give it a random torque
			GameObject corpse = Instantiate(shipCorpseObject, transform.position, transform.rotation) as GameObject;
			float torqueForce = 7000.0f;
			corpse.transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(new Vector3(Random.value, Random.value, Random.value).normalized * torqueForce);
			corpse.transform.GetChild(1).GetComponent<Rigidbody>().AddTorque(new Vector3(Random.value, Random.value, Random.value).normalized * (torqueForce / 3));

			GameObject explosionInstance = Instantiate(explosionObject, transform.position, transform.rotation) as GameObject;

			if (isPlayer) {
				Camera.main.transform.parent = null;

				float offsetDistance = 150.0f;
				Vector3 randomOffset = new Vector3(Random.value, Random.value, Random.value).normalized * offsetDistance;
				Vector3 newPosition = Camera.main.transform.position + randomOffset;

				Camera.main.transform.DOMove(newPosition, 2.0f)
					.SetEase(Ease.InOutQuad)
					.OnComplete(() => gameOverText.SetActive(true));

				Camera.main.transform.DOLookAt(explosionInstance.transform.position, 1.0f)
					.SetEase(Ease.InOutQuad);

				HideFlash();
				hud.SetActive(false);
			} else {
				GameObject.FindWithTag("TargetingController").GetComponent<TargetingController>().Remove(gameObject);
				GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawner>().DestroyEnemy();
			}

			Destroy(gameObject);
		}
	}

	private void HideFlash () {
		flashImage.SetActive(false);
	}
}
