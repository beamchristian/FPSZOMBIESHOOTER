using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Parameters & Muzzleflash Effect")]
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;

    [Header("Impact Effects")]
    [SerializeField] GameObject zombieHitEffect;
    [SerializeField] GameObject concreteHitEffect;
    [SerializeField] GameObject metalHitEffect;
    [SerializeField] GameObject woodHitEffect;
    [SerializeField] GameObject grassHitEffect;
    [SerializeField] GameObject leavesHitEffect;

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
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        LayerMask zombieMask = LayerMask.GetMask("Zombie");
        LayerMask concreteMask = LayerMask.GetMask("Concrete");
        LayerMask metalMask = LayerMask.GetMask("Metal");
        LayerMask woodMask = LayerMask.GetMask("Wood");
        LayerMask grassMask = LayerMask.GetMask("Grass");
        LayerMask leavesMask = LayerMask.GetMask("Leaves");

        RaycastHit hit;
        // Zombie hit impact
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range, zombieMask))
        {
            CreateZombieHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        // Concrete hit impact
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range, concreteMask))
        {
            CreateConcreteHitImpact(hit);
        }
        // Metal hit impact
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range, metalMask))
        {
            CreateMetalHitImpact(hit);
        }
        // Wood hit impact
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range, woodMask))
        {
            CreateWoodHitImpact(hit);
        }
        // Grass hit impact
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range, grassMask))
        {
            CreateGrassHitImpact(hit);
        }
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range, leavesMask))
        {
            CreateLeavesHitImpact(hit);
        }
        else
        {
            return;
        }
    }

    // Hit impact methods ======================================================================================== >>

    private void CreateZombieHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(zombieHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }

    private void CreateConcreteHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(concreteHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }

    private void CreateMetalHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(metalHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }

    private void CreateWoodHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(woodHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }

    private void CreateGrassHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(grassHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }

    private void CreateLeavesHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(leavesHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }

    // ============================================================================================================= >>
}
