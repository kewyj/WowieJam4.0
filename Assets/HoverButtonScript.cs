using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverButtonScript : MonoBehaviour {

  // Start is called before the first frame update
  void Start() {
    gameObject.GetComponent<Animator>().Play("NotBreathingAnimation");
  }

  // Update is called once per frame
  void Update() {
    if (IsMouseOverUI()) {
      gameObject.GetComponent<Animator>().Play("ButtonBreathingAnimation");
    } else {
      gameObject.GetComponent<Animator>().Play("NotBreathingAnimation");
    }

  }

  private bool IsMouseOverUI() {
    return EventSystem.current.IsPointerOverGameObject();
  }

}
