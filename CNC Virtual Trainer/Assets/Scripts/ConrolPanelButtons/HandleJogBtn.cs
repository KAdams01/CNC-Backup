using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleJogBtn : iButton
{
    public GameObject screen;
    public Material toolScreen;
    public Renderer rend;
    public ArrowKeys arrowKeys;
    public GameObject questLog;
    private Logs logs;
    private GameObject highlight;
    private HighlightCreator highlightCreator;

    protected override void Awake()
    {
        logs = questLog.GetComponent<Logs>();
    }

    void Start()
    {
        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlight = highlightCreator.CreateHighlightForGameObject(this.gameObject);
    }

    public override void OnButtonDown()
    {
        if (useable && StartupStateManager.powerUpButtonTested)
        {
            foreach (Transform t in screen.transform)
            {
                if (t.name != "x_coordinate" && t.name != "y_coordinate" && t.name != "z_coordinate")
                {
                    t.gameObject.SetActive(false);
                    arrowKeys.TurnOnToolPanel();
                }
            }

            if (arrowKeys.SwitchToWorkingPanels())
            {
                rend.material = toolScreen;
            }


            logs.CompleteQuest(6);
        }
    }

}
