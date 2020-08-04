using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class BlackButtonV2 : MonoBehaviour
{
    public Hand leftHand, rightHand;
    public SteamVR_Action_Boolean triggerPressed;
    private bool pressed = false;
    private BoxcastTest boxcast;

    private GameObject highlight;
    private HighlightCreator highlightCreator;

    private enum CurrentHand
    {
        LEFT, RIGHT, NONE
    }
    private CurrentHand currentHand;



    void Start()
    {
        boxcast = GameObject.FindObjectOfType<BoxcastTest>();
        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlight = highlightCreator.CreateHighlightForGameObject(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if ((triggerPressed.GetStateDown(SteamVR_Input_Sources.LeftHand)) && !pressed)
        {
            if (leftHand.hoveringInteractable != null)
            {
                if (leftHand.hoveringInteractable.name == "MainBody")
                {
                    currentHand = CurrentHand.LEFT;
                    gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z + 0.01f);
                    pressed = true;
                    buttonPressed();
                    boxcast.StartBoxCheck();
                }
            }


        }
        if (triggerPressed.GetStateUp(SteamVR_Input_Sources.LeftHand) && pressed && currentHand == CurrentHand.LEFT)
        {
            buttonReleased();
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z - 0.01f);
            pressed = false;
            currentHand = CurrentHand.NONE;
            boxcast.StopBoxCheck();
        }

        if ((triggerPressed.GetStateDown(SteamVR_Input_Sources.RightHand)) && !pressed)
        {
            if (rightHand.hoveringInteractable != null)
            {
                if (rightHand.hoveringInteractable.name == "MainBody")
                {
                    currentHand = CurrentHand.RIGHT;
                    gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z + 0.01f);
                    pressed = true;
                    buttonPressed();
                    boxcast.StartBoxCheck();
                }
            }


        }
        if (triggerPressed.GetStateUp(SteamVR_Input_Sources.RightHand) && pressed && currentHand == CurrentHand.RIGHT)
        {
            buttonReleased();
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z - 0.01f);
            pressed = false;
            currentHand = CurrentHand.NONE;
            boxcast.StopBoxCheck();
        }
    }

    private void buttonPressed()
    {
        pressed = true;
        if (boxcast.inserted)
        {
            //allow the parent to be interactable
            Destroy(boxcast.tool.GetComponent<IgnoreHovering>());
            foreach (Transform t in boxcast.tool.transform)
            {
                Destroy(t.gameObject.GetComponent<IgnoreHovering>());
            }

        }
    }

    private void buttonReleased()
    {
        pressed = false;
        if (boxcast.inserted)
        {
            boxcast.tool.gameObject.AddComponent<IgnoreHovering>();
            foreach (Transform t in boxcast.tool.transform)
            {
                t.gameObject.AddComponent<IgnoreHovering>();
            }
        }
    }

    public bool isPressed()
    {
        return pressed;
    }
}
