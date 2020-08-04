using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightCreator : MonoBehaviour
{
    public Material highlightMaterial;

    private Material materialCreatedAtRuntime;

    private List<GameObject> allCreatedHighlights;

    private void Awake()
    {
        allCreatedHighlights = new List<GameObject>();
    }

    public GameObject CreateHighlightForGameObject(GameObject go)
    {
        if (go.GetComponent<Renderer>() != null)
        {
            Material temp = Instantiate(highlightMaterial);
            GameObject highlightContainer = Instantiate(go, go.transform.position, go.transform.rotation);
            foreach(Component c in highlightContainer.GetComponents<Component>())
            {
                if(!(c is MeshRenderer || c is Transform || c is MeshFilter)){
                    Destroy(c);
                }
            }
            foreach(Transform t in highlightContainer.transform)
            {
                Destroy(t.gameObject);
            }
            highlightContainer.transform.localScale = CorrectGlobalScale(highlightContainer.transform, go.transform.lossyScale);
            highlightContainer.SetActive(false);
            Renderer rend = highlightContainer.GetComponent<Renderer>();
            rend.material = temp;
            highlightContainer.transform.SetParent(go.transform);
            allCreatedHighlights.Add(highlightContainer);
            return highlightContainer;
        }
        else
        {
            return null;
        }
    }

    private Vector3 CorrectGlobalScale(Transform goTransform, Vector3 globalScale)
    {
        goTransform.localScale = Vector3.one;
        return new Vector3(globalScale.x / goTransform.lossyScale.x, globalScale.y / goTransform.lossyScale.y, globalScale.z / goTransform.lossyScale.z);
    }

    public void SetAllHighlight(bool areHighlightersOn, int questNumber)
    {
        foreach (var go in allCreatedHighlights)
        {
            if (areHighlightersOn)
            {
                if (!go.activeInHierarchy)
                {
                    switch (questNumber)
                    {
                        case 2:
                            findHighlightInList("PowerOnBtn").SetActive(true);
                            break;
                        case 3:
                            findHighlightInList("EmergancyStopHeadStart").SetActive(true);
                            break;
                        case 5:
                            findHighlightInList("BlueBtn1").SetActive(true);
                            break;
                        case 6:
                            findHighlightInList("ShapedBtn004").SetActive(true);
                            break;
                        case 9:
                            findHighlightInList("MainBody").SetActive(true);
                            break;
                        case 10:
                            findHighlightInList("SelectArrowUp").SetActive(true);
                            break;
                        case 11:
                            findHighlightInList("SelectArrowRight").SetActive(true);
                            break;
                        case 12:
                            findHighlightInList("SelectArrowDown").SetActive(true);
                            break;
                        case 13:
                            findHighlightInList("Keypad7WhiteBtnUp").SetActive(true);
                            findHighlightInList("Keypad7WhiteBtn003").SetActive(true);
                            findHighlightInList("Keypad7WhiteBtnRight").SetActive(true);
                            findHighlightInList("Keypad7WhiteBtnDown").SetActive(true);
                            findHighlightInList("Keypad7WhiteBtn002").SetActive(true);
                            findHighlightInList("Keypad7WhiteBtnLeft").SetActive(true);
                            break;
                        case 14:
                            findHighlightInList("Keypad4Btn013").SetActive(true);
                            findHighlightInList("Keypad4Btn014").SetActive(true);
                            findHighlightInList("Keypad4Btn015").SetActive(true);
                            findHighlightInList("Keypad4Btn016").SetActive(true);
                            break;
                        case 15:
                            findHighlightInList("TurnableKnob").SetActive(true);
                            break;
                        case 18:
                            findHighlightInList("SelectArrowRight").SetActive(true);
                            findHighlightInList("SelectArrowLeft").SetActive(true);
                            break;
                        case 19:
                            findHighlightInList("Keypad5Btn008").SetActive(true);
                            break;
                        case 20:
                            findHighlightInList("Keypad3Btn010").SetActive(true);
                            break;
                        case 21:
                            findHighlightInList("Keypad3Btn009").SetActive(true);
                            findHighlightInList("Keypad3Btn012").SetActive(true);
                            break;
                        case 22:
                            findHighlightInList("Keypad3Btn015").SetActive(true);
                            break;
                    }
                }
            }
            else
            {
                if (go.activeInHierarchy)
                {
                    go.SetActive(false);
                }
            }
        }
    }

    private GameObject findHighlightInList(string name)
    {
        foreach (var go in allCreatedHighlights)
        {
            if (go.name == name + "(Clone)")
            {
                return go;
            }
        }

        return null;
    }
}
