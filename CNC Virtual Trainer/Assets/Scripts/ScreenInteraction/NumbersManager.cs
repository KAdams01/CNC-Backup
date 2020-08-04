using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class NumbersManager : MonoBehaviour
{

    public GameObject screenDisplay;
    private ArrowKeys arrowKeys;
    private ScreenCoordinates screenCoordinates;
    
    public Text x_coordinate, y_coordinate, z_coordinate;

    //public int pointPosition;
    private bool isPointSet;

    public Text inputField;
    private bool isNegative;
    private bool isInMilimiters;
    public Text minusPlaceholder;
    public Text pointPlaceholder;

    void Start()
    {
        screenCoordinates = screenDisplay.GetComponent<ScreenCoordinates>();
        arrowKeys = screenDisplay.GetComponent<ArrowKeys>();
        //pointPosition = 0;
        inputField.text = "";
        isPointSet = false;
        isNegative = false;
        isInMilimiters = false;
        minusPlaceholder.text = "-";
        pointPlaceholder.text = "";
    }

    public void AddToInput(char number)
    {
        if (!arrowKeys.startPanelOn)
        {
            //if (number == '.' && inputField.text.Length < 4)
            //{
            //    if (!isPointSet)
            //    {
            //        inputField.text += ".";
            //        pointPosition = inputField.text.Length;
            //        isPointSet = true;
            //    }
            //}
            //else if (number != '.' && (inputField.text.Length < pointPosition + 3))
            //{
            //    inputField.text += number;
            //}
            if (inputField.text.Length < 3)
            {
                inputField.text += number;
            }
        }
    }

    public float GetValue()
    {
        if (!String.IsNullOrEmpty(inputField.text))
        {
            string value = inputField.text;
            //value = value.Replace(',', '.');
            
            //    if (value[value.Length - 1] == '.')
            //    {
            //        value += "0";
            //    }

            float result = float.Parse(value); //, CultureInfo.InvariantCulture.NumberFormat);


            if (!isNegative)
            {
                if (isInMilimiters)
                {
                    //result /= Get10s(value.Length);
                    return result;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                if (isInMilimiters)
                {
                    //result /= Get10s(value.Length);
                    return -result;
                }
                else
                {
                    return -result;
                }
            }
        }
        else
        {
            return 0;
        }
    }

    int Get10s(float number)
    {
        int result = 0;
        switch (number)
        {
            case 1:
                result = 10;
                break;
            case 2:
                result = 100;
                break;
            case 3:
                result = 1000;
                break;
        }

        return result;
    }

    public void Reset()
    {
        isPointSet = false;
        //pointPosition = 0;
        inputField.text = "";
        arrowKeys.CoordinateIndicatorMoveToRight();
        minusPlaceholder.gameObject.SetActive(false);
        pointPlaceholder.gameObject.SetActive(false);
        isNegative = false;
        isInMilimiters = false;
    }

    public void ClickMinus()
    {
        isNegative = !isNegative;
        minusPlaceholder.gameObject.SetActive(!minusPlaceholder.gameObject.activeInHierarchy);
    }

    public void ClickPoint()
    {
        isInMilimiters = !isInMilimiters;
        pointPlaceholder.gameObject.SetActive(!pointPlaceholder.gameObject.activeInHierarchy);
    }

    public void ClearInput()
    {
        inputField.text = "";
    }

}
