using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Time.deltaTime * speed, 0, 0);
        if (transform.position.x < -1920)
            transform.position = transform.position + new Vector3(3840.0f, 0, 0);
    }
}
