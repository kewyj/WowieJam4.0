using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Drag : MonoBehaviour
{
    private AudioSource Sound;

    private Vector3 initial;
    private Vector3 offset;
    private float placeAt;
    private bool placeItem = false;
    public bool isPlaced;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        initial = gameObject.transform.position;
        isPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaced == true)
        {
            gameObject.layer = 0;
        }
        else
        {
            gameObject.layer = 5;
        }
    }
 
    void OnMouseDown()
    {
        if (isPlaced || GameObject.FindWithTag("GameController").GetComponent<ControlGeneration>().started == false) return;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    }

    void OnMouseDrag()
    {
        if (isPlaced || GameObject.FindWithTag("GameController").GetComponent<ControlGeneration>().started == false) return;
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) + offset;
    }

    void OnMouseUp()
    {
        if (isPlaced || GameObject.FindWithTag("GameController").GetComponent<ControlGeneration>().started == false) return;
        if (placeItem == true)
        {
            isPlaced = true;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, placeAt, 0);
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
        if (isPlaced && CollisionItem.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;

            if(gameObject.tag == "Jump")
                CollisionItem.GetComponent<PlayerJump>().Jumppad = true;
            else if (gameObject.tag == "Cannon")
                CollisionItem.GetComponent<PlayerJump>().Cannon = true;

            if (gameObject.tag != "Bridge")
                Sound.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        GameObject CollisionItem = collision.gameObject;
        if (CollisionItem.tag == "Platform")
        {
            placeItem = false;
        };
        if (isPlaced && CollisionItem.tag == "Player")
        {
            if (gameObject.tag == "Jump")
                CollisionItem.GetComponent<PlayerJump>().Jumppad = false;
            else if (gameObject.tag == "Cannon")
                CollisionItem.GetComponent<PlayerJump>().Cannon = false;

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
