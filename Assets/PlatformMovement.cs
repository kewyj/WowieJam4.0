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
        transform.Translate(-Time.deltaTime * speed, 0, 0);
        if (transform.position.x < -960 - transform.localScale.x * 15.0f - 100.0f)
            Destroy(gameObject);
    }
}
