using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartZeroSet : iButton
{


    public GameObject screenDisplay;
    private ArrowKeys arrowKeys;
    public DialF1 dialF1;
    private ZeroPointManager zeroPointManager;
    private ScreenCoordinates screenCoordinates;
    public GameObject questLog;
    private Logs logs;
    private GameObject highlight;
    private HighlightCreator highlightCreator;




    public int pointPosition;

    public override void OnButtonDown()
    {
        if (useable && StartupStateManager.isSequenceDone)
        {
            if (arrowKeys.isWritable)
            {
                switch (arrowKeys.GetCurrentCoordinate())
                {
                    case 1:
                        dialF1.x_coordinate.text = "" + screenCoordinates.x_coordinate.text;
                        zeroPointManager.MovePointX();
                        arrowKeys.CoordinateIndicatorMoveToRight();
                        break;
                    case 2:
                        dialF1.y_coordinate.text = "" + screenCoordinates.y_coordinate.text;
                        zeroPointManager.MovePointY();
                        arrowKeys.CoordinateIndicatorMoveToRight();
                        break;
                    case 3:
                        dialF1.z_coordinate.text = "" + screenCoordinates.z_coordinate.text;
                        zeroPointManager.MovePointZ();
                        arrowKeys.CoordinateIndicatorMoveToRight();
                        break;
                }
                logs.CompleteQuest(19);
            }
        }
        if(float.Parse(dialF1.x_coordinate.text) != 0f && float.Parse(dialF1.y_coordinate.text) != 0f && float.Parse(dialF1.z_coordinate.text) != 0f)
        {
            logs.CompleteQuest(23);
        }
    }

    void Start()
    {
        arrowKeys = screenDisplay.GetComponent<ArrowKeys>();
        zeroPointManager = GameObject.Find("MachineZeroPoint").GetComponent<ZeroPointManager>();
        screenCoordinates = screenDisplay.GetComponent<ScreenCoordinates>();
        pointPosition = 4;
        logs = questLog.GetComponent<Logs>(); highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlight = highlightCreator.CreateHighlightForGameObject(this.gameObject);
    }

}
