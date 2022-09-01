using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;

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
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log("I hit this thing: " + hit.transform.name);
            // TODO: add some hit effect for visual playes
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
        
    }
}
