using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCam;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 30f;
    bool isToggle = false;
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
            if (!isToggle)
            {
                isToggle = true;
                fpsCam.fieldOfView = zoomedInFOV;
            }
            else
            {
                isToggle = false;
                fpsCam.fieldOfView = zoomedOutFOV;
            }
    }
}
