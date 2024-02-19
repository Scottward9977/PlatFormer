using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHandlet : MonoBehaviour
{
    // CREATED BY NF

    [SerializeField] Transform playerFeetTransform;
    [SerializeField] BoxCollider2D boxCollider;
    float topOfBound;
    float dropTimer;

    // Start is called before the first frame update
    void Start()
    {
        topOfBound = boxCollider.bounds.center.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (topOfBound < playerFeetTransform.position.y && dropTimer <= 0)
        {
            boxCollider.enabled = true;
            if (Input.GetKeyDown(KeyCode.S))
            {
                boxCollider.enabled = false;
                dropTimer = 60;
            }
        }
        else
        {
            boxCollider.enabled = false;
        }
        dropTimer--;
    }
}
