using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FishingLongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] Player player;

	private bool pointerDown;
	private float pointerDownTimer;

	[SerializeField]
	private float requiredHoldTime;

	public UnityEvent onLongClick;

	[SerializeField]
	private Slider fill;

	public void OnPointerDown(PointerEventData eventData)
	{
		pointerDown = true;
		//shakeInstance = FindObjectOfType<EZCameraShake.CameraShaker>().StartShake(0.2f, 5, 2f);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Reset();
		pointerDown = false;
		//shakeInstance.StartFadeOut(2);
	}

	private void Update()
	{
		if (pointerDown)
		{
			pointerDownTimer += Time.deltaTime;
			requiredHoldTime = player.GetAttribute("fishTime").value;
			if (pointerDownTimer >= requiredHoldTime)
			{
				if (onLongClick != null)
					onLongClick.Invoke();

				Reset();
			}
			fill.value = pointerDownTimer / requiredHoldTime;
		}
	}

	private void Reset()
	{
		pointerDownTimer = 0;
		fill.value = 0;
	}

}


