using System;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank Instance;

    public EventHandler<BankEventArgs> OnChangeMoneyAmount;
    public EventHandler<BankEventArgs> OnPermanentMoneyGained;
    public class BankEventArgs : EventArgs
    {
        public int amount;
    }

    [SerializeField] BankUI bankUI;

    [SerializeField] int startMoney;

    int currentMoney;

    int gainedPermanentMoney = 0;

    public int GetGainedPermanentMoney
    {
        get => gainedPermanentMoney;
    }

    void Awake()
    {
        Instance = this;
    }

    void Start() 
    {
        currentMoney = startMoney;
        bankUI.SetMoneyText(currentMoney);
        OnChangeMoneyAmount += Bank_OnChangeMoneyAmount;
        OnPermanentMoneyGained += Bank_OnPermanentMoneyGained;
    }

    void Bank_OnPermanentMoneyGained(object sender, BankEventArgs e)
    {
        gainedPermanentMoney += e.amount;
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
        OnPermanentMoneyGained -= Bank_OnPermanentMoneyGained;
    }

}
