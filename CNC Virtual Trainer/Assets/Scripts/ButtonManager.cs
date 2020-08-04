using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager _instance = null;
    public enum InputMode
    {
        Right_Hand, Both_Hands
    }
    public InputMode inputMode = InputMode.Right_Hand;
    public Hand rightHand;
    public Hand leftHand;
    public SteamVR_Action_Boolean buttonPressRift;
    private iGrabbable grabbedObject;
    private SoundManager soundManager;
    private List<string> alreadyAnimatingButtons;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(_instance);
        }
        else
        {
            _instance = this;
        }
        soundManager = SoundManager._instance;
        alreadyAnimatingButtons = new List<string>();
        alreadyAnimatingButtons.Add(" ");
    }
    private void Update()
    {
        if (buttonPressRift.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            OnButtonDown(rightHand);
        }
        if (buttonPressRift.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            OnButtonUp(rightHand);
        }
        if (inputMode == InputMode.Both_Hands)
        {
            if (buttonPressRift.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                OnButtonDown(leftHand);

            }
            if (buttonPressRift.GetStateUp(SteamVR_Input_Sources.LeftHand))
            {
                OnButtonUp(leftHand);
            }
        }
    }

    //Delegate the functionality of a button press to member that inherits iButton
    private void OnButtonDown(Hand hand)
    {
        grabbedObject = null;
        //if the hand is in contact with an Interactable script (SteamVR)
        if (hand.hoveringInteractable)
        {
            //Does it have a script that implements iButton? is so, delegate button action.
            iButton iB = hand.hoveringInteractable.GetComponent<iButton>();
            if (iB != null)
            {

                if (iB is iGrabbable)
                {
                    ((iGrabbable)iB).SetCurrentHand(hand);
                    grabbedObject = (iGrabbable)iB;
                    iB.OnButtonDown();
                }
                else
                {
                    iB.OnButtonDown();
                    soundManager.PlayClickSound();
                    StartCoroutine(AnimateButtonPress(iB));
                }
            }
        }
    }
    //Delegate the functionality of a button release to member that inherits iGrabbable
    private void OnButtonUp(Hand hand)
    {
        if (grabbedObject != null)
        {
            grabbedObject.OnButtonUp();
        }
    }

    IEnumerator AnimateButtonPress(iButton button)
    {

        if (button.GetButtonIsAnimatable())
        {
            button.gameObject.transform.localPosition = new Vector3(button.gameObject.transform.localPosition.x, button.gameObject.transform.localPosition.y, button.gameObject.transform.localPosition.z - 0.003f);
            button.SetButtonAnimatable(false);
            yield return new WaitForSeconds(0.5f);
            button.gameObject.transform.localPosition = new Vector3(button.gameObject.transform.localPosition.x, button.gameObject.transform.localPosition.y, button.gameObject.transform.localPosition.z + 0.003f);
            button.SetButtonAnimatable(true);
        }

    }
}
