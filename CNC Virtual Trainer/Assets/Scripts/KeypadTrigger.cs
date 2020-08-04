using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class KeypadTrigger : MonoBehaviour
{
    [HideInInspector]
    public string axisChosen;
    [HideInInspector]
    public float speedChosen;

    private WorkbenchTrigger workbenchTrigger;


    private SoundManager soundManager;

    void Start()
    {
        axisChosen = "notChosen";
        speedChosen = 0.0001f;
        workbenchTrigger = GetComponent<WorkbenchTrigger>();
        soundManager = SoundManager._instance;
    }

    public void SetAxis(string keyName)
    {
        switch (keyName)
        {
            case "x_key":
                axisChosen = "x";
                soundManager.PlayClickSound();
                break;
            case "y_key":
                axisChosen = "y";
                soundManager.PlayClickSound();
                break;
            case "z_key":
                axisChosen = "z";
                soundManager.PlayClickSound();
                break;
        }
    }

    public void SetSpeed(string keyName)
    {
            switch (keyName)
            {
                case "0001_key":
                    speedChosen = 0.0001f;
                    soundManager.PlayClickSound();
                break;
                case "001_key":
                    speedChosen = 0.001f;
                    soundManager.PlayClickSound();
                break;
                case "01_key":
                    speedChosen = 0.01f;
                    soundManager.PlayClickSound();
                break;
            }
    }

    /*public void ResetPosition()
    {
        if (buttonB.GetStateDown(SteamVR_Input_Sources.RightHand) || VIVEtrigger.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            workbenchTrigger.ResetPosition();
            workbenchTrigger.clickSoundsSource.PlayOneShot(clickSound);
        }
    }*/

    public string GetAxis()
    {
        return axisChosen;
    }

    public float GetSpeed()
    {
        return speedChosen;
    }

}
