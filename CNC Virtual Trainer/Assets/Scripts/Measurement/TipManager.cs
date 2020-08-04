using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TipManager : MonoBehaviour
{
    public GameObject horizontalTip, verticalTip, passiveTip, measurePoints, brokenPoint;
    public Transform brokenTipParentTransform;
    private Vector3 localPositionBrokenTip;
    public Transform playerCamera;
    private SoundManager sm;
    public GameObject dial;
    private Logs questLogs;
    private Quaternion initialLocalRotation;
    public enum CurrentTip
    {
        HORIZONTAL, VERTICAL, PASSIVE, BROKEN
    }
    //TODO Make this private after testing
    public CurrentTip tip;
    public bool isChangeable; 


    // Start is called before the first frame update
    void Start()
    {
        localPositionBrokenTip = brokenPoint.transform.localPosition;
        SetPassiveTip();
        initialLocalRotation = dial.transform.localRotation;
        sm = SoundManager._instance;
        isChangeable = true;
        questLogs = GameObject.FindObjectOfType<Logs>();
    }

    public void SetPassiveTip()
    {
        if (tip != CurrentTip.BROKEN)
        {
            if (tip != CurrentTip.PASSIVE)
            {
                horizontalTip.SetActive(false);
                verticalTip.SetActive(false);
                passiveTip.SetActive(true);
                measurePoints.SetActive(false);
                brokenPoint.SetActive(false);
                tip = CurrentTip.PASSIVE;
                isChangeable = true;
            }
        }
    }
    public void SetHorizontalTip()
    {
        if (tip != CurrentTip.BROKEN)
        {
            if (isChangeable)
            {
                measurePoints.SetActive(true);
                horizontalTip.SetActive(true);
                foreach(Transform t in measurePoints.transform)
                {
                    t.gameObject.SetActive(true);
                }
                verticalTip.SetActive(false);
                passiveTip.SetActive(false);
                brokenPoint.SetActive(false);
                tip = CurrentTip.HORIZONTAL;
                ResetTip(tip);
            }
        }
    }
    public void SetVerticalTip()
    {
        if (tip != CurrentTip.BROKEN)
        {
            if (tip != CurrentTip.VERTICAL && isChangeable)
            {
                horizontalTip.SetActive(false);
                verticalTip.SetActive(true);
                passiveTip.SetActive(false);
                measurePoints.SetActive(false);
                brokenPoint.SetActive(false);
                tip = CurrentTip.VERTICAL;
                ResetTip(tip);
            }
        }
    }
    public void SetBrokenTip()
    {
        if (tip == CurrentTip.HORIZONTAL)
        {
            horizontalTip.SetActive(false);
            measurePoints.SetActive(false);
            BreakTip();
        }
        else if (tip == CurrentTip.VERTICAL)
        {
            verticalTip.SetActive(false);
            BreakTip();
        }
        brokenPoint.SetActive(true);

    }
    public void BreakTip()
    {
        Vector3 direction = playerCamera.transform.position - brokenPoint.transform.position;
        brokenPoint.GetComponent<Rigidbody>().velocity = direction * 50;
        brokenPoint.transform.parent = null;
        sm.PlayBreakSound();
        tip = CurrentTip.BROKEN;
        isChangeable = true;
        questLogs.isTipBroken = true;
        questLogs.OpenBrokenTipQuest();
    }
    public void ResetTip()
    {
        tip = new CurrentTip();
        SetPassiveTip();
        dial.transform.localRotation = initialLocalRotation;
        Rigidbody temp = brokenPoint.GetComponent<Rigidbody>();
        temp.angularVelocity = Vector3.zero;
        temp.velocity = Vector3.zero;
        brokenPoint.transform.SetParent(brokenTipParentTransform);
        brokenPoint.transform.localPosition = localPositionBrokenTip;
        brokenPoint.transform.rotation = gameObject.transform.rotation;
        horizontalTip.transform.SetParent(brokenTipParentTransform);
        horizontalTip.transform.localPosition = localPositionBrokenTip;
        horizontalTip.transform.rotation = gameObject.transform.rotation;
        horizontalTip.transform.SetParent(gameObject.transform);

    }
    private void ResetTip(CurrentTip current)
    {
        switch (current)
        {
            case CurrentTip.HORIZONTAL:
                //Reset vertical tip
                verticalTip.transform.localRotation = initialLocalRotation;
                break;
            case CurrentTip.VERTICAL:
                //Reset horizontal tip
                horizontalTip.transform.localRotation = initialLocalRotation;
                break;
        }
    }
    public void SetTipBasedOnAxis(WorkbenchTrigger.Axis axis)
    {
        switch (axis)
        {
            case WorkbenchTrigger.Axis.x:
                SetHorizontalTip();
                break;
            case WorkbenchTrigger.Axis.y:
                SetVerticalTip();
                break;
            case WorkbenchTrigger.Axis.z:
                SetHorizontalTip();
                break;
            case WorkbenchTrigger.Axis.undefined:
                SetPassiveTip();
                break;
        }
    }
}
