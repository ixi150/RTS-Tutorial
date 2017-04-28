using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitButton : MonoBehaviour
{
    public void SpawnUnit(GameObject prefab)
    {
        CameraControl.SpawnUnits(prefab);
    }
}
