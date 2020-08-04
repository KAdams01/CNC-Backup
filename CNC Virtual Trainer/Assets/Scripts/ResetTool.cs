using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ResetTool : MonoBehaviour
{
    private Quaternion startRotation;
    private Transform parentTransform;
    private TipManager tipManager;
    private Tool tool;

    private void Awake()
    {
        tipManager = GameObject.FindObjectOfType<TipManager>();
        tool = GameObject.FindObjectOfType<Tool>();
        startRotation = transform.rotation;
        parentTransform = transform.parent;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Trash bin")
        {
            StartCoroutine(DestroyObjectAfter(2));
        }
    }

    IEnumerator DestroyObjectAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        foreach(Transform t in transform)
        {
            Destroy(transform.gameObject.GetComponent<IgnoreHovering>());
            foreach(Component c in t.gameObject.GetComponents<Component>())
            {
                if (c is IgnoreHovering)
                {
                    Destroy(c);
                }
            }

        }
        gameObject.transform.position = parentTransform.position;
        gameObject.transform.rotation = startRotation;
        Rigidbody temp = gameObject.GetComponent<Rigidbody>();
        temp.velocity = Vector3.zero;
        temp.angularVelocity = Vector3.zero;
        tipManager.ResetTip();
        tool.makeToolDirtyAgain();
    }

}
