using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TeemoAnimation : MonoBehaviour
{
    [SerializeField] private Image teemoImage;
    [SerializeField] float defaultAnimationDuration = .3f;
    private bool zoomed = false;
    private bool fade = false;
    private bool flew = false;
    public void ZoomAnimation()
    {
        if (!zoomed)
        {
            teemoImage.transform.DOScale(0f, defaultAnimationDuration);
        }
        else
        {
            teemoImage.transform.DOScale(1f, defaultAnimationDuration);
        }
        zoomed = !zoomed;
    }
    public void FadeAnimation()
    {
        if (!fade)
        {
            teemoImage.DOFade(0f, defaultAnimationDuration);
        }
        else
        {
            teemoImage.DOFade(1f, defaultAnimationDuration);
        }
        fade = !fade;
    }
    public void BounceAnimation()
    {
        teemoImage.transform.DOMoveY(660, defaultAnimationDuration).SetEase(Ease.InBounce).OnComplete(() => teemoImage.transform.DOMoveY(360, defaultAnimationDuration).SetEase(Ease.OutBounce));
    }
    public void FlyAnimation()
    {
        if (!flew)
        {
            teemoImage.transform.DOMoveY(1500, defaultAnimationDuration).SetEase(Ease.InBack);
        }
        else
        {
            teemoImage.transform.DOMoveY(360, defaultAnimationDuration).SetEase(Ease.OutBack);

        }
        flew = !flew;
    }
}