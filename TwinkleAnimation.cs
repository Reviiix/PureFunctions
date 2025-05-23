using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class TwinkleAnimation : MonoBehaviour
{
    [SerializeField] private float firstTime = 1; //Exposed fields to allow for different twinkles.
    [SerializeField] private float repeatInterval = 3;
    [SerializeField] private float duration = 2;
    [SerializeField] private int rotationAngle = 60;
    private const Ease In = Ease.InQuad;
    private const Ease Out = Ease.OutQuad;
    private readonly Vector2 startScale = Vector2.one;
    private Vector3 startRotation;
    private Sequence tween;
    
    
    private void OnEnable()
	{
        startRotation = transform.localEulerAngles;
        transform.localScale = Vector2.zero;
        InvokeRepeating(nameof(Animate), firstTime, repeatInterval);
    }

    private void OnDisable()
    {
        CancelAnimation();
    }

    private void OnDestroy()
    {
        CancelAnimation();
    }

    private void Animate()
    {
        if (!isActiveAndEnabled) return;
        var halfDuration = duration / 2;
        
        tween = DOTween.Sequence();
        tween.Append(transform.DOScale(startScale, halfDuration).SetEase(In));
        tween.Insert(0, transform.DORotate(new Vector3(0, 0, startRotation.z + rotationAngle), duration).SetEase(In));
        tween.Insert(halfDuration, transform.DOScale(0, halfDuration).SetEase(Out));
        tween.AppendCallback(OnAnimateComplete);
        tween.OnKill(() =>
        {
            tween = null;
        });
        tween.Play();
    }
    
	private void OnAnimateComplete()
    {
        transform.eulerAngles = startRotation;
    }
    
    private void CancelAnimation()
    {
        if (ShouldCancel())
        {
            tween.Kill();
        }
        CancelInvoke();
    }

    private bool ShouldCancel()
    {
        return tween != null && tween.IsActive() && tween.IsPlaying();
    }
}
