using UnityEngine;
using DG.Tweening;

public class IntroFTLEffect : MonoBehaviour {

	public CameraShake cameraShake;

	void Start () {
		float duration = 5.0f;

		Camera.main.DOFieldOfView(43.4f, duration)
			.SetEase(Ease.OutQuad);

		cameraShake.Shake();
	}
	
	void Update () {
		
	}
}
