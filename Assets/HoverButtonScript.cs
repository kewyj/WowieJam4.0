using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class HoverSmallButtonScript : MonoBehaviour {

  // Start is called before the first frame update
  void Start() {
    gameObject.GetComponent<Animator>().Play("SmallButtonNotBreathing");
  }

  // Update is called once per frame
  void Update() {

  }

  public void OnMouseEnter() {
    gameObject.GetComponent<Animator>().Play("SmallButtonBreathing");
  }

  public void OnMouseExit() {
    gameObject.GetComponent<Animator>().Play("SmallButtonNotBreathing");
  }

}
