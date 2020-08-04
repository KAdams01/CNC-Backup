using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField]
    private Light leftLight, rightLight;
    [SerializeField]
    private bool shouldLightsFlash = true;
    private bool coroutineRunning;
    private IEnumerator flashLights;
    // Start is called before the first frame update
    void Awake()
    {
        flashLights = FlashLights();
    }
    private IEnumerator FlashLights()
    {
        coroutineRunning = true;
        yield return new WaitForSeconds(0.5f);
        LightsOn();
        yield return new WaitForSeconds(0.1f);
        LightsOff();
        yield return new WaitForSeconds(0.1f);
        LightsOn();
        yield return new WaitForSeconds(0.1f);
        LightsOff();
        yield return new WaitForSeconds(0.1f);
        LightsOn();
        yield return new WaitForSeconds(0.2f);
        LightsOff();
        yield return new WaitForSeconds(0.3f);
        LightsOn();
        coroutineRunning = false;
    }
    private void LightsOn()
    {
        leftLight.range = 5;
        rightLight.range = 5;
    }
    public void TurnLightsOn()
    {
        if (!coroutineRunning)
        {
            if (shouldLightsFlash)
            {
                flashLights = FlashLights();
                StartCoroutine(flashLights);
            }
            else
            {
                LightsOn();
            }
        }
    }
    private void LightsOff()
    {
        leftLight.range = 0;
        rightLight.range = 0;
    }
    public void TurnLightsOff()
    {
        if (coroutineRunning)
        {
            StopCoroutine(flashLights);
            coroutineRunning = false;
        }
        shouldLightsFlash = false;
        LightsOff();
    }
}
