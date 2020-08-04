using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TurnableKnob : iGrabbable
{
    private Hand hand;
    private Quaternion previousFrameRotation;
    private Quaternion startingRotation;
    private bool grabbed = false;

    private void Start()
    {
        previousFrameRotation = new Quaternion(0, 0, 0, 0);
    }

    private void Update()
    {
        if (hand != null && grabbed)
        {
            if (previousFrameRotation.z != hand.transform.rotation.z)
            {
                float newRotation = hand.transform.rotation.eulerAngles.z;
                newRotation = (-hand.transform.rotation.z - -previousFrameRotation.z);
                gameObject.transform.Rotate(0, 0, newRotation);
                previousFrameRotation = Quaternion.Euler(hand.transform.rotation.x, hand.transform.rotation.y, (-hand.transform.rotation.z - -previousFrameRotation.z));
            }
        }

    }
    public override void OnButtonDown()
    {
            grabbed = true;

    }

    public override void OnButtonUp()
    {
            grabbed = false;

        //previousFrameRotation = hand.transform.rotation;
    }

    public override void SetCurrentHand(Hand hand)
    {
        this.hand = hand;
    }
}
