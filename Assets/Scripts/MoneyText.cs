using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    public int money;
    [SerializeField]
    Vector3 startOffset, endOffset;
    [SerializeField]
    float duration;
    [SerializeField]
    Color startColor, endColor;

    Vector3 startingPoint;
    Text text;
    float timer;

    private void Awake()
    {
        text = GetComponentInChildren<Text>(true);
        startingPoint = transform.position;
        timer = duration;
    }

    void Update ()
    {
        timer -= Time.deltaTime;
        float percentDone = 1 - timer / duration;
        transform.position = Vector3.Lerp(
            startingPoint + startOffset,
            startingPoint + endOffset,
            percentDone);

        text.color = Color.Lerp(startColor, endColor, percentDone);
        text.text = money + " $";
        if (timer <= 0)
            Destroy(gameObject);
    }
}
