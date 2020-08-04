using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public GameObject toolHolder;
    public Material dirty;
    public Material clear;
    bool clean;
    public GameObject questLog;
    private Logs logs;
    // Start is called before the first frame update
    void Start()
    {
        
        clean = false;
        toolHolder.GetComponent<Renderer>().material = dirty;
        logs = questLog.GetComponent<Logs>();

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Cloth")
        {
            cleanTool();
        }
    }

    void cleanTool()
    {
        clean = true;
        toolHolder.GetComponent<Renderer>().material = clear;
        logs.CompleteQuest(8);
    }

    public void makeToolDirtyAgain()
    {
        clean = false;
        toolHolder.GetComponent<Renderer>().material = dirty;
    }

    public bool isClean()
    {
        return clean;
    }
}
