using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HilightCreatorTest : MonoBehaviour
{
    public bool testOutliner = false;
    public HighlightCreator highlighter;
    public GameObject testObject;
    private GameObject highlightedObject;
    [Range(0, 0.333f)]
    public float hue = 0;
    private float previousHue;

    private float h, s, v;

    private void Awake()
    {
        previousHue = hue;
    }

    // Update is called once per frame
    void Update()
    {
        if (testOutliner)
        {
            highlightedObject = highlighter.CreateHighlightForGameObject(testObject);
            if(highlightedObject != null)
            {
                highlightedObject.SetActive(true);
            }
            testOutliner = false;
        }
        if(hue != previousHue)
        {

            Renderer highlightRenderer = highlightedObject.GetComponent<Renderer>();
            Color.RGBToHSV(highlightRenderer.material.GetColor("g_vOutlineColor"), out h, out s, out v);
            Color temp = highlightRenderer.material.GetColor("g_vOutlineColor");
            temp = Color.HSVToRGB(hue, s, v);
            highlightRenderer.material.SetColor("g_vOutlineColor", temp);
            previousHue = hue;
        }
            

    }
}
