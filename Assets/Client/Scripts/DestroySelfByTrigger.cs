using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfByTrigger: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagsDictionary.TagEnemy))
        {
            Destroy(gameObject);
        }
    }
}
