using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : iButton
{
    public GameObject screenDisplay;
    private NumbersManager numbersManager;

    void Start()
    {
        numbersManager = screenDisplay.GetComponent<NumbersManager>();
    }

    public override void OnButtonDown()
    {
        if (useable && StartupStateManager.isSequenceDone)
        {
            numbersManager.ClearInput();
        }
    }
}
