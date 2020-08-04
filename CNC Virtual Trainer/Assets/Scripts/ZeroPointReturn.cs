using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroPointReturn : MonoBehaviour
{
    public float speed;

    public GameObject workbench, drill;
    public Transform workbenchZeroPoint, drillZeroPoint;

    private IEnumerator zeroReturnInstance = null;
    private bool isCoroutineStarted = false;
    private bool drillInPosition, benchInPosition;

    public void ReturnMachineToZeroPoint()
    {
        if (!isCoroutineStarted)
        {
            zeroReturnInstance = ReturnToZeroPoint();
            StartCoroutine(zeroReturnInstance);
        }
    }
    public void StopMachineReturn()
    {
        if(zeroReturnInstance != null)
        {
            StopCoroutine(zeroReturnInstance);
            isCoroutineStarted = false;
        }
    }
    private IEnumerator ReturnToZeroPoint()
    {
        StartupStateManager.isMachineMoving = true;
        float workbenchDistance = Vector3.Distance(workbench.transform.position, workbenchZeroPoint.transform.position) / speed;
        float drillDistance = Vector3.Distance(drill.transform.position, drillZeroPoint.transform.position) / speed;
        isCoroutineStarted = true;
        while (true)
        {
            if (workbench.transform.position != workbenchZeroPoint.transform.position)
            {
                workbench.transform.position = Vector3.MoveTowards(workbench.transform.position, workbenchZeroPoint.transform.position, workbenchDistance);
            }
            else
            {
                benchInPosition = true;
            }

            if (drill.transform.position != drillZeroPoint.transform.position)
            {
                drill.transform.position = Vector3.MoveTowards(drill.transform.position, drillZeroPoint.transform.position, drillDistance);
            }
            else
            {

                drillInPosition = true;
            }

            if (drillInPosition && benchInPosition)
            {
                drillInPosition = false;
                benchInPosition = false;
                StartupStateManager.isMachineMoving = false;
                break;
            }

            else
            {
                yield return new WaitForSeconds(0.01f);
            }

        }
        isCoroutineStarted = false;
    }
}
