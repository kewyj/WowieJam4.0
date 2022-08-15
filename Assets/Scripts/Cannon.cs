using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Cannon : MonoBehaviour
{
    public bool isPlaced;
    private AudioSource Sound;

    // Start is called before the first frame update
    void Start()
    {
        isPlaced = false;
        Sound = GetComponent<AudioSource>();
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
            Sound.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (isPlaced && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerJump>().Cannon = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
