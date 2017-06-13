using UnityEngine;
using DG.Tweening;

public class IntroFTLEffect : MonoBehaviour {

	public CameraShake cameraShake;

	void Start () {
		float duration = 2.0f;

		Camera.main.DOFieldOfView(120.0f, duration)
			.SetEase(Ease.OutExpo)
			.SetLoops(2, LoopType.Yoyo);

		cameraShake.Shake();
	}
	
	void Update () {
		
	}
}
