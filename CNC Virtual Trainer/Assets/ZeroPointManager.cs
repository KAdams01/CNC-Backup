using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroPointManager : MonoBehaviour
{
    public Transform drill, workbench;
    private Vector3 drillPositionRelative, workbenchPositionRelative;


    // Start is called before the first frame update

    //Workbench
    public void MovePointX()
    {
        transform.position = new Vector3(workbench.transform.position.x, transform.position.y, transform.position.z);
    }
    public void MovePointZ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, workbench.transform.position.z);
    }
    //Drill
    public void MovePointY()
    {
        transform.position = new Vector3(transform.position.x, drill.position.y, transform.position.z);
    }
}
