using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerOnBtn : iButton
{
    private GameObject computerScreen;
    private List<iButton> allButtons;

    public Material startScreen;
    public Renderer rend;

    public GameObject panelLight;
    private Renderer lightRenderer;
    public Material red;

    public GameObject questLog;
    private Logs logs;

    private HighlightCreator highlightCreator;
    private GameObject highlight;

    private LightController lightController;


    protected override void Awake()
    {
        base.Awake();
        computerScreen = GameObject.Find("ScreenDisplay");
        allButtons = new List<iButton>();
        foreach (iButton b in Resources.FindObjectsOfTypeAll<iButton>())
        {
            allButtons.Add(b);
        }
        lightRenderer = panelLight.GetComponent<Renderer>();
        logs = questLog.GetComponent<Logs>();
        lightController = GameObject.FindObjectOfType<LightController>();
    }

    private void Start()
    {
        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlight = highlightCreator.CreateHighlightForGameObject(this.gameObject);
    }

    public override void OnButtonDown()
    {
        if (!StartupStateManager.powerButtonOnTested)
        {
            //logic for turning on machine
            StartupStateManager.powerButtonOnTested = true;
            logs.CompleteQuest(2);
            computerScreen.SetActive(true);
            foreach (iButton b in allButtons)
            {
                b.SetButtonAsUseable();
            }
            lightRenderer.material = red;
            rend.material = startScreen;
            lightController.TurnLightsOn();
        }
    }


}
