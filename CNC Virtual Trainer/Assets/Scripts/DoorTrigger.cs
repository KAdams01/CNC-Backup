using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    private bool isLeftDoorOpen;
    private bool isRightDoorOpen;
    public GameObject computerScreen;
    public GameObject questLog;
    private Logs logs;

    private void Awake()
    {
        //doorTick = GameObject.Find("CheckMarks").transform.GetChild(0).gameObject;
        isLeftDoorOpen = true;
        isRightDoorOpen = true;
        logs = questLog.GetComponent<Logs>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.name == "DoorColliderLeft")
        {
            isLeftDoorOpen = false;
            CheckBothDoors();
        }
        if (collision.name == "DoorColliderRight")
        {
            isRightDoorOpen = false;
            CheckBothDoors();
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.name == "DoorColliderLeft" || collision.name == "DoorColliderRight")
        {
            StartupStateManager.bothDoorsClosed = false;
            logs.CompleteQuest(7);
        }
    }
    private void CheckBothDoors()
    {
        //May provide bugs later
        if (!isLeftDoorOpen && !isRightDoorOpen && computerScreen.activeSelf)
        {
            StartupStateManager.bothDoorsClosed = true;
            logs.CompleteQuest(4);
        }
    }
}
