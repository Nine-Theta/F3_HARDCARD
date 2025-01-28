using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Bus design pattern. Contains all the events that can be Publish.
/// </summary>
public static class Bus
{
    public static readonly BusEvent Sync = new BusEvent();
}

public class BubbleShot : EventArgs
{ }

public class BuoyPicked : EventArgs
{ }
