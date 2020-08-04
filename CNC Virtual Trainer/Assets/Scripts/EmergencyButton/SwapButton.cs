using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class SwapButton : MonoBehaviour
{
    public GameObject originalButton, pressedButton;
    private bool pressed = false;
    private string originalText;
    private List<iButton> allButtons;
    private HoverButton hoverButton;
    private Collider col;
    public ZeroPointReturn zeroPointReturn;

    public GameObject computerScreen;

    private bool processStarted;

    private void Start()
    {
        hoverButton = GetComponentInChildren<HoverButton>();
        col = transform.GetChild(0).GetComponent<BoxCollider>();
        allButtons = new List<iButton>();
        foreach (iButton b in Resources.FindObjectsOfTypeAll<iButton>())
        {
            if (!b.gameObject.name.Contains("Clone"))
            {
                allButtons.Add(b);
            }

        }
    }

    public void SwapEmergencyButtons()
    {
        //Logic for swapping emergency buttons
        if (!pressed)
        {
            processStarted = true;
            pressedButton.SetActive(true);
            originalButton.SetActive(false);
            zeroPointReturn.StopMachineReturn();
            foreach (iButton b in allButtons)
            {
                if (b.gameObject.name != "EmergancyStopHeadEnd" || b.gameObject.name != "PowerOffBtn")
                {
                    b.SetButtonAsUnusable();
                }
            }
        }
        else
        {
            pressedButton.SetActive(false);
            originalButton.SetActive(true);
            StartCoroutine(DisableButtonCollider());
            //Unsure if this should be set to previous state or the machine resets after an emergency press.
            CurrentState.state = States.STARTUP_EMERGENCYRELEASED;
            //clipboardEmergencyButtonText.text = originalText;
            foreach (iButton b in allButtons)
            {
                b.SetButtonAsUseable();
            }
            if (processStarted && computerScreen.activeSelf)
            {
                StartupStateManager.emergencyButtonTested = true;

            }
        }
        pressed = !pressed;
    }
    IEnumerator DisableButtonCollider()
    {
        col.enabled = false;
        yield return new WaitForSeconds(1f);
        col.enabled = true;
    }
}
