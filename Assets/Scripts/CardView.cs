using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text gemsConstText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image portraitSprite;

    [SerializeField] private CardInformation cardInformation;

    void Start()
    {
        ChargeValues();
    }

    private void ChargeValues()
    {
        lifeText.text = cardInformation.Life.ToString();
        damageText.text = cardInformation.Damage.ToString();
        nameText.text = cardInformation.Name;
        gemsConstText.text = cardInformation.GemsCost.ToString();
        descriptionText.text = cardInformation.Description.ToString();
        portraitSprite.sprite = cardInformation.Portrait;
    }

}
