using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrower : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectile;
    private float orbVelocity = 10f;


    virtual public void Throw(Projectile proj)
    {
        var _proj = Instantiate(proj, launchPoint.position, Quaternion.identity);
        _proj.GetComponent<Rigidbody>().velocity = launchPoint.up * orbVelocity;
    }
}
