using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenCoordinates : MonoBehaviour
{

    public Text x_coordinate;
    public Text y_coordinate;
    public Text z_coordinate;

    public GameObject drill;
    public GameObject workbench;

    public GameObject workbench000;
    public GameObject drill000;

    private float x_value;
    private float y_value;
    private float z_value;

    //private Vector3 oldDrillPosition;
    //private Vector3 oldWorkbenchPosition;

    void Start()
    {
        UpdateCoordinates();
        //oldDrillPosition = drill.transform.localPosition;
        //oldWorkbenchPosition = workbench.transform.localPosition;
        
    }

    public void StartACoroutine()
    {
        StartCoroutine("CoordinatesUpdator");
    }

    void Update()
    {
       
    }

    public void UpdateCoordinates()
    {
        x_value = (float) System.Math.Round(((workbench.transform.position.x - workbench000.transform.position.x) / 0.63f * 600), 3);
        y_value = (float)System.Math.Round(((workbench.transform.position.z - workbench000.transform.position.z) / 0.44f * 600), 3);
        z_value = (float)System.Math.Round(-((drill.transform.position.y - drill000.transform.position.y) / 0.35f * 600), 3); ;

        if (x_value >= 600) x_coordinate.text = "600.000";
        else if (x_value <= 0) x_coordinate.text = "0.000";
        else x_coordinate.text = "" + x_value;

        if(y_value >= 600) y_coordinate.text = "600.000";
        else if (y_value <= 0) y_coordinate.text = "0.000";
        else y_coordinate.text = "" + y_value;

        if (z_value >= 600) z_coordinate.text = "600.000";
        else if (z_value <= 0) z_coordinate.text = "0.000";
        else z_coordinate.text = "" + z_value;
    }

    IEnumerator CoordinatesUpdator()
    {
        while (true)
        {
            //print("old position drill: " + oldDrillPosition + ", new position drill: " + drill.transform.localPosition + ", old position wb: " + oldWorkbenchPosition + ", new position wb: " + workbench.transform.localPosition);
            //if (drill.transform.localPosition.y != oldDrillPosition.y || workbench.transform.localPosition != oldWorkbenchPosition)
            //{
            UpdateCoordinates();
            //}

            //oldDrillPosition = drill.transform.localPosition;
            //oldWorkbenchPosition = workbench.transform.localPosition;

            yield return new WaitForSeconds(0.1f);
        }
    }

}
