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

		// TODO if target is behind player, pointer should point towards one side or the other, depending on which is closer

		if (rect.Contains(coord) && coord.z > 0) {
			image.enabled = false;
		} else {
			image.enabled = true;

			float scalar = 1.0f;
			if (coord.z < 0) {
				scalar = 400.0f;
			}

			coord = new Vector3(Mathf.Clamp(coord.x * scalar, rect.xMin, rect.xMax), Mathf.Clamp(coord.y * scalar, rect.yMin, rect.yMax), 0);
			imagePosition.anchoredPosition = coord;

			Vector3 projected = Vector3.ProjectOnPlane((target.position - canvas.transform.position).normalized, canvas.transform.forward);
			imagePosition.localRotation = Quaternion.Euler(0, 0, Vector3.Angle(projected, canvas.transform.up));
		}
	}
}
