using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasurePointSpring : MonoBehaviour
{
    //Reference to something that does not rotate relative to parent, to reset dial back to
    public GameObject baseOfSensor;
    //The arrow on the dial
    public GameObject dial;
    //Distance and previous frame distance, to save on performance, rotation of dial not updated of these two match
    private float distance;
    private float previousFrameDistance;

    //forward(downward relative to world) direction.
    private Ray raycastForward;
    private RaycastHit hit;
    //The layer of the target
    public LayerMask layerToHit;
    //The initial contact point of the tip, this is used to measure distance from after the tool is lowered/raised
    private Vector3 pointOfContact;

    //The rough size from raycast point to the end of the tool
    private readonly float distanceToTip = 0.01883656f;
    //Position relative to parent, set OnEnable so that the tip can be moved back if needed
    private Vector3 originalLocalPosition;
    public float pointBreakLimit = 500;
    private TipManager tipManager;
    public HighlightCreator highlightCreator;

    private GameObject highlight;
    private float previousHue, h, s, v;
    public GameObject questLog;
    private Logs logs;


    private void Awake()
    {
        tipManager = GameObject.FindObjectOfType<TipManager>();

        logs = questLog.GetComponent<Logs>();
    }

    private void Start()
    {
        highlight = highlightCreator.CreateHighlightForGameObject(gameObject);
        highlight.transform.SetParent(transform);
        highlight.SetActive(false);
    }

    private void OnEnable()
    {
        originalLocalPosition = transform.localPosition;
        StartCoroutine(VerticalMeasurement());

    }

    IEnumerator VerticalMeasurement()
    {
        while (true)
        {
            //Ray from the base of the measurement tool towards the end of the tool.
            raycastForward = new Ray(baseOfSensor.transform.position, -baseOfSensor.transform.forward);
            //if the above ray hits something within the length of the end of the tool on the target layer
            if (Physics.Raycast(raycastForward, out hit, distanceToTip, layerToHit))
            {
                highlight.SetActive(true);
                //The point that the first raycast hit
                pointOfContact = hit.point;
                //The distance between the base of the sensor and the point that was hit
                distance = Vector3.Distance(baseOfSensor.transform.position, pointOfContact);
                SetHueOfHighlight(distance / distanceToTip - 0.7f);
                //If there has been a change of distance in this iteration
                if (previousFrameDistance != distance)
                {
                    //Move the tip of the tool relative to the distance
                    Vector3 movePoint = baseOfSensor.transform.position;
                    movePoint.y -= (distance - 0.01091813f);
                    transform.position = movePoint;

                    //Adjusted distance to make 0.0001f unity distance roughly equal to 1
                    float distanceAdjusted = Mathf.Round((distanceToTip - distance) * 100000);
                    if (distanceAdjusted > pointBreakLimit)
                    {
                        ResetTipToOriginalLocation();
                        tipManager.SetBrokenTip();
                    }

                    if (distanceAdjusted == 200)
                    {
                        logs.CompleteQuest(17);
                    }
                    //Redundant check, this value should always be above 0
                    if (distanceAdjusted > 0)
                    {
                        tipManager.isChangeable = false;
                        dial.transform.localRotation = Quaternion.Euler(dial.transform.localRotation.x, -distanceAdjusted * 1.8f, dial.transform.localRotation.z);
                    }
                    else
                    {
                        ResetTipToOriginalLocation();
                    }
                    previousFrameDistance = distance;
                }
            }
            else
            {
                tipManager.isChangeable = true;
                previousFrameDistance = 0;
                ReturnDialToOriginalRotation();
                ResetTipToOriginalLocation();
                if (highlight != null)
                {

                    SetHueOfHighlight(0.3f);
                    highlight.SetActive(false);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void SetHueOfHighlight(float hue)
    {
        if (hue != previousHue)
        {
            Renderer highlightRenderer = highlight.GetComponent<Renderer>();
            Color.RGBToHSV(highlightRenderer.material.GetColor("g_vOutlineColor"), out h, out s, out v);
            Color temp = highlightRenderer.material.GetColor("g_vOutlineColor");
            temp = Color.HSVToRGB(hue, s, v);
            highlightRenderer.material.SetColor("g_vOutlineColor", temp);
            previousHue = hue;
            logs.CompleteQuest(16);
        }
    }
    private void ReturnDialToOriginalRotation()
    {
        if (dial.transform.rotation != baseOfSensor.transform.rotation)
        {
            dial.transform.rotation = baseOfSensor.transform.rotation;
        }
    }
    private void ResetTipToOriginalLocation()
    {
        if (highlight != null)
        {
            highlight.SetActive(false);

        }
        transform.localPosition = originalLocalPosition;
    }
    private void OnDisable()
    {
        StopCoroutine(VerticalMeasurement());
        ReturnDialToOriginalRotation();
    }
}
