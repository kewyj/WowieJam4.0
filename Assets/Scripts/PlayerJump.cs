using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerJump : MonoBehaviour
{
    public bool Jumppad;
    public bool Cannon;
    private Vector2 JumpSpeed;
    private Vector2 CannonSpeed;
    private Rigidbody2D Rigid;
    private AudioSource WalkingSound;

    public bool death;

    // Start is called before the first frame update
    void Start()
    {
        death = false;
        Jumppad = false;
        Cannon = false;
        JumpSpeed = new Vector2(0, 1500.0f);
        CannonSpeed = new Vector2(0, 3700.0f);
        Rigid = gameObject.GetComponent<Rigidbody2D>();
        WalkingSound = GetComponents<AudioSource>()[1];
        gameObject.transform.position = new Vector3(-700, -244, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -540)
            death = true;

        if (Jumppad == true)
        {
            Rigid.drag = 0;
            Rigid.gravityScale = 350;
            Rigid.velocity = new Vector2(Rigid.velocity.x, 0f);
            Rigid.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
        }
        if (Cannon == true)
        {
            Rigid.drag = 6;
            Rigid.velocity = new Vector2(Rigid.velocity.x, 0f);
            Rigid.AddForce(Vector2.up * CannonSpeed, ForceMode2D.Impulse);
            Rigid.gravityScale = 90;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Bridge") && Jumppad == false && Cannon == false)
        {
            Rigid.drag = 0;
            Rigid.gravityScale = 500;
            WalkingSound.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            WalkingSound.Stop();
        }
    }

    public void Restart()
    {
        gameObject.transform.position = new Vector3(-700, -244, 0);
        Start();
    }
}
