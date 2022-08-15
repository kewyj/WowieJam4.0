using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Drag : MonoBehaviour
{
    private Vector3 initial;
    private Vector3 offset;
    private float placeAt;
    private bool placeItem = false;

    // Start is called before the first frame update
    void Start()
    {
        initial = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        switch (gameObject.tag)
        {
            case "Jump":
                if(gameObject.GetComponent<Jumppad>().isPlaced == true)
                {
                    gameObject.layer = 0;
                }
                else
                {
                    gameObject.layer = 5;
                }
                break;
            case "Cannon":
                if(gameObject.GetComponent<Cannon>().isPlaced == true)
                {
                    gameObject.layer = 0;
                }
                else
                {
                    gameObject.layer = 5;
                }
                break;
        }
        */
    }
 
    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        Cursor.visible = false;
    }

    void OnMouseDrag()
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) + offset;
    }

    void OnMouseUp()
    {
        Cursor.visible = true;

        if (placeItem == true)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, placeAt, 0);
            if (gameObject.tag == "Jump")
                gameObject.GetComponent<Jumppad>().isPlaced = true;
            else if (gameObject.tag == "Cannon")
                gameObject.GetComponent<Cannon>().isPlaced = true;
        }
        else
        {
            gameObject.transform.position = initial;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject CollisionItem = collision.gameObject;
        if (CollisionItem.tag == "Platform"){
            placeItem = true;
            placeAt = CollisionItem.transform.position.y + CollisionItem.transform.localScale.y * 20 - (gameObject.transform.localScale.y * 0.25f);
        };
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            placeItem = false;
        };
    }
}
