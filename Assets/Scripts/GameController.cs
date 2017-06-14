using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameController : MonoBehaviour {

	public GameObject flashImage;
	public GameObject gameOverText;
	public Text scoreText;
	public GameObject hud;

	private bool gameIsOver = false;

	void Update () {
		if (Input.GetKeyDown("r") && gameIsOver) {
			RestartGame();
		}
	}

	public void GameOver (Vector3 lookAtTarget) {
		PositionCamera(lookAtTarget);

		// show score
		scoreText.text = "wave: " + PlayerUpgrades.waves + "\nkills: " + PlayerUpgrades.kills;

		gameIsOver = true;
	}

	private void PositionCamera (Vector3 lookAtTarget) {
		Camera.main.transform.parent = null;

		float offsetDistance = 150.0f;
		Vector3 randomOffset = new Vector3(Random.value, Random.value, Random.value).normalized * offsetDistance;
		Vector3 newPosition = Camera.main.transform.position + randomOffset;

		Camera.main.transform.DOMove(newPosition, 2.0f)
			.SetEase(Ease.InOutQuad)
			.OnComplete(() => gameOverText.SetActive(true));

		Camera.main.transform.DOLookAt(lookAtTarget, 1.0f)
			.SetEase(Ease.InOutQuad);

		HideFlash();
		hud.SetActive(false);
	}

	private void RestartGame () {
		// Set all changed variables back to default
		EnemySpawner.maxToSpawn = 1;

		PlayerUpgrades.ROF = 0.15f;
		PlayerUpgrades.damage = 25;
		PlayerUpgrades.health = 150;

		PlayerUpgrades.kills = 0;
		PlayerUpgrades.waves = 0;

		// Reload scene
		SceneManager.LoadScene("game");
	}

	private void HideFlash () {
		flashImage.SetActive(false);
	}

}
