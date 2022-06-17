using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GemPickUp : ICollectable
{
    public static Action AddScoreEvent;

    public void PickUp()
    {
        AddScoreEvent?.Invoke();
    }
}
