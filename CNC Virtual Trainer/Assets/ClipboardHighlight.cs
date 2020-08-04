using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardHighlight : MonoBehaviour
{
    public GameObject clipboardRight, clipboardLeft;
    private HighlightCreator highlightCreator;
    private GameObject[] highlights;
    private bool highlightEnabled;
    private IEnumerator flashHighlight;
    private float counter;
    private bool up;
    private const string ShaderWidth = "g_flOutlineWidth";
    // Start is called before the first frame update
    void Start()
    {
        Shader.EnableKeyword(ShaderWidth);
        flashHighlight = FlashHighlight();
        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        highlights = new GameObject[3];
        highlights[0] = highlightCreator.CreateHighlightForGameObject(gameObject);
        highlights[1] = highlightCreator.CreateHighlightForGameObject(clipboardRight);
        highlights[2] = highlightCreator.CreateHighlightForGameObject(clipboardLeft);
        counter = 0.005f;
        highlightEnabled = false;
        up = true;
        EnableClipboardHighlight();
    }
    public void EnableClipboardHighlight()
    {
        if (!highlightEnabled)
        {
            StartCoroutine(flashHighlight);
            foreach (GameObject g in highlights)
            {
                g.SetActive(true);
            }
        }
    }
    public void DisableClipboardHighlight()
    {
        if (highlightEnabled)
        {
            StopCoroutine(flashHighlight);
            foreach (GameObject g in highlights)
            {
                g.SetActive(false);
            }
        }
    }

    private IEnumerator FlashHighlight()
    {
        while (true)
        {
            foreach (GameObject g in highlights)
            {
                if(g && g.activeInHierarchy)
                {
                    g.GetComponent<Renderer>().material.SetFloat(ShaderWidth, counter);
                }
                /*highlights[0].GetComponent<Renderer>().material.SetFloat(ShaderWidth, counter);
                highlights[1].GetComponent<Renderer>().material.SetFloat(ShaderWidth, counter);
                highlights[2].GetComponent<Renderer>().material.SetFloat(ShaderWidth, counter);*/
            }
                if (counter < 0.005f)
                {
                    up = true;
                }
                if(counter > 0.0125f)
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
