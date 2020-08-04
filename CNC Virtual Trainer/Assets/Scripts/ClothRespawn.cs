using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothRespawn : MonoBehaviour
{

    public GameObject clothPrefab;
    public GameObject toolTableClothColliders;

    private Transform startTransform;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private GameObject currentCloth;

    private Cloth cloth;
    private CapsuleCollider[] clothColliders;

    void Start()
    {
        currentCloth = GameObject.Find("Cloth");
        startTransform = currentCloth.transform;
        startPosition = startTransform.position;
        startRotation = startTransform.rotation;
        clothColliders = toolTableClothColliders.GetComponentsInChildren<CapsuleCollider>();
    }
    
    void Update()
    {
        if (currentCloth.transform.position.y < 0)
        {
            Destroy(currentCloth);
            currentCloth = Instantiate(clothPrefab, startPosition, startRotation);
            cloth = currentCloth.GetComponentInChildren<Cloth>();
            cloth.capsuleColliders = clothColliders;
        }
    }
}
