using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableFuel : Collectable
{
    protected override void Action() {
        Boot.Instance.fuelHandler.Refill();
    }
}
