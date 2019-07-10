using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;
    private Transform trans;
    public float speed;
    public static bool plateHit = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0f,0f);
        //rigidbody2D.AddForce(movement * speed);
        trans.position += movement * speed;

    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.name == "WallLeft" || collider2D.gameObject.name == "WallRight")
        {
            rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
        }
        else
        {
            Debug.Log("plateHit");

            plateHit = true;
        }
        //Debug.Log("Baaaaam");

    }
}
