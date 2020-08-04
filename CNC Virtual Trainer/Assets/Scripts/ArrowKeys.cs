using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowKeys : MonoBehaviour
{

    public Material startPanel, toolPanel, workPanel;
    private Renderer rend;
    [HideInInspector] public bool startPanelOn, toolPanelOn;
    public RawImage topBarIndicator, toolRowIndicator, workRowIndicator, coordinateIndicator;
    private int countTopBar, countToolRow, countWorkRow, countCoordinate;

    public bool isWritable;

    public Text x_coordinate, y_coordinate, z_coordinate, inputField, minusPlaceholder;

    private Vector3 TBIOriginalPos, TRIOriginalPos, WRIOriginalPos, CIOriginalPos;

    public GameObject questLog;
    private Logs logs;




    void Start()
    {
        rend = GetComponent<Renderer>();

        startPanelOn = true;
        toolPanelOn = false;

        topBarIndicator.gameObject.SetActive(false);
        toolRowIndicator.gameObject.SetActive(false);
        workRowIndicator.gameObject.SetActive(false);
        coordinateIndicator.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
        minusPlaceholder.gameObject.SetActive(false);

        TBIOriginalPos = topBarIndicator.transform.position;
        TRIOriginalPos = toolRowIndicator.transform.position;
        WRIOriginalPos = workRowIndicator.transform.position;
        CIOriginalPos = coordinateIndicator.transform.position;

        countTopBar = 1;
        countToolRow = 1;
        countWorkRow = 0;
        countCoordinate = 1;

        isWritable = false;

        x_coordinate.gameObject.SetActive(false);
        y_coordinate.gameObject.SetActive(false);
        z_coordinate.gameObject.SetActive(false);

        logs = questLog.GetComponent<Logs>();
    }

    public void TurnOnStartPanel()
    {
        startPanelOn = true;
        toolPanelOn = false;

        topBarIndicator.gameObject.SetActive(false);
        toolRowIndicator.gameObject.SetActive(false);
        workRowIndicator.gameObject.SetActive(false);
        coordinateIndicator.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
        minusPlaceholder.gameObject.SetActive(false);

        topBarIndicator.transform.position = TBIOriginalPos;
        toolRowIndicator.transform.position = TRIOriginalPos;
        workRowIndicator.transform.position = WRIOriginalPos;
        coordinateIndicator.transform.position = CIOriginalPos;

        x_coordinate.gameObject.SetActive(false);
        y_coordinate.gameObject.SetActive(false);
        z_coordinate.gameObject.SetActive(false);

        isWritable = false;

        countTopBar = 1;
        countToolRow = 1;
        countWorkRow = 0;
        countCoordinate = 1;
    }

    public bool SwitchToWorkingPanels()
    {
        if (StartupStateManager.powerUpButtonTested && startPanelOn)
        {
            startPanelOn = false;
            toolPanelOn = true;
            toolRowIndicator.gameObject.SetActive(true);
            topBarIndicator.gameObject.SetActive(false);
            inputField.gameObject.SetActive(true);
            minusPlaceholder.gameObject.SetActive(false);
            countCoordinate = 1;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void TurnOnToolPanel()
    {
            rend.material = toolPanel;
            toolPanelOn = true;
            x_coordinate.gameObject.SetActive(false);
            y_coordinate.gameObject.SetActive(false);
            z_coordinate.gameObject.SetActive(false);
    }

    public void TurnOnWorkPanel()
    {
            rend.material = workPanel;
            toolPanelOn = false;
            x_coordinate.gameObject.SetActive(true);
            y_coordinate.gameObject.SetActive(true);
            z_coordinate.gameObject.SetActive(true);
    }

    public void TopBarIndicatorMoveToRight()
    {
        if (countToolRow == 0 && countWorkRow == 0)
        {
            if (countTopBar < 2)
            {
                topBarIndicator.transform.localPosition -= new Vector3(0.11f, 0, 0);
                countTopBar++;
                TurnOnWorkPanel();
                logs.CompleteQuest(11);
            }
        }
    }

    public void TopBarIndicatorMoveToLeft()
    {
        if (countToolRow == 0 && countWorkRow == 0)
        {
            if (countTopBar > 1)
            {
                topBarIndicator.transform.localPosition += new Vector3(0.11f, 0, 0);
                countTopBar--;
                TurnOnToolPanel();
            }
        }
    }

    public void ToolRowIndicatorMoveUp()
    {
        if (toolPanelOn)
        {
            if (countToolRow > 0)
            {
                toolRowIndicator.transform.position += new Vector3(0, 0.0077f, 0);
                countToolRow--;
            }

            if (countToolRow == 0)
            {
                toolRowIndicator.gameObject.SetActive(false);
                topBarIndicator.gameObject.SetActive(true);
                logs.CompleteQuest(10);
            }
        }
    }

    public void ToolRowIndicatorMoveDown()
    {
        if (toolPanelOn)
        {
            if (countToolRow < 15)
            {
                toolRowIndicator.transform.position -= new Vector3(0, 0.0077f, 0);
                countToolRow++;
                topBarIndicator.gameObject.SetActive(false);
                toolRowIndicator.gameObject.SetActive(true);
            }
        }


    }

    public void WorkRowIndicatorMoveUp()
    {
        if (!toolPanelOn)
        {
            if (countWorkRow > 0)
            {
                workRowIndicator.transform.position += new Vector3(0, 0.00578f, 0);
                countWorkRow--;
                isWritable = false;
            }

            if (countWorkRow == 0)
            {
                workRowIndicator.gameObject.SetActive(false);
                coordinateIndicator.gameObject.SetActive(false);
                topBarIndicator.gameObject.SetActive(true);
            }

            if (countWorkRow == 2)
            {
                isWritable = true;
                logs.CompleteQuest(12);
            }
        }
    }

    public void WorkRowIndicatorMoveDown()
    {
        if (!toolPanelOn)
        {
            if (countWorkRow < 21)
            {
                workRowIndicator.transform.position -= new Vector3(0, 0.00578f, 0);
                countWorkRow++;
                topBarIndicator.gameObject.SetActive(false);
                coordinateIndicator.gameObject.SetActive(true);
                workRowIndicator.gameObject.SetActive(true);
                isWritable = false;
            }

            if (countWorkRow == 2)
            {
                isWritable = true;
                logs.CompleteQuest(12);
            }
        }
    }

    public void CoordinateIndicatorMoveToRight()
    {
        if (!toolPanelOn)
        {
            if (countWorkRow > 0)
            {
                if (countCoordinate < 4)
                {
                    coordinateIndicator.transform.localPosition -= new Vector3(25f, 0, 0);
                    countCoordinate++;
                }

                if (countCoordinate == 4)
                {
                    coordinateIndicator.transform.localPosition += new Vector3(75f, 0, 0);
                    countCoordinate = 1;
                }
                logs.CompleteQuest(18);
            }
        }
    }

    public void CoordinateIndicatorMoveToLeft()
    {
        if (!toolPanelOn)
        {
            if (countWorkRow > 0)
            {
                if (countCoordinate > 1)
                {
                    coordinateIndicator.transform.localPosition += new Vector3(25f, 0, 0);
                    countCoordinate--;
                }
                logs.CompleteQuest(18);
            }
        }
    }

    public int GetCurrentCoordinate()
    {
        return countCoordinate;
    }
}
