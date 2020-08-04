using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTurnIndication : MonoBehaviour
{
    private HighlightCreator highlightCreator;
    private GameObject panelRotateHighlight;
    private HighlightFlash flash;
    private Quaternion startRot;
    // Start is called before the first frame update
    void Start()
    {
        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        panelRotateHighlight = highlightCreator.CreateHighlightForGameObject(gameObject);
        panelRotateHighlight.transform.parent = gameObject.transform.parent;
        panelRotateHighlight.SetActive(true);
        startRot = gameObject.transform.rotation;
        flash = panelRotateHighlight.AddComponent<HighlightFlash>();
        EnablePanelFlash();
        StartCoroutine(CheckIfRotated());
    }
    public void EnablePanelFlash()
    {
        flash.EnablePanelHighlight();
    }
    public void DisablePanelFlash()
    {
        flash.DisablePanelHighlight();
    }
    IEnumerator CheckIfRotated()
    {
        while (true)
        {
            if(startRot != gameObject.transform.rotation)
            {
                DisablePanelFlash();
                Destroy(gameObject);
                break;
            }
            else
            {
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
}
