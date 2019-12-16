using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        gameObject.GetComponent<UnitContoller>().Destroy();
    }
}
