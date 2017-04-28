using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : UnitButton
{

    public void SpawnBuilding()
    {
        CameraControl.SpawnBuilding(spawnPrefab);
    }

    public override void SpawnUnit()
    {
        //base.SpawnUnit();
    }
}
