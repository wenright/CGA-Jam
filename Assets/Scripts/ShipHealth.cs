using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShipHealth : MonoBehaviour {

	public int maxHealth = 100;
	private int health;

	public bool isPlayer = false;
	public bool isCorpse = false;

	public GameObject flashImage;

	public GameObject explosionObject;
	public GameObject shipCorpseObject;

	public Slider healthBar;

	void Start () {
		health = maxHealth;
	}
	
	public void Hit (int damage) {
		health -= damage;

		if (isPlayer && flashImage != null) {
			flashImage.SetActive(true);
			Invoke("HideFlash", 0.05f);

			if (healthBar != null) {
				healthBar.value = 1.0f * health / maxHealth;
			}
		}

		if (health <= 0) {
			GameObject explosionInstance = Instantiate(explosionObject, transform.position, transform.rotation) as GameObject;

			if (isCorpse) {
				Destroy(gameObject);
				return;
			}

			// Instantiate a corpse and give it a random torque
			GameObject corpse = Instantiate(shipCorpseObject, transform.position, transform.rotation) as GameObject;
			float torqueForce = 7000.0f;
			corpse.transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(new Vector3(Random.value, Random.value, Random.value).normalized * torqueForce);
			corpse.transform.GetChild(1).GetComponent<Rigidbody>().AddTorque(new Vector3(Random.value, Random.value, Random.value).normalized * (torqueForce / 3));

			if (isPlayer) {
				GameObject.FindWithTag("GameController").GetComponent<GameController>().GameOver(explosionInstance.transform.position);
			} else {
				GameObject.FindWithTag("TargetingController").GetComponent<TargetingController>().Remove(gameObject);
				GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawner>().DestroyEnemy();
			}

			Destroy(gameObject);
		}
	}

	public float GetHealthPercentage () {
		return 1.0f * health / maxHealth;
	}

	private void HideFlash () {
		flashImage.SetActive(false);
	}
}
