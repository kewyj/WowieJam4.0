using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Cannon : MonoBehaviour
{
    public bool isPlaced;

    // Start is called before the first frame update
    void Start()
    {
        isPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPlaced && collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            collision.gameObject.GetComponent<PlayerJump>().Cannon = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (isPlaced && collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<PlayerJump>().Cannon = false;
        }
    }
}
