using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    const string HP_CANVAS = "HP Canvas";

    [SerializeField]
    Vector3 offset;

    Slider slider;
    Unit unit;
    Transform parent;
    Transform cameraTransform;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        parent = transform.parent;
        unit = GetComponentInParent<Unit>();
        var canvas = GameObject.FindGameObjectWithTag(HP_CANVAS);
        if (canvas) transform.SetParent(canvas.transform);
        cameraTransform = Camera.main.transform;
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
        transform.LookAt(cameraTransform);
        var rotation = transform.localEulerAngles;
        rotation.y = -180;
        transform.localEulerAngles = rotation;
    }


}
