using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoTet;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            DisplayAmmo();
            Shoot();

        }
    }
    private void DisplayAmmo()
    {
        int curr = ammoSlot.GetCurrentAmount(ammoType);
        ammoTet.text = curr.ToString();
    }
    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmount(ammoType) > 0)
        {
            ammoSlot.ReduceCurrentAmount(ammoType);
            RaycastHit hit;
            if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
            {
                CreateHitImpact(hit);
                Debug.Log("I hit this: " + hit.transform.name);
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
    public void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);   
    }
}
