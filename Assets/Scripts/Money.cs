using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    static Money money;

    [SerializeField]
    ulong amount, maxAmount = 1000000;

    Text text;

    private void Awake()
    {
        money = this;
        text = GetComponentInChildren<Text>(true);
    }

    void Update()
    {
        text.text = amount + " $";
    }

    public static bool TryAddMoney(uint value)
    {
        money.amount += value;
        if (money.amount > money.maxAmount)
        {
            money.amount = money.maxAmount;
            return false;
        }
        return true;
    }

    public static bool TrySpendMoney(uint value)
    {
        if (money.amount < value)
        {
            return false;
        }
        money.amount -= value;
        return true;
    }

    public static bool HaveEnoughMoney(uint value)
    {
        return value <= money.amount;
    }
}
