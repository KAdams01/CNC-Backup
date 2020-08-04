using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ButtonLock : MonoBehaviour
{
    //compnent containing logic for swapping buttons
    private SwapButton swapButton;
    public GameObject panelLight;
    private Renderer lightRenderer;
    public Material red;

    private HighlightCreator highlightCreator;
    private GameObject highlight;

    private void Awake()
    {
        swapButton = GetComponentInParent<SwapButton>();
        lightRenderer = panelLight.GetComponent<Renderer>();
    }

    void Start()
    {
        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlight = highlightCreator.CreateHighlightForGameObject(this.gameObject);
    }

    private void OnTriggerEnter(Collider col)
    {
        //if this button is pushed to the point where it hits ButtonStopPoint, swap to "pressed button"
        if(col.name == "ButtonStopPoint")
        {
            swapButton.SwapEmergencyButtons();
            lightRenderer.material = red;
        }
    }
}
