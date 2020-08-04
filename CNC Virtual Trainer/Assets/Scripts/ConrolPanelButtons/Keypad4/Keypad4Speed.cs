using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad4Speed : iButton
{
    // Start is called before the first frame update
    private WorkbenchTrigger wbTrigger;
    public Text jogRate;
    private GameObject highlight;
    private HighlightCreator highlightCreator;

    public enum Speed
    {
        Slow, Medium, Fast, DEBUG
    }
    public Speed speed;

    protected override void Awake()
    {
        base.Awake();
        //adding something
        wbTrigger = GameObject.Find("TurnableKnob").GetComponent<WorkbenchTrigger>();
    }

    void Start()
    {
        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlight = highlightCreator.CreateHighlightForGameObject(this.gameObject);
    }

    public override void OnButtonDown()
    {
        if (useable && StartupStateManager.isSequenceDone)
        {
            float temp;
            switch (speed)
            {
                case Speed.Slow:
                    temp = 0.00001f;
                    jogRate.text = "0.0001";
                    break;
                case Speed.Medium:
                    jogRate.text = "0.001";
                    temp = 0.0001f;
                    break;
                case Speed.Fast:
                    jogRate.text = "0.01";
                    temp = 0.001f;
                    break;
                case Speed.DEBUG:
                    jogRate.text = "0.1";
                    temp = 0.01f;
                    break;
                default:
                    temp = 0.001f;
                    break;
            }
            wbTrigger.SetSpeed(temp);
        }
    }
}
