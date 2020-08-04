using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanishLanguageBtn : iButton
{

    public GameObject questLog;
    private Logs logs;

    void Start()
    {
        logs = questLog.GetComponent<Logs>();
        logs.ChangeLanguage("danish");
    }


    public override void OnButtonDown()
    {
        logs.ChangeLanguage("danish");
    }
}
