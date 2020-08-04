using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBtn : iButton
{

    public GameObject questLog;
    private Logs logs;
    public GameObject powerOff;
    private PowerOffBtn powerOffBtn;

    void Start()
    {
        logs = questLog.GetComponent<Logs>();
        powerOffBtn = powerOff.GetComponent<PowerOffBtn>();
    }

    public override void OnButtonDown()
    {
        logs.RestartQuestLog();
        powerOffBtn.TurnOffTheMachine();
    }
}
