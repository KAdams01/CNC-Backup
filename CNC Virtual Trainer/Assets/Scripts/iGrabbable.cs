using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public abstract class iGrabbable : iButton
{
    public abstract void SetCurrentHand(Hand hand);
    public abstract override void OnButtonDown();
    public abstract void OnButtonUp();
}