using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad7YAxis : iButton
{
    private WorkbenchTrigger wbTrigger;
    private TipManager tipManager;
    private BoxcastTest boxcast;
    private GameObject highlight;
    private HighlightCreator highlightCreator;

    protected override void Awake()
    {
        base.Awake();
        wbTrigger = GameObject.Find("TurnableKnob").GetComponent<WorkbenchTrigger>();
        tipManager = GameObject.FindObjectOfType<TipManager>();
        boxcast = GameObject.FindObjectOfType<BoxcastTest>();
    }

    void Start()
    {
        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlight = highlightCreator.CreateHighlightForGameObject(this.gameObject);
    }

    public override void OnButtonDown()
    {
        if (useable && StartupStateManager.isSequenceDone && boxcast.inserted)
        {
            wbTrigger.SetAxis("z");
            tipManager.SetHorizontalTip();
        }

    }
}
