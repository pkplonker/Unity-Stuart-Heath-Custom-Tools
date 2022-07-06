using System.Collections;
using UnityEngine;

namespace StuartHeathTools
{
	/// <summary>
	///CanvasGroupBase - base class for UI window controllers
	/// </summary>
	[RequireComponent(typeof(CanvasGroup))]
	public abstract class CanvasGroupBase : MonoBehaviour
	{
		[SerializeField] protected CanvasGroup canvasGroup;

		protected virtual void ShowUI(float fadeTime = 0f)
		{
			if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
			if (fadeTime > 0) StartCoroutine(FadeOverTime(0, 1, fadeTime));
			else canvasGroup.alpha = 1f;
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
		}

		protected virtual void HideUI(float fadeTime = 0f)
		{
			if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
			if (fadeTime > 0) StartCoroutine(FadeOverTime(1, 0, fadeTime));
			else canvasGroup.alpha = 0f;
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
		}

		IEnumerator FadeOverTime(float start, float end, float duration)
		{
			for (var t = 0f; t < duration; t += Time.deltaTime)
			{
				var normalizedTime = t / duration;
				canvasGroup.alpha = Mathf.Lerp(start, end, normalizedTime);
				yield return null;
			}
			canvasGroup.alpha = end;
		}
	}
}