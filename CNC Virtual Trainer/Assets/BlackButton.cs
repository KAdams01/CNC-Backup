using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BlackButton : MonoBehaviour
{

    private bool pressed;
    //private SpawnTool spawnTool;

    void Start()
    {
       // spawnTool = GameObject.FindObjectOfType<SpawnTool>();
    }


  /*  public void buttonPressed()
    {
        pressed = true;
        if (spawnTool.inserted)
        {
            //allow the parent to be interactable
            Destroy(spawnTool.tool.GetComponent<IgnoreHovering>());
            foreach (Transform t in spawnTool.tool.transform)
            {
                Destroy(t.gameObject.GetComponent<IgnoreHovering>());
            }
            
        }
    }

    public void buttonReleased()
    {
        pressed = false;
        if (spawnTool.inserted)
        {
            spawnTool.tool.gameObject.AddComponent<IgnoreHovering>();
            foreach (Transform t in spawnTool.tool.transform)
            {
                t.gameObject.AddComponent<IgnoreHovering>();
            }
        }
   }
    public bool isPressed()
    {
        return pressed;
    }*/
}
