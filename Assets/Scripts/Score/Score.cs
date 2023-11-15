using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score //TODO: add showing of score in real time. maybe not here
{
    [NonSerialized]public static int score;

    public Score() {
        score = 0;
    }
}
