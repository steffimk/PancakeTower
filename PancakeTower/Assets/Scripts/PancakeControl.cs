using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private CapsuleCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        rb2d.gravityScale = 0;
        rb2d.velocity = new Vector2(0.0f, 0.0f);
        Debug.Log("Baaaaam");
    }
}
