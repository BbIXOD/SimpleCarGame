using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMoney : Collectable
{
    [SerializeField]private int value;

    protected override void Action()
    {
        Score.score += value;
    }
}
