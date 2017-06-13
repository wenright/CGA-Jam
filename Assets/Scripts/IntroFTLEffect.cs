using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IntroFTLEffect : MonoBehaviour {

	public CameraShake cameraShake;
	public PlayerMovement playerMovement;
	public Text speedText;

	void Start () {
		playerMovement.enabled = false;

		float duration = 2.0f;

		Camera.main.DOFieldOfView(120.0f, duration)
			.SetEase(Ease.InOutExpo)
			.SetLoops(2, LoopType.Yoyo)
			.OnComplete(() => playerMovement.enabled = true);

		cameraShake.Shake();
	}
	
	void Update () {
		
	}
}
