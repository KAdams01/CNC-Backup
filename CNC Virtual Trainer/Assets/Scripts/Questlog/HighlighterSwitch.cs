using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlighterSwitch : iButton
{

    public GameObject questLog;
    private Logs logs;

    void Start()
    {
        logs = questLog.GetComponent<Logs>();
    }
    

    public override void OnButtonDown()
    {
        logs.SwitchHighlighters();
    }
}
