using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonScript : MonoBehaviour {

  public GameObject startButton;
  public UnityEngine.UI.Image startButtonImage;
  private float ratio;
  private float timer;
  private float maxTime;

  // Start is called before the first frame update
  void Start() {
    startButton = GameObject.Find("StartButton");
    startButtonImage = startButton.GetComponent<UnityEngine.UI.Image>();
    
    ratio = 0;
    timer = 0;
    maxTime = 0;
  }
  // Update is called once per frame
  void Update() {
    
    if (timer > 0) { 
      timer -= Time.deltaTime;
      ratio = timer / maxTime;
      startButtonImage.color.a = ratio;
    }



  }

  public void OnClick() {
    timer = maxTime;
  }

}
