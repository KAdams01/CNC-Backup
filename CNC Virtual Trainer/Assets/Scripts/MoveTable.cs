using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MoveTable : MonoBehaviour
{
    public Hand leftHand, rightHand;
    public SteamVR_Action_Boolean triggerPressed;
    private GameObject attachedTable;
    private Vector3 grabOffset;
    private List<GameObject> contactingGameObjects;
    private bool leftGrab, rightGrab;

    private void Start()
    {
        contactingGameObjects = new List<GameObject>();
        leftGrab = false;
        rightGrab = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerPressed.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            if (leftHand.hoveringInteractable != null)
            {
                if (leftHand.hoveringInteractable.name == "ToolTableParent")
                {
                    attachedTable = leftHand.hoveringInteractable.gameObject;
                    grabOffset = leftHand.transform.position - attachedTable.transform.position;
                    foreach(GameObject go in contactingGameObjects)
                    {
                        go.transform.SetParent(gameObject.transform);
                    }
                    leftGrab = true;
                }
            }

        }
        else if (triggerPressed.GetStateUp(SteamVR_Input_Sources.LeftHand))
        {
            attachedTable = null;
            foreach (GameObject go in contactingGameObjects)
            {
                go.transform.SetParent(null);
            }
            leftGrab = false;
        }



        if (triggerPressed.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            if (rightHand.hoveringInteractable != null)
            {
                if (rightHand.hoveringInteractable.name == "ToolTableParent")
                {
                    attachedTable = rightHand.hoveringInteractable.gameObject;
                    grabOffset = rightHand.transform.position - attachedTable.transform.position;
                    foreach (GameObject go in contactingGameObjects)
                    {
                        go.transform.SetParent(gameObject.transform);
                    }
                    rightGrab = true;
                }
            }

        }
        else if (triggerPressed.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            attachedTable = null;
            foreach (GameObject go in contactingGameObjects)
            {
                go.transform.SetParent(null);
            }
            rightGrab = false;
        }

        if (attachedTable != null)
        {
            if (leftGrab)
            {
                Vector3 temp = leftHand.transform.position - grabOffset;
                temp.y = attachedTable.transform.position.y;
                attachedTable.transform.position = temp;
            } else if (rightGrab)
            {
                Vector3 temp = rightHand.transform.position - grabOffset;
                temp.y = attachedTable.transform.position.y;
                attachedTable.transform.position = temp;
            }
            

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        switch (collision.name)
        {
            case "Clipboard":
                contactingGameObjects.Add(collision.gameObject);
                break;
            case "Tool":
                contactingGameObjects.Add(collision.gameObject);
                break;
            case "Cloth":
                contactingGameObjects.Add(collision.gameObject);
                break;
            case "Magnifier":
                contactingGameObjects.Add(collision.gameObject);
                break;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        switch (collision.name)
        {
            case "Clipboard":
                contactingGameObjects.Remove(collision.gameObject);
                break;
            case "Tool":
                contactingGameObjects.Remove(collision.gameObject);
                break;
            case "Cloth":
                contactingGameObjects.Remove(collision.gameObject);
                break;
            case "Magnifier":
                contactingGameObjects.Add(collision.gameObject);
                break;
        }
    }
}
