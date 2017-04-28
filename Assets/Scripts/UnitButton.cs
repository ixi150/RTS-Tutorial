using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    [SerializeField]
    protected GameObject spawnPrefab;

    Button button;
    Text text;

    private void Awake()
    {
        text = GetComponentInChildren<Text>(true);
        button = GetComponentInChildren<Button>(true);

        Buyable buyable;
        if (spawnPrefab && (buyable = spawnPrefab.GetComponent<Buyable>()))
            button.image.sprite = buyable.icon;
    }

    private void Update()
    {
        Buyable buyable;
        if (spawnPrefab && (buyable = spawnPrefab.GetComponent<Buyable>()))
        {
            text.text = buyable.cost + " $";
            button.interactable = Money.HaveEnoughMoney(buyable.cost);
        }
    }

    public virtual void SpawnUnit()
    {
        CameraControl.SpawnUnits(spawnPrefab);
    }
}
