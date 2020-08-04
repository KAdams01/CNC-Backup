using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class EmergencyButtonTrigger : iButton
{
    //SteamVR action that needs to be set to the trigger of the right controller
    //component containing logic for swapping buttons
    private SwapButton swapButton;
    // Start is called before the first frame update

    public GameObject questLog;
    private Logs logs;

    protected override void Awake()
    {
        base.Awake();
        swapButton = GetComponentInParent<SwapButton>();
        logs = questLog.GetComponent<Logs>();
    }
    //Collision logic to see if the hand is in contact with the button. Stops the button being reset from a distance.


    public override void OnButtonDown()
    {
        swapButton.SwapEmergencyButtons();
        StartupStateManager.powerUpButtonTested = false;
        StartupStateManager.isSequenceDone = false;
        logs.CompleteQuest(3);
    }
}
