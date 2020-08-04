using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : iButton
{

    public GameObject screenDisplay;
    private ArrowKeys arrowKeys;
    public ZeroPointReturn zeroPointReturn;

    public override void OnButtonDown()
    {
        if (useable && StartupStateManager.isSequenceDone)
        {
            if (!arrowKeys.startPanelOn && !arrowKeys.toolPanelOn &&
                arrowKeys.isWritable)
            {

                arrowKeys.x_coordinate.text = "0";
                arrowKeys.y_coordinate.text = "0";
                arrowKeys.z_coordinate.text = "0";
            }
            if (StartupStateManager.bothDoorsClosed && StartupStateManager.emergencyButtonTested)
            {
                zeroPointReturn.ReturnMachineToZeroPoint();
            }
        }
    }

    void Start()
    {
        arrowKeys = screenDisplay.GetComponent<ArrowKeys>();
    }
}
