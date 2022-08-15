using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class HoverButtonScript : MonoBehaviour {

  // Start is called before the first frame update
  void Start() {
    gameObject.GetComponent<Animator>().Play("NotBreathingAnimation");
  }

  // Update is called once per frame
  void Update() {

  }

  public void OnMouseEnter() {
    gameObject.GetComponent<Animator>().Play("ButtonBreathingAnimation");
  }

  public void OnMouseOver() {
    gameObject.GetComponent<Animator>().Play("ButtonBreathingAnimation");
  }

  public void OnMouseExit() {
    gameObject.GetComponent<Animator>().Play("NotBreathingAnimation");
  }

}
