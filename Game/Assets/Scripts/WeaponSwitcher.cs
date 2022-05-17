using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currWeapon = 0;
    void Start()
    {
        SetWeaponActive();
    }

    // Update is called once per frame
    void Update()
    {
        int pWeapon = currWeapon;
        PKeyInput();
        if (pWeapon != currWeapon)
            SetWeaponActive();

    }

  

    private void PKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currWeapon = 1;
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform w in transform)
        {
            if (weaponIndex == currWeapon)
            {
                w.gameObject.SetActive(true);
            }else
                w.gameObject.SetActive(false);

            weaponIndex++;
        }
    }
}
