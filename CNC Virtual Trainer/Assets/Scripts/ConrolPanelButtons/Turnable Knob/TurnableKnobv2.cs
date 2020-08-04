using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TurnableKnobv2 : iGrabbable
{
    private Hand hand;
    private float startingRotationZ;
    private float handPreviousFrameZRotation;
    private bool grabbed = false;
    private WorkbenchTrigger wBT;
    private float counterPos;
    private float counterNeg;

    protected override void Awake()
    {
        base.Awake();
        wBT = GetComponent<WorkbenchTrigger>();
        counterPos = 0;
        counterNeg = 0;
        useable = true;
    }

    private void Update()
    {
        //if the hand assigned is not null and the OnButtonDown has been called on this class and the machine isnt moving
        if (hand != null && grabbed && !StartupStateManager.isMachineMoving)
        {
            //calculate the difference in rotation between the previous frame and this
            float difference = handPreviousFrameZRotation - hand.transform.rotation.eulerAngles.z;

            //if the difference is between 1 and 300, or -1 and -300 (the 300s are there to compensate for the shift between 0 degrees and 360)
            if (difference > 0.5f && difference < 300)
            {
                //rotate this game object by that amount
                gameObject.transform.Rotate(0, 0, difference);
                hand.TriggerHapticPulse(0.1f, 50, 5);
                //counter used to keep track of how far it has been rotated so that a sound is not played every frame
                counterPos += difference;
                if (counterPos > 20)
                {
                    wBT.MoveObjectPositive();
                    counterPos = 0;
                }

            }
            if (difference < -0.5f && difference > -300)
            {
                gameObject.transform.Rotate(0, 0, difference);
                hand.TriggerHapticPulse(0.1f, 50, 5);
                //counter used to keep track of how far it has been rotated so that a sound is not played every frame
                counterNeg += difference;
                if (counterNeg < -20)
                {
                    wBT.MoveObjectNegative();
                    counterNeg = 0;
                }

            }

            handPreviousFrameZRotation = hand.transform.eulerAngles.z;
        }

    }
    public override void OnButtonDown()
    {
        if (useable)
        {
            startingRotationZ = gameObject.transform.rotation.eulerAngles.z;
            handPreviousFrameZRotation = hand.transform.eulerAngles.z;
            grabbed = true;
        }

    }

    public override void OnButtonUp()
    {
        if (useable)
        {
            grabbed = false;
        }


    }

    public override void SetCurrentHand(Hand hand)
    {
        this.hand = hand;
    }
}
