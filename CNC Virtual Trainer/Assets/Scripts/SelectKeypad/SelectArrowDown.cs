using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectArrowDown : iButton
{

    public GameObject screenDisplay;
    private ArrowKeys arrowKeys;

    private GameObject highlight;
    private HighlightCreator highlightCreator;

    public override void OnButtonDown()
    {
        if (useable && StartupStateManager.isSequenceDone)
        {
            if (!arrowKeys.startPanelOn)
            {
                arrowKeys.ToolRowIndicatorMoveDown();
                arrowKeys.WorkRowIndicatorMoveDown();
            }
        }
    }

    void Start()
    {
        arrowKeys = screenDisplay.GetComponent<ArrowKeys>();
        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlight = highlightCreator.CreateHighlightForGameObject(this.gameObject);

    }


    void Update()
    {
        
    }
}
