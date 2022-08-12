using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class DropSnap : MonoBehaviour
{
    private bool snapped = false;
    private GameObject DropItem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DropItem == null) return;
        if (DropItem.GetComponent<DragSnap>().snapped == true)
            snapped = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (snapped == true) return;

        DropItem = collision.gameObject;
        DropItem.GetComponent<DragSnap>().snapItem = true;
        DropItem.GetComponent<DragSnap>().snapTo = gameObject.transform.position;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<DragSnap>().snapItem = false;
    }
}
