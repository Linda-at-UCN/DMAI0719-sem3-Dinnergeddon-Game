using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigiBody : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Add a force to the Rigidbody.
        rb.AddForce(Vector3.up * 10f);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
