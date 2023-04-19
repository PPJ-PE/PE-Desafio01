using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Subject
{
    public float playerHealth = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out IPainDealer painDealer))
        {
            float damage = painDealer.DealPain();
            playerHealth -= damage;
            if (playerHealth > 0)
            {
                NotifyDamage(damage);
            }
            else if (playerHealth <= 0f)
                NotifyDeath();
        }
    }
}
