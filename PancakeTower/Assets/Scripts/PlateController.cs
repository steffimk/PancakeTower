using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{

    Rigidbody2D rigidbody2D;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0f);
        rigidbody2D.AddForce(movement * speed);

    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.name == "WallLeft" || collider2D.gameObject.name == "WallRight")
        {
            rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
            Debug.Log("Baaaaam");
        }

    }
}
