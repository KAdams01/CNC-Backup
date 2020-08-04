using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightFlash : MonoBehaviour
{
    private IEnumerator flashHighlight;
    private float counter;
    private bool up;
    private bool highlightEnabled = false;
    private const string ShaderWidth = "g_flOutlineWidth";
    // Start is called before the first frame update
    void Awake()
    {
        flashHighlight = FlashHighlight();
    }

    public void EnablePanelHighlight()
    {
        if (!highlightEnabled)
        {
            flashHighlight = FlashHighlight();
            StartCoroutine(flashHighlight);
            gameObject.SetActive(true);
            highlightEnabled = true;
        }
    }
    public void DisablePanelHighlight()
    {
        if (highlightEnabled)
        {
            StopCoroutine(flashHighlight);
            gameObject.SetActive(false);
            highlightEnabled = false;
        }
    }
    private IEnumerator FlashHighlight()
    {
        while (true)
        {
            gameObject.GetComponent<Renderer>().material.SetFloat(ShaderWidth, counter);

            if (counter < 0.005f)
            {
                up = true;
            }
            if (counter > 0.0125f)
            {
                up = false;
            }
            if (up)
            {
                counter += 0.0004f;
            }
            else
            {
                counter -= 0.0004f;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
