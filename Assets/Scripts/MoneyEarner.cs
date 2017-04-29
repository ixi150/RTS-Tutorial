using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyEarner : MonoBehaviour
{
    [SerializeField]
    GameObject moneyTextPrefab;

    static MoneyEarner earner;

    private void Awake()
    {
        earner = this;
    }

    public static void ShowMoneyText(Vector3 position, int amount)
    {
        var money = Instantiate(earner.moneyTextPrefab, position, earner.transform.rotation, earner.transform);
        money.GetComponent<MoneyText>().money = amount;
    }
}
