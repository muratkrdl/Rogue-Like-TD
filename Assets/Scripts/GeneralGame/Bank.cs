using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank Instance;

    public EventHandler<BankEventArgs> OnChangeMoneyAmount;
    public class BankEventArgs : EventArgs
    {
        public int amount;
    }

    [SerializeField] BankUI bankUI;

    [SerializeField] int startMoney;

    int currentMoney;

    void Awake()
    {
        Instance = this;
    }

    void Start() 
    {
        currentMoney = startMoney;
        bankUI.SetMoneyText(currentMoney);
        OnChangeMoneyAmount += Bank_OnChangeMoneyAmount;
    }

    void Bank_OnChangeMoneyAmount(object sender, BankEventArgs e)
    {
        currentMoney += e.amount;
        bankUI.SetMoneyText(currentMoney);
    }

    public bool CanUseMoney(int amount)
    {
        if(currentMoney - amount < 0)
        {
            return false;
        }
        return true;
    }

    void OnDestroy() 
    {
        OnChangeMoneyAmount -= Bank_OnChangeMoneyAmount;
    }

}
