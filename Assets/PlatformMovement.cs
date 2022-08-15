using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
        if (GameObject.Find("MenuManager").GetComponent<MenuManager>().paused) return;

        transform.Translate(-Time.deltaTime * speed, 0, 0);
        if (transform.position.x < -4000)
            Destroy(gameObject);
    }
}
