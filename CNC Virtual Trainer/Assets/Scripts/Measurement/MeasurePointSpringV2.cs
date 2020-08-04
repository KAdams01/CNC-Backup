using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasurePointSpringV2 : MonoBehaviour
{
    //The four points around the measure tool
    public Transform pointSouth, pointNorth, pointEast, pointWest;
    //The rough distance that each point is from the the opposite edge of the ball at the end of the tool
    private float raycastDistance = 0.0177973f;
    public float pointBreakLimit = 500;
    public GameObject dial, pointSideAxis;
    //array to easily iterate and not repeat code
    private Transform[] allPoints;
    //The layer mask of the target
    public LayerMask blockLayer;
    private RaycastHit hit;
    //Storage byte for number of raycasts that have hit
    private byte hitCount;

    private float distanceToBlock;

    public Transform baseOfTool;

    public TipManager tipManager;

    public HighlightCreator highlightCreator;

    private GameObject highlight;
    private float previousHue, h, s, v;

    public GameObject questLog;
    private Logs logs;
    private string sideHitName;
    private IEnumerator beginRaycasts;

    private void Awake()
    {
        beginRaycasts = RaycastAllDirections();
    }
    private void Start()
    {
        previousHue = 0;
        pointSideAxis.SetActive(true);
        highlight = highlightCreator.CreateHighlightForGameObject(pointSideAxis);
        highlight.transform.SetParent(pointSideAxis.transform);
        highlight.SetActive(false);
        pointSideAxis.SetActive(false);
        logs = questLog.GetComponent<Logs>();
        gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        //Assign all of the points to an array for easier iteration
        allPoints = new Transform[4];
        allPoints[0] = pointSouth;
        allPoints[1] = pointNorth;
        allPoints[2] = pointEast;
        allPoints[3] = pointWest;
        StartCoroutine(beginRaycasts);
    }

    private Ray CreateRayForward(Transform origin)
    {
        return new Ray(origin.position, origin.forward);
    }

    IEnumerator RaycastAllDirections()
    {
        while (true)
        {
            //reset hit number
            hitCount = 0;
            foreach (Transform t in allPoints)
            {
                if (t.gameObject.activeInHierarchy)
                {
                    //Creates a raycast with each of the four points in allPoints, for the distance set and on the layer the target is on
                    if (Physics.Raycast(CreateRayForward(t), out hit, raycastDistance, blockLayer))
                    {
                        foreach(Transform t2 in allPoints)
                        {
                            if(t2.gameObject.name != t.gameObject.name)
                            {
                                t2.gameObject.SetActive(false);
                            }
                        }
                        //Rough math for equating the distance of 0.0001 movement in Unity to being 1. 0.001 being 10 etc.
                        distanceToBlock = Mathf.Round((raycastDistance - hit.distance) * 100000);
                        if (distanceToBlock > pointBreakLimit)
                        {
                            highlight.SetActive(false);
                            tipManager.SetBrokenTip();
                            Debug.Log("Tip broke from: " + t.gameObject.name);
                        }
                        if (distanceToBlock < 1000)
                        {
                            highlight.SetActive(true);
                            SetHueOfHighlight(hit.distance / raycastDistance - 0.6f);
                        }
                        //potential improvement to allow a little wiggle room when measuring
                        //if (distanceToBlock <= 205 && distanceToBlock<=195)
                        if (distanceToBlock == 200)
                        {
                            logs.CompleteQuest(17);
                        }
                        //Slightly redundant check, since this should always be a positive value after the above calculation
                        if (distanceToBlock > 0)
                        {
                            //Increases hit count so that dial is not reset on this iteration of the coroutine
                            hitCount++;
                            //Rotate the dial a distance relative to the value calculated above. The sweet spot seems to be around 1.8f, this could also be moved to a variable
                            dial.transform.localRotation = Quaternion.Euler(dial.transform.localRotation.x, -distanceToBlock * 1.8f, dial.transform.localRotation.z);
                        }
                    }
                }
            }
            if (hitCount == 0)
            {
                tipManager.isChangeable = true;
                ReturnDialToOriginalRotation();
                if (highlight && highlight.activeInHierarchy)
                {
                    highlight.SetActive(false);
                }

            }
            else
            {
                tipManager.isChangeable = false;
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
    //Return the dial to the rotation relative to parent that is had at the start. Easiest way to do this was to use something else that never rotates relative to parent
    private void ReturnDialToOriginalRotation()
    {
        if (dial.transform.rotation != baseOfTool.rotation)
        {
            dial.transform.rotation = baseOfTool.rotation;
        }
    }
    //Stop measuring and reset the dial
    private void OnDisable()
    {
        foreach (Transform t2 in allPoints)
        {
                t2.gameObject.SetActive(true);
        }
        StopCoroutine(beginRaycasts);
        ReturnDialToOriginalRotation();
    }
}
