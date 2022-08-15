using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject CollisionItem = collision.gameObject;
        if (CollisionItem.tag == "Player")
            CollisionItem.GetComponent<PlayerJump>().death = true;
    }
}
