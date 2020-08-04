using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpBtt : iButton
{

    public GameObject panelLight;
    private Renderer lightRenderer;
    public Material green;
    public ZeroPointReturn zeroPointReturn;
    public GameObject screenDisplay;
    private ScreenCoordinates screenCoordinates;
    public GameObject questLog;
    private Logs logs;
    private GameObject highlight;
    private HighlightCreator highlightCreator;

    protected override void Awake()
    {
        base.Awake();
        lightRenderer = panelLight.GetComponent<Renderer>();
        screenCoordinates = screenDisplay.GetComponent<ScreenCoordinates>();
        logs = questLog.GetComponent<Logs>();
    }

    void Start()
    {
        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlight = highlightCreator.CreateHighlightForGameObject(this.gameObject);
    }

    public override void OnButtonDown()
    {
        if (useable && StartupStateManager.bothDoorsClosed && StartupStateManager.emergencyButtonTested)
        {
            lightRenderer.material = green;
            StartupStateManager.powerUpButtonTested = true;
            zeroPointReturn.ReturnMachineToZeroPoint();
            StartupStateManager.isSequenceDone = true;
            screenCoordinates.StartACoroutine();
            logs.CompleteQuest(5);
        }
    }
}
