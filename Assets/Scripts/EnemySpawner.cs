using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour {

	public Rigidbody playerRb;
	public GameObject[] enemies;
	public static int maxToSpawn = 1;
	public int startDelay = 5;
	public Text enemiesText;
	public Text warpText;
	public Text upgradeText;

	private int numToSpawn;
	private int numLeft = 0;

	void Start () {
		numToSpawn = Random.Range(1, maxToSpawn);
		Invoke("StartSpawning", startDelay);	
	}

	private void StartSpawning () {
		enemiesText.gameObject.SetActive(true);
		if (numToSpawn == 1) {
			enemiesText.text = "1 hostile detected!";
		} else {
			enemiesText.text = numToSpawn + " enemies detected!";			
		}

		Invoke("HideEnemiesText", 1.0f);

		for (int i = 0; i < numToSpawn; i++) {
			SpawnEnemy(enemies[Random.Range(0, enemies.Length - 1)]);
		}	
	}

	private void SpawnEnemy (GameObject enemy) {
		numLeft++;

		float offsetDistance = 1000.0f;
		Vector3 randomOffset = new Vector3(Random.value, Random.value, Random.value).normalized * offsetDistance;
		GameObject enemyInstance = Instantiate(enemy, transform.position + randomOffset, Quaternion.identity) as GameObject;
		GameObject.FindWithTag("TargetingController").GetComponent<TargetingController>().Add(enemyInstance);
	}

	public void DestroyEnemy () {
		numLeft--;
		PlayerUpgrades.kills++;

		if (numLeft == 0) {
			// Apply upgrades to player
			int type = Random.Range(0, 3);
			switch (type) {
				case 0:
					PlayerUpgrades.health += 25;
					upgradeText.text = "+HEALTH";
					break;
				case 1:
					PlayerUpgrades.damage += 12;
					upgradeText.text = "+DAMAGE";
					break;
				case 2:
					PlayerUpgrades.ROF *= 0.9f;
					upgradeText.text = "+FIRE RATE";
					break;
				default:
					break;
			}

			maxToSpawn = (int) ((maxToSpawn + 1) * 1.25f);
			warpText.gameObject.SetActive(true);
			Invoke("LoadNextScene", 2.0f);

			playerRb.angularVelocity = Vector3.zero;
			playerRb.DORotate(Vector3.zero, 2f).SetEase(Ease.InOutQuad);
			playerRb.gameObject.GetComponent<PlayerMovement>().enabled = false;
		}
	}

	private void LoadNextScene () {
		PlayerUpgrades.waves++;
		SceneManager.LoadScene("game");
	}

	private void HideEnemiesText () {
		enemiesText.gameObject.SetActive(false);
	}
}
