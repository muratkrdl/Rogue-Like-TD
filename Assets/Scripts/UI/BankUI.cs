using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BankUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyAmountText;

    public void SetMoneyText(int amount)
    {
        moneyAmountText.text = amount.ToString();
    }

}
