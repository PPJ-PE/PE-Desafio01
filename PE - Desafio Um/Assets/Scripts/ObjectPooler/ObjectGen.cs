using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGen : MonoBehaviour
{
    public Projectile[] projectiles;
    public Transform[] launchPos;
    public bool canGenProj = false;
    public float genCD = 1.5f;

    private int randomShooter;
    private int randomOrb;
    ObjectPooling objPooler;
    Quaternion randomRot;

    void Start()
    {
        objPooler = ObjectPooling.Instance;
    }

    void FixedUpdate()
    {
        if (!canGenProj)
        {
            canGenProj = true;
            randomShooter = Random.Range(0, 4);
            randomOrb = Random.Range(0, 3);
            randomRot = Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));

            StartCoroutine(OrbFalling());
        }
    }

    IEnumerator OrbFalling()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == randomShooter)
            {
                if (randomOrb == 0)
                    objPooler.spawnFromPool("PROJECTILE_S", launchPos[randomShooter].transform.position, randomRot);
                if (randomOrb == 1)
                    objPooler.spawnFromPool("PROJECTILE_M", launchPos[randomShooter].transform.position, randomRot);
                if (randomOrb == 2)
                    objPooler.spawnFromPool("PROJECTILE_L", launchPos[randomShooter].transform.position, randomRot);
                yield return new WaitForSeconds(genCD);
            }
        }
        canGenProj = false;
    }
}
