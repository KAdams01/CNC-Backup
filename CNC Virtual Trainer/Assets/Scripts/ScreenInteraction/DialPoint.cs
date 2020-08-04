using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class DialPoint : iButton
{

    public GameObject screenDisplay;
    private NumbersManager numbersManager;
    public GameObject questLog;
    private Logs logs;
    private GameObject highlight;
    private HighlightCreator highlightCreator;

    public override void OnButtonDown()
    {
        if (useable && StartupStateManager.isSequenceDone)
        {
            numbersManager.ClickPoint();
            logs.CompleteQuest(21);
            numbersManager.AddToInput('.');
        }
    }

    void Start()
    {
        numbersManager = screenDisplay.GetComponent<NumbersManager>();
        logs = questLog.GetComponent<Logs>();

        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlight = highlightCreator.CreateHighlightForGameObject(this.gameObject);

    }
}
