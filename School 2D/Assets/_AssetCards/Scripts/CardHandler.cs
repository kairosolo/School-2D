using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardHandler : MonoBehaviour
{
    public static CardHandler Instance;
    [SerializeField] private List<Card> cardList;
    [SerializeField] private Image background;
    [SerializeField] private TMP_Text youWinText;

    [SerializeField] private Vector3 rotationValue = new Vector3(0, 180, 0);

    [SerializeField] private float rotationTransitionSpeed = .5f;
    [SerializeField] private int flipped = 0;

    public Sequence cardSequence;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
    }

    public void FlipCard(Card card)
    {
        flipped++;
        cardSequence = DOTween.Sequence();
        cardSequence.Append(card.transform.DOScale(1.1f, 0.25f).SetEase(Ease.OutElastic).OnComplete(() => card.transform.DOScale(1f, 0.25f)));
        cardSequence.Join(card.transform.DORotate(rotationValue, rotationTransitionSpeed).SetEase(Ease.InSine));
        cardSequence.Join(Camera.main.transform.DOShakeRotation(.5f, 2, 10, 10, true));
        if (flipped >= 5)
        {
            AssembleExodia();
        }
    }

    public void AssembleExodia()
    {
        float strength = .75f;
        int vibrato = 10;
        float duration = 1f;
        Sequence exodiaSequence = DOTween.Sequence();
        //Right Arm
        exodiaSequence.Append(cardList[1].transform.DOMove(new Vector3(-2, 1.2f), duration));
        exodiaSequence.Join(cardList[1].transform.DORotate(new Vector3(0, 180, 7), duration));
        exodiaSequence.Join(Camera.main.transform.DOShakeRotation(duration, strength, vibrato, 10, false));
        //Left Arm
        exodiaSequence.Append(cardList[2].transform.DOMove(new Vector3(2, 1.2f), duration));
        exodiaSequence.Join(cardList[2].transform.DORotate(new Vector3(0, 180, -7), duration));
        exodiaSequence.Join(Camera.main.transform.DOShakeRotation(duration, strength, vibrato, 10, false));

        //Right Leg
        exodiaSequence.Append(cardList[3].transform.DOMove(new Vector3(-1.6f, -2f), duration));
        exodiaSequence.Join(cardList[3].transform.DORotate(new Vector3(0, 180, 3), duration));
        exodiaSequence.Join(Camera.main.transform.DOShakeRotation(duration, strength, vibrato, 10, false));

        //Left Leg
        exodiaSequence.Append(cardList[4].transform.DOMove(new Vector3(1.6f, -2f), duration));
        exodiaSequence.Join(cardList[4].transform.DORotate(new Vector3(0, 180, -3), duration));
        exodiaSequence.Join(Camera.main.transform.DOShakeRotation(duration, strength, vibrato, 10, false));

        //Ending
        exodiaSequence.Append(background.DOFade(1, 2));
        exodiaSequence.Append(youWinText.DOFade(1, 2));
    }
}