using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialF1 :iButton
{
    public GameObject screenDisplay;
    private ArrowKeys arrowKeys;
    private NumbersManager numbersManager;
    
    public Text x_coordinate, y_coordinate, z_coordinate;

    public override void OnButtonDown()
    {
        if (useable && StartupStateManager.isSequenceDone)
        {
            if (arrowKeys.isWritable)
            {
                switch (arrowKeys.GetCurrentCoordinate())
                {
                    case 1:
                        if (numbersManager.GetValue() > 0 && numbersManager.GetValue() < 600)
                        {
                            x_coordinate.text = "" + numbersManager.GetValue();
                            numbersManager.Reset();
                        }
                        else
                        {
                            numbersManager.Reset();
                        }

                        break;
                    case 2:
                        if (numbersManager.GetValue() > 0 && numbersManager.GetValue() < 600)
                        {
                            y_coordinate.text = "" + numbersManager.GetValue();
                            numbersManager.Reset();
                        }
                        else
                        {
                            numbersManager.Reset();
                        }

                        break;
                    case 3:
                        if (numbersManager.GetValue() > 0 && numbersManager.GetValue() < 600)
                        {
                            z_coordinate.text = "" + numbersManager.GetValue();
                            numbersManager.Reset();
                        }
                        else
                        {
                            numbersManager.Reset();
                        }

                        break;
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
    }
}
