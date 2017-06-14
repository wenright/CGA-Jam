using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackingUI : MonoBehaviour {

	// TODO this should be gathered procedurally
	public Transform player;
	public Transform target;
	public Canvas canvas;
	public GameObject chevron;

	private Rect rect;

	private float xMargin = 30.0f;
	private float yMargin = 20.0f;

	void Start () {
		// This uses the canvas preferred scaling resolution
		rect = new Rect(xMargin, yMargin, 800 - xMargin * 2, 600 - yMargin * 2);
	}

	void Update () {
		if (target == null) {
			return;
		}

		Vector3 coord = Camera.main.WorldToScreenPoint(target.position);

		// TODO if target is behind player, pointer should point towards one side or the other, depending on which is closer

		if (rect.Contains(coord) && coord.z > 0) {
			chevron.SetActive(false);
		} else {
			chevron.SetActive(true);

			chevron.transform.LookAt(target);
		}
	}
}
