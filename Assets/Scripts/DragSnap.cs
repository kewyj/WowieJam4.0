using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class DragSnap : MonoBehaviour
{
    private Vector3 initial;
    private Vector3 offset;

    public Vector3 snapTo;
    public bool snapItem = false;
    public bool allowSnap = true;

    private Rigidbody2D Rigid;

    // Start is called before the first frame update
    void Start()
    {
        allowSnap = true;

        if (GetComponent<Rigidbody2D>())
        {
            Rigid = GetComponent<Rigidbody2D>();
            Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        initial = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (allowSnap == true)
        {
            if (Rigid) Rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Cursor.visible = false;
        }
    }

    void OnMouseDrag()
    {
        if (allowSnap == true)
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) + offset;
    }

    void OnMouseUp()
    {
        if (allowSnap == true)
        {
            Cursor.visible = true;

            if (snapItem == true)
            {
                if (Rigid) Destroy(Rigid);
                gameObject.transform.position = snapTo;
                allowSnap = false;
            }
            else
            {
                if (Rigid) Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
                gameObject.transform.position = initial;
            }
        }
    }
}
