using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingController : MonoBehaviour {

	public AudioClip nextTargetSound;
	public AudioSource audioSource;

	public TrackingUI trackingUI;
	public GameObject targetingCamera;

	private Transform target;
	private List<GameObject> enemies;
	private int i = 0;
	private Vector3 cameraOffset = new Vector3(25, 50, -24);

	void Start () {
		enemies = new List<GameObject>();
	}
	
	void Update () {
		if (Input.GetButtonDown("CycleTarget")) {
			if (enemies.Count > 0) {
				audioSource.PlayOneShot(nextTargetSound, 0.2f);

				if (target != null) {
					target.gameObject.GetComponent<LeadAngle>().HideLead();
				}

				i = (i + 1) % enemies.Count;

				target = enemies[i].transform;

				trackingUI.target = target;

				target.gameObject.GetComponent<LeadAngle>().ShowLead();
			}
		}

		if (target == null) {
			targetingCamera.SetActive(false);
		} else {
			targetingCamera.SetActive(true);

			targetingCamera.transform.position = target.position + cameraOffset;
			targetingCamera.transform.LookAt(target.position);
		}
	}

	public void Add (GameObject enemy) {
		enemies.Add(enemy);
	}

	public void Remove (GameObject enemy) {
		enemies.Remove(enemy);
	}
}
