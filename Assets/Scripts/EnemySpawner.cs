﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemies;
	public static int numToSpawn = 2;
	public int startDelay = 5;

	private int numLeft = 0;

	void Start () {
		Invoke("StartSpawning", startDelay);	
	}

	private void StartSpawning () {
		for (int i = 0; i < numToSpawn; i++) {
			SpawnEnemy(enemies[Random.Range(0, enemies.Length - 1)]);
		}	
	}

	private void SpawnEnemy (GameObject enemy) {
		numLeft++;

		float offsetDistance = 10.0f;
		Vector3 randomOffset = new Vector3(Random.value, Random.value, Random.value).normalized * offsetDistance;
		GameObject enemyInstance = Instantiate(enemy, transform.position + randomOffset, Quaternion.identity) as GameObject;
		GameObject.FindWithTag("TargetingController").GetComponent<TargetingController>().Add(enemyInstance);
	}

	public void DestroyEnemy () {
		numLeft--;

		if (numLeft == 0) {
			numToSpawn *= 2;
			Invoke("LoadNextScene", 2.0f);
		}
	}

	private void LoadNextScene () {
		SceneManager.LoadScene("game");
	}
}
