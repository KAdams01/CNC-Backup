using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Dial2 : iButton
{

    public GameObject screenDisplay;
    private NumbersManager numbersManager;

    public override void OnButtonDown()
    {
        if (useable && StartupStateManager.isSequenceDone)
        {
            numbersManager.AddToInput('2');
        }
    }

    void Start()
    {
        numbersManager = screenDisplay.GetComponent<NumbersManager>();
    }
}
