using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BoxcastTest : MonoBehaviour
{
    public LayerMask layer;
    private IEnumerator boxCheckCoroutine;
    public GameObject clearHiglight;
    public GameObject dirtyHiglight;
    public GameObject tool;
    public GameObject inserPosition;
    [HideInInspector]
    public bool placable;
    [HideInInspector]
    public bool inserted;

    public bool isStarted;


    public GameObject blackButton;
    public Rigidbody toolIns;
    public GameObject headOfDrill;
    private TipManager tipManager;
    private WorkbenchTrigger workbenchTrigger;
    private Vector3 defaultToolPos;
    public SteamVR_Action_Boolean triggerReset;


    public GameObject questLog;
    private Logs logs;

    public bool m_Started;

    private void Start()
    {
        isStarted = false;
        boxCheckCoroutine = BoxCheck();
        inserted = false;
        defaultToolPos = tool.transform.position;
        toolIns = tool.GetComponent<Rigidbody>();
        tipManager = tool.GetComponentInChildren<TipManager>();
        workbenchTrigger = GameObject.FindObjectOfType<WorkbenchTrigger>();
        logs = questLog.GetComponent<Logs>();

        m_Started = true;

    }

    private IEnumerator BoxCheck()
    {
        while (true)
        {
            CheckBoxColliderCollisions();
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void StartBoxCheck()
    {
        isStarted = true;
        StartCoroutine(boxCheckCoroutine);
    }
    public void StopBoxCheck()
    {
        isStarted = false;
        CheckBoxColliderCollisions();
        StopCoroutine(boxCheckCoroutine);
        if (clearHiglight.activeInHierarchy || dirtyHiglight.activeInHierarchy)
        {
            clearHiglight.SetActive(false);
            dirtyHiglight.SetActive(false);
        }
    }

    public void OnButtonRelease()
    {
        //checks if tool is cleaned and inserts it
        if (tool.GetComponent<Tool>().isClean() && blackButton.GetComponentInChildren<BlackButtonV2>().isPressed() && placable)
        {
            clearHiglight.SetActive(false);
            tool.transform.position = inserPosition.transform.position;
            tool.transform.rotation = inserPosition.transform.rotation;
            toolIns.velocity = Vector3.zero;
            toolIns.angularVelocity = Vector3.zero;
            toolIns.useGravity = false;
            toolIns.isKinematic = true;
            inserted = true;
            logs.isTipBroken = false;
            logs.CloseBrokenTipQuest();
            logs.CompleteQuest(9);
            placable = false;
            tool.transform.SetParent(headOfDrill.transform);
            tipManager.SetTipBasedOnAxis(workbenchTrigger.currentlySelectedAxis);
        }
        else if (!tool.GetComponent<Tool>().isClean() && placable)
        {
            tool.transform.position = defaultToolPos;
        }
        else
        {
            RemoveTool();
        }
    }

    public void RemoveTool()
    {
        //resets velocity and gravity of removed tool
        toolIns.useGravity = true;
        toolIns.isKinematic = false;
        inserted = false;
        tipManager.SetPassiveTip();
    }

    public bool isPlacable()
    {
        return placable;
    }

    private void CheckBoxColliderCollisions()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(0.1f, 0.01f, 0.1f), Quaternion.identity, layer);
        if (colliders.Length > 0)
        {
            foreach (Collider c in colliders)
            {
                if (!inserted)
                {
                    placable = true;
                    if (tool.GetComponent<Tool>().isClean())
                    {
                        clearHiglight.SetActive(true);
                        clearHiglight.transform.position = inserPosition.transform.position;
                        clearHiglight.transform.rotation = Quaternion.Euler(0, 180f, 0);
                    }
                    else
                    {
                        dirtyHiglight.SetActive(true);
                        dirtyHiglight.transform.position = inserPosition.transform.position;
                        dirtyHiglight.transform.rotation = Quaternion.Euler(0, 180f, 0);
                    }

                }
            }
        }
        else
        {
            if (clearHiglight.activeInHierarchy || dirtyHiglight.activeInHierarchy)
            {
                clearHiglight.SetActive(false);
                dirtyHiglight.SetActive(false);
            }
            placable = false;
            inserted = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, new Vector3(0.1f, 0.01f, 0.1f));
    }
}
