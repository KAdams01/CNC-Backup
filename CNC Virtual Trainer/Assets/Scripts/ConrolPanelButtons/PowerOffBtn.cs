using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerOffBtn : iButton
{
    private GameObject computerScreen;
    public bool powerOff;
    private List<iButton> allButtons;

    public GameObject panelLight;
    private Renderer lightRenderer;
    public Material off;
    private ArrowKeys arrowKeys;

    public GameObject handleJog;
    private WorkbenchTrigger workbenchTrigger;

    public Text inputField;
    private LightController lightController;

    protected override void Awake()
    {
        base.Awake();
        powerOff = false;
        computerScreen = GameObject.Find("ScreenDisplay");
        allButtons = new List<iButton>();
        foreach (iButton b in Resources.FindObjectsOfTypeAll<iButton>())
        {
            allButtons.Add(b);
        }
        lightRenderer = panelLight.GetComponent<Renderer>();
        arrowKeys = computerScreen.GetComponent<ArrowKeys>();
        workbenchTrigger = handleJog.GetComponent<WorkbenchTrigger>();
        lightController = GameObject.FindObjectOfType<LightController>();
    }

    public override void OnButtonDown()
    {
        if (useable)
        {
            TurnOffTheMachine();
        }
    }

    public void TurnOffTheMachine()
    {//logic for turning off machine
        computerScreen.SetActive(false);
        powerOff = true;
        foreach (iButton b in allButtons)
        {
            b.SetButtonAsUnusable();
        }
        lightRenderer.material = off;
        arrowKeys.TurnOnStartPanel();
        StartupStateManager.powerButtonOnTested = false;
        StartupStateManager.emergencyButtonTested = false;
        StartupStateManager.bothDoorsClosed = false;
        StartupStateManager.powerUpButtonTested = false;
        StartupStateManager.isSequenceDone = false;
        workbenchTrigger.ResetPositionWithoutMoving();
        inputField.text = "";
        lightController.TurnLightsOff();
    }
}
