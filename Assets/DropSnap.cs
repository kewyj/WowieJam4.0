using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class DropSnap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<DragSnap>().snapItem = true;
        collision.gameObject.GetComponent<DragSnap>().snapTo = gameObject.transform.position;
    }

    void OnCollisionExit(Collision collision)
    {
        collision.gameObject.GetComponent<DragSnap>().snapItem = false;
    }
}
