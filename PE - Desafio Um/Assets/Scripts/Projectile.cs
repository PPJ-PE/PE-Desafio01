using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IPainDealer
{
    public float damage;

    public float DealPain()
    {
        gameObject.SetActive(false);
        return damage;
    }

    
}
