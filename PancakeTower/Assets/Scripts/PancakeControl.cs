using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private CapsuleCollider2D collider;
    private Transform trans;
    private bool onPlate = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        //trans.SetPositionAndRotation(new Vector3(trans.parent.position.x, trans.position.y, 0), 0.0f) = trans.parent.position.x;

        if (onPlate)
        {
            trans.position = new Vector3(trans.parent.position.x, trans.position.y, 0);

        }

    }

    

    void OnTriggerEnter2D(Collider2D collider2D)
    {

        if (collider2D.gameObject.name != "WallLeft" && collider2D.gameObject.name != "WallRight")
        {
            rb2d.gravityScale = 0;
            rb2d.velocity = new Vector2(0.0f, 0.0f);
            onPlate = true;

            GetComponent<Transform>().SetParent(collider2D.transform);
            Debug.Log("Baaaaam");
        }
      

    }
}
