using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Invoke("FallDown", 0.5f);
        }
    }

    private void FallDown()
    {
        var rb = GetComponentInParent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;

        Destroy(transform.parent.gameObject, 2);
    }
}
