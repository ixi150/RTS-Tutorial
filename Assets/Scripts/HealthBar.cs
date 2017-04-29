using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    const string WORLD_CANVAS = "World Canvas";

    [SerializeField]
    Vector3 offset;

    Slider slider;
    Unit unit;
    Transform parent;
    

    private void Awake()
    {
        slider = GetComponent<Slider>();
        parent = transform.parent;
        unit = GetComponentInParent<Unit>();
        var canvas = GameObject.FindGameObjectWithTag(WORLD_CANVAS);
        if (canvas) transform.SetParent(canvas.transform);
    }

    private void Update()
    {
        if (!parent)
        {
            Destroy(gameObject);
            return;
        }
        if (unit)
            slider.value = unit.HealthPercent;
        transform.position = parent.position + offset;
    }
}
