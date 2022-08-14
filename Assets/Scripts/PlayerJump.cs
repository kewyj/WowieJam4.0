using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerJump : MonoBehaviour
{
    public bool Jumppad = false;
    public bool Cannon = false;
    private Vector2 JumpSpeed = new Vector2(0, 1500.0f);
    private Vector2 CannonSpeed = new Vector2(0, 6200.0f);
    private Rigidbody2D Rigid;

    // Start is called before the first frame update
    void Start()
    {
        Rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Jumppad == true)
        {
            Rigid.drag = 0;
            Rigid.gravityScale = 100;
            Rigid.velocity = new Vector2(Rigid.velocity.x, 0f);
            Rigid.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
        }
        if (Cannon == true)
        {
            Rigid.drag = 15;
            Rigid.gravityScale = 100;
            Rigid.velocity = new Vector2(Rigid.velocity.x, 0f);
            Rigid.AddForce(Vector2.up * CannonSpeed, ForceMode2D.Impulse);
        }
        if (Jumppad == false && Cannon == false)
        {
            Rigid.gravityScale = 500;
        }
    }
}
