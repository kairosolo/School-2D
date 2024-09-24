using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField] Transform cardHolderTransform;
    [Header("Mouse Enter")]
    [SerializeField] float cardScale = 1.2f;
    [SerializeField] Vector3 hoverRotation = new Vector3(30, -10);
    [SerializeField] float enterTransitionSpeed = .25f;
    [SerializeField] float enterRevertSpeed = .5f;
    [Space]
    [Header("Mouse Exit")]
    [SerializeField] float exitRevertSpeed = .3f;

    private bool flipped = false;
    Sequence enterSequence;

    private void OnMouseEnter()
    {
        if (flipped) return;

        enterSequence = DOTween.Sequence();
        enterSequence.Append(cardHolderTransform.DOScale(cardScale, enterTransitionSpeed));
        cardHolderTransform.DOLocalRotate(hoverRotation, enterTransitionSpeed).SetEase(Ease.OutBack).OnComplete(() => cardHolderTransform.DOLocalRotate(new Vector3(0, 0), enterRevertSpeed).SetEase(Ease.OutSine));
    }

    private void OnMouseExit()
    {
        if (flipped) return;

        cardHolderTransform.DOScale(1f, exitRevertSpeed);
    }

    private void OnMouseDown()
    {
        if (flipped) return;

        flipped = true;
        CardHandler.Instance.FlipCard(this);
    }
}
