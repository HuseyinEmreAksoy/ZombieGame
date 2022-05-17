using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;
    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }
    public void AttackEvent()
    {
        if (target == null)
            return;
        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowImpact();
        Debug.Log("Baaang");
    }
    public void OnDamageTaken()
    {
        Debug.Log("Take Damage");
    }
}
