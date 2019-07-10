using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private CapsuleCollider2D collider;
    private Transform trans;
    private bool onPlate = false;
    public bool topPancake = true;
    private bool isColliding = false;
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
        if (isColliding) return;
        isColliding = true;
        Debug.Log("onTrigger: " + collider2D.gameObject.name);
        if (IsHit(collider2D))
        {
            Debug.Log(collider2D.gameObject.name);
            rb2d.gravityScale = 0;
            rb2d.velocity = new Vector2(0.0f, 0.0f);
            onPlate = true;
            GetComponent<Transform>().SetParent(collider2D.transform);
            Debug.Log("Baaaaam");
        }
        else
        {
            if (collider2D.gameObject.name.Length > 10)
            {
                Debug.Log("sub: " + collider2D.gameObject.name.Substring(0, 11));

            }
            if (collider2D.gameObject.name == "Pfannkuchen" && onPlate)
            {
                
                if(collider.GetComponent<PancakeControl>().topPancake)
                {

                    this.topPancake = false;

                }
                Debug.Log("berührung ");

            }
        }




        StartCoroutine(Reset());
        


    }
    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }

    bool IsHit(Collider2D collider2D)
    {
        Debug.Log(collider2D.gameObject.name);
        return collider2D.gameObject.name != "WallLeft" && collider2D.gameObject.name != "WallRight" && collider2D.gameObject.name == "plate" && !PlateController.plateHit || collider2D.gameObject.name == "Pfannkuchen" && collider2D.gameObject.GetComponent<PancakeControl>().topPancake && !onPlate;
    }
}
