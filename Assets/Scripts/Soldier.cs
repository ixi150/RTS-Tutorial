using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Unit, ISelectable
{
    public void SetSelected(bool selected)
    {
        healthBar.gameObject.SetActive(selected);
    }
}
