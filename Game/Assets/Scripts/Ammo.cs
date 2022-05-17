using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }
    public int GetCurrentAmount(AmmoType a)
    {
        return GetAmmoSlot(a).ammoAmount;
    }
    public void ReduceCurrentAmount(AmmoType a)
    {
        GetAmmoSlot(a).ammoAmount--;
    }
    public void IncreaseCurrentAmount(AmmoType a, int count)
    {
        GetAmmoSlot(a).ammoAmount += count;
    }
    private AmmoSlot GetAmmoSlot(AmmoType a)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == a)
            {
                return slot;
            }
        }
        return null;
    }
}
