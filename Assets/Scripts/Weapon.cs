using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    [SerializeField] float range = 100f;

    private Camera FPCamera;


    private void Awake()
    {
        FPCamera = GetComponentInParent<Camera>();    
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out RaycastHit hit, range);

        if (hit.transform != null)
        {
            Debug.Log("I hit this thing: " + hit.transform.name);
        }
        
    }
}
