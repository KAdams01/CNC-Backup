using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialMinus : iButton
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
            numbersManager.ClickMinus();
            logs.CompleteQuest(20);
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
