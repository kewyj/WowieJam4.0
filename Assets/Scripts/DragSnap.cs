using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class DragSnap : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 initial;
    private Vector3 offset;
    public Vector3 snapTo;
    public bool snapItem = false;
    public bool snapped = false;

    // Start is called before the first frame update
    void Start()
    {
        initial = gameObject.transform.position;
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Cursor.visible = false;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        gameObject.transform.position = curPosition;
    }

    void OnMouseUp()
    {
        Cursor.visible = true;

        if (snapItem == true)
        {
            Destroy(GetComponent<Rigidbody2D>());
            gameObject.transform.position = snapTo;
            //gameObject.SetActive(false);

            snapped = true;
        }
        else
        {
            gameObject.transform.position = initial;
        }
    }
}
