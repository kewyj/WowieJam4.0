using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        speed = 0;
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
