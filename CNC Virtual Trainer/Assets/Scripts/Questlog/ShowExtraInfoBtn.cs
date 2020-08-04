using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowExtraInfoBtn : iButton
{

    public GameObject additionalPanel;
    public Animator anim;
    private bool isShown;

    public override void OnButtonDown()
    {
        if (!isShown)
        {
            anim.Play("ShowPanel");
            isShown = true;
        }
        else
            {
                anim.Play("HideClip");
                isShown = false;
            }

        StartCoroutine(TriggerAdditionStuff());
    }

    protected override void Awake()
    {
        additionalPanel.SetActive(false);
        isShown = false;
    }

    IEnumerator TriggerAdditionStuff()
    {
        if (isShown)
        {
            yield return new WaitForSeconds(0.59f);
            additionalPanel.SetActive(!additionalPanel.activeInHierarchy);
        }
        else
        {
            additionalPanel.SetActive(!additionalPanel.activeInHierarchy);
        }

    }

}
