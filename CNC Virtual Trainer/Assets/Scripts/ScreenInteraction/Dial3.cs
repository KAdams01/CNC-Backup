using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Dial3 : iButton
{

    public GameObject screenDisplay;
    private NumbersManager numbersManager;
    private GameObject highlight;
    private HighlightCreator highlightCreator;

    public override void OnButtonDown()
    {
        if (useable && StartupStateManager.isSequenceDone)
        {
            numbersManager.AddToInput('3');
        }
    }

    void Start()
    {
        numbersManager = screenDisplay.GetComponent<NumbersManager>();
        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlight = highlightCreator.CreateHighlightForGameObject(this.gameObject);
    }
}
