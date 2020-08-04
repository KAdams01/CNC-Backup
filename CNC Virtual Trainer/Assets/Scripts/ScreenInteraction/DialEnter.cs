using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class DialEnter : iButton
{

    public GameObject screenDisplay;
    private ArrowKeys arrowKeys;
    private NumbersManager numbersManager;

    public Text x_coordinate, y_coordinate, z_coordinate;
    public GameObject questLog;
    private Logs logs;
    private GameObject highlight;
    private HighlightCreator highlightCreator;



    public override void OnButtonDown()
    {
        if (useable && StartupStateManager.isSequenceDone)
        {
            if (arrowKeys.isWritable)
            {
                float result = 0;

                bool isQuest = numbersManager.GetValue() == -3.0f;

                string resultInString = "";
                switch (arrowKeys.GetCurrentCoordinate())
                {
                    case 1:
                        result = float.Parse(x_coordinate.text) +
                                       numbersManager.GetValue();
                        if (result > 0 && result < 600)
                        {
                            resultInString = result.ToString();
                            x_coordinate.text = resultInString;
                            numbersManager.Reset();
                            result = 0;
                        }
                        else
                        {
                            numbersManager.Reset();
                        }

                        break;
                    case 2:
                        result = float.Parse(y_coordinate.text) +
                                       numbersManager.GetValue();
                        if (result > 0 && result < 600)
                        {
                            resultInString = result.ToString();
                            y_coordinate.text = resultInString;
                            numbersManager.Reset();
                            result = 0;
                        }
                        else
                        {
                            numbersManager.Reset();
                        }

                        break;
                    case 3:
                        result = float.Parse(z_coordinate.text) +
                                       numbersManager.GetValue();
                        if (result > 0 && result < 600)
                        {
                            resultInString = result.ToString();
                            z_coordinate.text = resultInString;
                            numbersManager.Reset();
                            result = 0;
                        }
                        else
                        {
                            numbersManager.Reset();
                        }
                        
                        break;
                }

                if (isQuest)
                {
                    logs.CompleteQuest(22);
                }

                isQuest = false;
                bool allAxisComplete = float.Parse(z_coordinate.text) != 0f && float.Parse(x_coordinate.text) != 0f && float.Parse(x_coordinate.text) != 0f;
                if (allAxisComplete)
                {
                    logs.CompleteQuest(23);
                }
            }
            else
            {
                numbersManager.Reset();
            }
        }
    }

    void Start()
    {
        arrowKeys = screenDisplay.GetComponent<ArrowKeys>();
        numbersManager = screenDisplay.GetComponent<NumbersManager>();
        logs = questLog.GetComponent<Logs>();
        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlight = highlightCreator.CreateHighlightForGameObject(this.gameObject);

    }
}
