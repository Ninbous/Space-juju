using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody rb;
    private BoxCollider collider;
    private Vector3 direction;
    public float moveSpeed = 10f;

    // Bit shift the index of the layer (8) to get a bit mask
    int layerMask = 1 << 8;
    bool isPlayerCollider = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if (Physics.Raycast(touchPosition, Vector3.down, out var hit, Mathf.Infinity, layerMask))
                {
                    if (hit.collider == collider)
                    {
                        isPlayerCollider = true;
                    }
                }
            }

            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = 10;

            if (isPlayerCollider)
            {
                direction = (touchPosition - transform.position);
                rb.velocity = new Vector3(direction.x, 0, direction.z) * moveSpeed;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
                isPlayerCollider = false;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            isPlayerCollider = false;
        }
    }
}