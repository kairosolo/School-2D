using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TeemoAnimation : MonoBehaviour
{
    [SerializeField] private Image teemoImage;
    [SerializeField] float defaultAnimationDuration = .3f;
    private bool zoomed = false;
    private bool fade = false;
    private bool flew = false;
    private bool flipped = false;
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
    public void FlipAnimation()
    {
        if (!flipped)
        {
            teemoImage.transform.DORotate(new Vector3(0,90,0), defaultAnimationDuration).SetEase(Ease.InQuart);
        }
        else
        {
            teemoImage.transform.DORotate(new Vector3(0, 0, 0), defaultAnimationDuration).SetEase(Ease.OutQuart);


        }
        flipped = !flipped;
    }
    public void BounceAnimation()
    {
        teemoImage.transform.DOMoveY(660, defaultAnimationDuration).SetEase(Ease.InBounce).OnComplete(() => teemoImage.transform.DOMoveY(360, defaultAnimationDuration).SetEase(Ease.OutBounce));
    }
    public void ShakeAnimation()
    {
        teemoImage.transform.DOShakePosition(1f, 50);
    }
    public void FlashAnimation()
    {
        Sequence flashSequence = DOTween.Sequence();
        float flashDuration = .2f;
        flashSequence.Append(teemoImage.DOFade(0f, flashDuration).SetEase(Ease.OutQuint));
        flashSequence.Append(teemoImage.DOFade(1f, flashDuration).SetEase(Ease.OutQuint));
        flashSequence.Append(teemoImage.DOFade(0f, flashDuration).SetEase(Ease.OutQuint));
        flashSequence.Append(teemoImage.DOFade(1f, flashDuration).SetEase(Ease.OutQuint));
    }
    public void TadaAnimation()
    {
        Sequence tadaSequence = DOTween.Sequence();

        float tadaDuration = .1f;
        tadaSequence.Append(teemoImage.transform.DOScale(.5f, tadaDuration));
        tadaSequence.Append(teemoImage.transform.DOScale(8f, tadaDuration).SetEase(Ease.InQuart));

        tadaSequence.Append(teemoImage.transform.DORotate(new Vector3(0, 0, -8), tadaDuration));
        tadaSequence.Append(teemoImage.transform.DORotate(new Vector3(0, 0, 8), tadaDuration));
        tadaSequence.Append(teemoImage.transform.DORotate(new Vector3(0, 0, -8), tadaDuration));
        tadaSequence.Append(teemoImage.transform.DORotate(new Vector3(0, 0, 8), tadaDuration));
        tadaSequence.Append(teemoImage.transform.DORotate(new Vector3(0, 0, -8), tadaDuration));
        tadaSequence.Append(teemoImage.transform.DORotate(new Vector3(0, 0, 8), tadaDuration));
        tadaSequence.Append(teemoImage.transform.DORotate(new Vector3(0, 0, -8), tadaDuration));
        tadaSequence.Append(teemoImage.transform.DORotate(new Vector3(0, 0, 8), tadaDuration));
        tadaSequence.Append(teemoImage.transform.DORotate(new Vector3(0, 0, 0), tadaDuration));
        tadaSequence.Append(teemoImage.transform.DOScale(1f, tadaDuration).SetEase(Ease.OutQuart));

    }
}