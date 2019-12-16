using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class UnitContoller : MonoBehaviour
{
    public GameObject explosion;
    private Transform gotransform;
    public float health;


    private void Awake()
    {
        gotransform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagsDictionary.TagPlayerProjectile))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        health--;
        if (health <= 0f)
        {
            Destroy();
        }
    }


    public void Destroy()
    {
        Object gameEffect = Instantiate(explosion, gotransform.position, gotransform.rotation);
        Destroy(gameEffect, 1.5f);
        Destroy(gameObject);
    }
}
