using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetItem : MonoBehaviour
{
    private Quaternion startRotation;
    private Transform parentTransform;

    private void Awake()
    {
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
        print("Kevin");
        yield return new WaitForSeconds(seconds);
        print("fuck kevin");
        this.gameObject.transform.position = parentTransform.position;
        this.gameObject.transform.rotation = startRotation;

        Rigidbody temp = gameObject.GetComponent<Rigidbody>();
        if (temp != null)
        {
            temp.velocity = Vector3.zero;
            temp.angularVelocity = Vector3.zero;
        }
    }
}
