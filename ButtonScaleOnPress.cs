using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace pure_unity_methods
{
    [RequireComponent(typeof(Button))]
    public class ButtonScaleOnPress : MonoBehaviour
    {
        [SerializeField] private float transitionScale = 0.95f;
        [SerializeField] private float transitionTime = 0.1f;
        private readonly Vector3 initialScale = Vector3.one;
        private int tweenID;

        private void Awake()
        {
            tweenID = gameObject.GetInstanceID();
            GetComponent<Button>().onClick.AddListener(ScaleUp);
        }

        private void ScaleUp()
        {
            KillExistingTween();
            transform.DOScale(transitionScale, transitionTime).SetId(tweenID).OnComplete(ScaleDown);
        }

        private void ScaleDown()
        {
            KillExistingTween();
            transform.DOScale(initialScale, transitionTime).SetId(tweenID);
        }

        private void KillExistingTween()
        {
            DOTween.Kill(tweenID);
        }
    }
}
