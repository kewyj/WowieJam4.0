using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

  public GameObject startButton;
  public GameObject pauseButton;
  public GameObject restartButton;
  public GameObject helpButton;
  public GameObject pauseCenter;
  public GameObject blackScreen;

  public UnityEngine.UI.Image startButtonImage;
  public UnityEngine.UI.Image pauseButtonImage;
  public UnityEngine.UI.Image restartButtonImage;
  public SpriteRenderer blackScreenImage;

  private float ratio;
  private float timer;
  private float maxTime;
  private bool paused;

  // Start is called before the first frame update
  void Start() {
    startButton = GameObject.Find("StartButton");
    pauseButton = GameObject.Find("PauseButton");
    restartButton = GameObject.Find("RestartButton");
    helpButton = GameObject.Find("HelpButton");
    pauseCenter = GameObject.Find("PauseCenter");
    blackScreen = GameObject.Find("BlackScreen");

    startButtonImage = startButton.GetComponent<UnityEngine.UI.Image>();
    pauseButtonImage = pauseButton.GetComponent<UnityEngine.UI.Image>();
    restartButtonImage = restartButton.GetComponent<UnityEngine.UI.Image>();
    blackScreenImage = blackScreen.GetComponent<SpriteRenderer>();

    RestartMenu();
    maxTime = 2;
  }
  // Update is called once per frame
  void Update() {

    // If start was pressed
    if (timer > 0) {
      timer -= Time.deltaTime;
      if (timer < 0) {
        timer = 0;
        startButton.SetActive(false);
      }
      ratio = timer / maxTime;

      Color temp = startButton.GetComponent<UnityEngine.UI.Image>().color;
      startButton.GetComponent<UnityEngine.UI.Image>().color = new Color(temp.r, temp.g, temp.b, ratio);

      temp = pauseButton.GetComponent<UnityEngine.UI.Image>().color;
      pauseButton.GetComponent<UnityEngine.UI.Image>().color = new Color(temp.r, temp.g, temp.b, 1-ratio);
      temp = restartButton.GetComponent<UnityEngine.UI.Image>().color;
      restartButton.GetComponent<UnityEngine.UI.Image>().color = new Color(temp.r, temp.g, temp.b, 1-ratio);
    }

    if (paused && Input.GetMouseButtonDown(0)) {
      paused = false;
      pauseButton.SetActive(true);
      restartButton.SetActive(true);
      blackScreen.SetActive(false);
      pauseCenter.SetActive(false);

    }

  }

  public void OnStartClick() {
    if (timer > 0) return;
    timer = maxTime;
    pauseButton.SetActive(true);
    restartButton.SetActive(true);
    helpButton.SetActive(false);
  }

  public void OnPauseClick() {
    paused = true;
    restartButton.SetActive(false);
    pauseButton.SetActive(false);
    blackScreen.SetActive(true);
    pauseCenter.SetActive(true);

    Color temp = blackScreenImage.color;
    blackScreenImage.color = new Color(temp.r, temp.g, temp.b, 0.5f);
  }

  public void RestartMenu() {
    Color temp = pauseButton.GetComponent<UnityEngine.UI.Image>().color;
    pauseButton.GetComponent<UnityEngine.UI.Image>().color = new Color(temp.r, temp.g, temp.b, 0);
    temp = restartButton.GetComponent<UnityEngine.UI.Image>().color;
    restartButton.GetComponent<UnityEngine.UI.Image>().color = new Color(temp.r, temp.g, temp.b, 0);
    temp = startButton.GetComponent<UnityEngine.UI.Image>().color;
    startButton.GetComponent<UnityEngine.UI.Image>().color = new Color(temp.r, temp.g, temp.b, 1);

    startButton.SetActive(true);
    helpButton.SetActive(true);
    pauseButton.SetActive(false);
    restartButton.SetActive(false);
    pauseCenter.SetActive(false);
    blackScreen.SetActive(false);

    pauseCenter.SetActive(false);

    ratio = 0;
    timer = 0;
  }

  public void OnRestartClick() {
    RestartMenu();
  }

  public void OnHelpClick() {

  }

}
