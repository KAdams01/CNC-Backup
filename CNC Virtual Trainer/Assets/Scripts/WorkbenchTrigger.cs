using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Vector3 = UnityEngine.Vector3;

public class WorkbenchTrigger : MonoBehaviour
{
    public GameObject workbench;
    public GameObject drill;

    public GameObject defaultPositionWorkbench;
    public GameObject defaultPositionDrill;

    private float speedChosen;
    private bool areDoorsClosed;
    //vector is assigned and used to convert the current axis into a direction
    private Vector3 vector;
    private SoundManager soundManager;
    public enum Axis
    {
        x,y,z, undefined
    }
    public Axis currentlySelectedAxis = Axis.undefined;
    private enum MoveableObject
    {
        Workbench, Drill
    }
    private MoveableObject currentlySelectedMoveable;
    public GameObject questLog;
    private Logs logs;

    private GameObject highlight;
    private HighlightCreator highlightCreator;

    void Start()
    {
        areDoorsClosed = true;
        vector = new Vector3(0, 0, 0);
        soundManager = SoundManager._instance;
        /*DoorTrigger.doorsClosed += SetDoorsClosed;
        DoorTrigger.doorsOpened += SetDoorsOpen;*/
        areDoorsClosed = true;
        logs = questLog.GetComponent<Logs>(); highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlight = highlightCreator.CreateHighlightForGameObject(this.gameObject);

    }

    public void MoveObjectPositive()
    {
        if (areDoorsClosed)
        {
            switch (currentlySelectedAxis) // switch for each axis used to keep the movement inside of the borders and call a coroutine that causes a transition to a new position
            {
                case Axis.x:
                    if ((workbench.transform.localPosition + vector).x > -2.75f)
                    {
                        DoMovementForward();
                    }
                    break;
                case Axis.y:
                    if ((drill.transform.localPosition + vector).y < 5.24f)
                    {
                        DoMovementForward();
                    }
                    break;
                case Axis.z:
                    if ((workbench.transform.localPosition + vector).z > 0.1f)
                    {
                        DoMovementForward();
                    }
                    break;
            }
        }

    }
    public void MoveObjectNegative()
    {
        if (areDoorsClosed)
        {
            switch (currentlySelectedAxis) // switch for each axis used to keep the movement inside of the borders and call a coroutine that causes a transition to a new position
            {
                case Axis.x:
                    if ((workbench.transform.localPosition - vector).x < -2.13f)
                    {
                        DoMovementBack();
                    }

                    break;
                case Axis.y:
                    if ((drill.transform.localPosition - vector).y > 4.78f)
                    {
                        DoMovementBack();
                    }

                    break;
                case Axis.z:
                    if ((workbench.transform.localPosition - vector).z < 0.45f)
                    {
                        DoMovementBack();
                    }

                    break;
            }
        }
        logs.CompleteQuest(15);

    }

    private void MoveObject(GameObject movableGameObject, Vector3 endPosition, Axis axis, bool isIncreasing)
    {

    switch (axis) // switch for checking which axis the play chose, with each case containing actions for both movement forward and back
        {
            case Axis.x:
                if (isIncreasing)
                {
                        movableGameObject.transform.position += endPosition;
                }
                else
                {
                        movableGameObject.transform.position -= endPosition;
                }
                break;
            case Axis.y:
                if (isIncreasing)
                {
                        movableGameObject.transform.position += endPosition;
                }
                else
                {
                        movableGameObject.transform.position -= endPosition;
                }
                break;
            case Axis.z:
                if (isIncreasing)
                {
                        movableGameObject.transform.position += endPosition;
                }
                else
                {
                        movableGameObject.transform.position -= endPosition;
                }
                break;
        }
        logs.CompleteQuest(15);
    }

    IEnumerator MoveToDefaultPositions()
    {
        int counter = 0;
        while (counter < 400)
        {
            workbench.transform.position = Vector3.Lerp(workbench.transform.position, defaultPositionWorkbench.transform.position,
                Time.deltaTime);
            drill.transform.position =
                Vector3.Lerp(drill.transform.position, defaultPositionDrill.transform.position, Time.deltaTime);
            counter++;
            yield return new WaitForSeconds(.01f);
        }
    }

    public void ResetPosition()
    {
        if (areDoorsClosed)
        {
            StopAllCoroutines();
            currentlySelectedAxis = Axis.undefined;
            speedChosen = 0.0001f;
            StartCoroutine(MoveToDefaultPositions());
        }
    }

    public void ResetPositionWithoutMoving()
    {
        if (areDoorsClosed)
        {
            StopAllCoroutines();
            currentlySelectedAxis = Axis.undefined;
            speedChosen = 0;
        }
    }

    public void DoMovementForward() // a function containing logic for movement forward
    {
        soundManager.PlayRotateSound();
        switch (currentlySelectedMoveable)
        {
            case MoveableObject.Workbench:
                MoveObject(workbench, vector, currentlySelectedAxis, true);
                break;
            case MoveableObject.Drill:
                MoveObject(drill, vector, currentlySelectedAxis, true);
                break;
        }
    }

    public void DoMovementBack() // a function containing logic for movement back
    {
        soundManager.PlayRotateSound();
        switch (currentlySelectedMoveable)
        {
            case MoveableObject.Workbench:
                MoveObject(workbench, vector, currentlySelectedAxis, false);
                break;
            case MoveableObject.Drill:
                MoveObject(drill, vector, currentlySelectedAxis, false);
                break;
        }

    }
    public void SetAxis(string axis)
    {
        switch (axis)
        {
            case "x":
                currentlySelectedMoveable = MoveableObject.Workbench;
                currentlySelectedAxis = Axis.x;
                break;
            case "y":
                currentlySelectedMoveable = MoveableObject.Drill;
                currentlySelectedAxis = Axis.y;
                break;
            case "z":
                currentlySelectedMoveable = MoveableObject.Workbench;
                currentlySelectedAxis = Axis.z;
                break;
        }
        AssignVector();
        logs.CompleteQuest(13);

    }
    private void AssignVector()
    {
            switch (currentlySelectedAxis) // switch for setting an appropriate vector and movable object 
            {
                case Axis.x:
                    vector = new Vector3(speedChosen, 0, 0);
                    break;
                case Axis.y:
                    vector = new Vector3(0, speedChosen, 0);
                    break;
                case Axis.z:
                    vector = new Vector3(0, 0, speedChosen);
                    break;
            }
    }
    public void SetSpeed(float speed)
    {
        speedChosen = speed;
        AssignVector();
        logs.CompleteQuest(14);
    }
    private void SetDoorsOpen()
    {
        areDoorsClosed = false;
    }
    private void SetDoorsClosed()
    {
        areDoorsClosed = true;
    }
}
