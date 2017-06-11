using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackingUI : MonoBehaviour {

	// TODO this should be gathered procedurally
	public Transform player;
	public Transform target;
	public Canvas canvas;
	public Image image;
	public RectTransform imagePosition;

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

		if (rect.Contains(coord)) {
			image.enabled = false;
		} else {
			image.enabled = true;
			coord = new Vector3(Mathf.Clamp(coord.x, rect.xMin, rect.xMax), Mathf.Clamp(coord.y, rect.yMin, rect.yMax), 0);
			imagePosition.anchoredPosition = coord;

			// Quaternion rotation = Quaternion.LookRotation(target.position - player.position);
			// imagePosition.eulerAngles = new Vector3(imagePosition.eulerAngles.x, imagePosition.eulerAngles.y, imagePosition.eulerAngles.y + rotation.eulerAngles.z);
			// imagePosition.localEulerAngles = new Vector3(0, 0, rotation.eulerAngles.z);
		}
	}
}
