using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiedScript : MonoBehaviour {

  private Rigidbody2D Rigid;
  public bool died;
  private AudioSource Sound;

  // Start is called before the first frame update
  void Start() {
    Rigid = gameObject.GetComponent<Rigidbody2D>();
    died = false;
    Sound = GetComponents<AudioSource>()[2];
  }

  // Update is called once per frame
  void Update() {
    if (GameObject.Find("BlindRobot").GetComponent<PlayerJump>().death) Die();    
  }

  public void Die() {
    Sound.Play();
    died = true;
    Rigid.drag = 0;
    Rigid.gravityScale = 350;
    Rigid.velocity = new Vector2(Rigid.velocity.x, 0f);
    Rigid.AddForce(Vector2.up * new Vector2(0, 1000.0f), ForceMode2D.Impulse);
    GameObject.Find("MenuManager").GetComponent<MenuManager>().OnRestartClick();
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (died) Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
  }
}
