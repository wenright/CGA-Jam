using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingController : MonoBehaviour {

	public TrackingUI trackingUI;

	private Transform target;
	private List<GameObject> enemies;
	private int i = 0;

	void Start () {
		enemies = new List<GameObject>();
	}
	
	void Update () {
		if (Input.GetButtonDown("CycleTarget")) {
			if (enemies.Count > 0) {
				i = (i + 1) % enemies.Count;

				target = enemies[i].transform;

				trackingUI.target = target;
			}
		}
	}

	public void Add (GameObject enemy) {
		enemies.Add(enemy);
	}

	public void Remove (GameObject enemy) {
		enemies.Remove(enemy);
	}
}
