using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Jumppad : MonoBehaviour
{
    float Speed = 0;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player)
        {
            Player.GetComponent<Rigidbody2D>().velocity = transform.forward * Speed;
            //Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + Speed);
            //--Speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player = collision.gameObject;
            Speed = 50;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {

    }
}
