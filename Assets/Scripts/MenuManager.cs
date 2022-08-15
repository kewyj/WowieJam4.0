using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour {

  public GameObject startButton;
  public GameObject pauseButton;
  public GameObject helpButton;
  public GameObject nextHelpButton;
  public GameObject prevHelpButton;
  public GameObject exitHelpButton;
  public GameObject bigRestartButton;
  public GameObject bigMenuButton;
  public GameObject blackScreen;
  public GameObject[] helpScreens;
  public GameObject timeScore;
  public GameObject distanceScore;
  public GameObject generatorController;

  public UnityEngine.UI.Image startButtonImage;
  public UnityEngine.UI.Image pauseButtonImage;
  public SpriteRenderer blackScreenImage;
  public TMP_Text timeScoreText;
  public TMP_Text distanceScoreText;

  public Rigidbody2D Rigid;


  private float timer;
  private float maxTime;
  public bool paused;
  private float restartTimer;
  private float maxRestartTimer;
  private bool restartFlip;
  private int helpIndex;
  private float timeScoreValue;
  private float distanceScoreValue;

  // Start is called before the first frame update
  void Start() {
    startButton = GameObject.Find("StartButton");
    pauseButton = GameObject.Find("PauseButton");
    helpButton = GameObject.Find("HelpButton");
    blackScreen = GameObject.Find("BlackScreen");
    nextHelpButton = GameObject.Find("NextHelpButton");
    prevHelpButton = GameObject.Find("PrevHelpButton");
    exitHelpButton = GameObject.Find("ExitHelpButton");
    bigRestartButton = GameObject.Find("BigRestartButton");
    bigMenuButton = GameObject.Find("BigMenuButton");
    timeScore = GameObject.Find("TimeScore");
    distanceScore = GameObject.Find("DistanceScore");
    generatorController = GameObject.Find("Generator Controller");

    startButtonImage = startButton.GetComponent<UnityEngine.UI.Image>();
    pauseButtonImage = pauseButton.GetComponent<UnityEngine.UI.Image>();
    blackScreenImage = blackScreen.GetComponent<SpriteRenderer>();

    timeScoreText = timeScore.GetComponent<TMP_Text>();
    distanceScoreText = distanceScore.GetComponent<TMP_Text>();

    Rigid = GameObject.Find("BlindRobot").GetComponent<Rigidbody2D>();
    
    blackScreen.SetActive(false);

    RestartMenu();
    restartTimer = 0;
    maxRestartTimer = 1;
    maxTime = 0.5f;
  }
  // Update is called once per frame
  void Update() {

    if (timeScore.activeSelf && distanceScore.activeSelf && !paused) UpdateScore();

    // If start was pressed
    if (timer > 0) {
      timer -= Time.deltaTime;
      if (timer < 0) {
        timer = 0;
        startButton.SetActive(false);
      }
      float ratio = timer / maxTime;

      Color temp = startButton.GetComponent<UnityEngine.UI.Image>().color;
      startButton.GetComponent<UnityEngine.UI.Image>().color = new Color(temp.r, temp.g, temp.b, ratio);

      temp = pauseButton.GetComponent<UnityEngine.UI.Image>().color;
      pauseButton.GetComponent<UnityEngine.UI.Image>().color = new Color(temp.r, temp.g, temp.b, 1-ratio);
    }

    if (paused) {
      // Mouse is clicked and outside button regions
      if (restartTimer <= 0)
      if (Input.GetMouseButtonDown(0)) {
        // Rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
        Rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        Vector3 mPos = Input.mousePosition;
        mPos = GameMaster.helper.ScreenToWorld(mPos);
        if (GameMaster.helper.Abs(mPos.x) > 250 || GameMaster.helper.Abs(mPos.y) > 150) {
          paused = false;
          pauseButton.SetActive(true);
          blackScreen.SetActive(false);
          bigRestartButton.SetActive(false);
          bigMenuButton.SetActive(false);
        }
      }


    }

    if (restartTimer > 0) {
      restartTimer -= Time.deltaTime;
      if (restartTimer < 0) restartTimer = 0;
      float ratio = restartTimer / maxRestartTimer;
      if (restartFlip) {
        // Lighting back up
        blackScreenImage.color = new Color(0, 0, 0, ratio);

      } else {
        // Dimming down
        blackScreenImage.color = new Color(0, 0, 0, 1-ratio);

        if (restartTimer == 0) {
          restartTimer = maxRestartTimer;
          restartFlip = true;
          RestartMenu();
        }
      }

    }

  }

  public void OnStartClick() {
    if (timer > 0) return;
    timer = maxTime;
    pauseButton.SetActive(true);
    helpButton.SetActive(false);
    timeScore.SetActive(true);
    distanceScore.SetActive(true);

    generatorController.GetComponent<ControlGeneration>().Play();
  }

  public void OnPauseClick() {
    paused = true;
    pauseButton.SetActive(false);
    blackScreen.SetActive(true);
    bigRestartButton.SetActive(true);
    bigMenuButton.SetActive(true);

    Color temp = blackScreenImage.color;
    blackScreenImage.color = new Color(temp.r, temp.g, temp.b, 0.5f);
    Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
    // GameObject.Find("BlindRobot").GetComponent<Rigidbody2D>().constraints |= RigidbodyConstraints.FreezePositionY;
  }

  public void RestartMenu() {
    Color temp = pauseButton.GetComponent<UnityEngine.UI.Image>().color;
    pauseButton.GetComponent<UnityEngine.UI.Image>().color = new Color(temp.r, temp.g, temp.b, 0);
    temp = startButton.GetComponent<UnityEngine.UI.Image>().color;
    startButton.GetComponent<UnityEngine.UI.Image>().color = new Color(temp.r, temp.g, temp.b, 1);

    startButton.SetActive(true);
    helpButton.SetActive(true);
    pauseButton.SetActive(false);
    bigRestartButton.SetActive(false);
    bigMenuButton.SetActive(false);

    nextHelpButton.SetActive(false);
    prevHelpButton.SetActive(false);
    exitHelpButton.SetActive(false);

    distanceScore.SetActive(false);
    timeScore.SetActive(false);

    timer = 0;
    helpIndex = 0;
    paused = false;
    ResetScore();

    GameObject.Find("BlindRobot").GetComponent<PlayerDiedScript>().died = false;
    generatorController.GetComponent<ControlGeneration>().Restart();
  }

  public void OnRestartClick() {
    if (restartTimer > 0) return;
    restartTimer = maxRestartTimer;
    restartFlip = false;
    blackScreen.SetActive(true);
  }

  public void OnHelpClick() {
    if (restartTimer > 0) return;
    helpIndex = 1;
    startButton.SetActive(false);
    helpButton.SetActive(false);
    nextHelpButton.SetActive(true);
    exitHelpButton.SetActive(true);
    blackScreen.SetActive(true);
    blackScreenImage.color = new Color(0, 0, 0, 0.5f);
    ChangeHelpScene(helpIndex);
  }

  public void OnNextHelpClick() {
    if (++helpIndex == helpScreens.Length) nextHelpButton.SetActive(false);
    prevHelpButton.SetActive(true);

    ChangeHelpScene(helpIndex);
  }

  public void OnPrevHelpClick() {
    if (--helpIndex == 1) prevHelpButton.SetActive(false);
    nextHelpButton.SetActive(true);

    ChangeHelpScene(helpIndex);
  }

  public void OnExitHelpClick() {
    helpScreens[helpIndex-1].SetActive(false);
    nextHelpButton.SetActive(false);
    prevHelpButton.SetActive(false);
    exitHelpButton.SetActive(false);
    blackScreen.SetActive(false);

    startButton.SetActive(true);
    helpButton.SetActive(true);
  }

  public void ChangeHelpScene(int index) {
    for (int i = 0; i < helpScreens.Length; ++i) {
      if (i + 1 == index) helpScreens[i].SetActive(true);
      else helpScreens[i].SetActive(false);
    }
  }

  public void QuickRestartClick() {
    if (restartTimer > 0) return;
    blackScreen.SetActive(false);
    bigRestartButton.SetActive(false);
    bigMenuButton.SetActive(false);
    pauseButton.SetActive(true);
    paused = false;
    ResetScore();
    generatorController.GetComponent<ControlGeneration>().Restart();
  }

  public void ResetScore() {
    distanceScoreValue = 0;
    timeScoreValue = 0;
  }

  public void UpdateScore() {
    float speed = 10.0f;
    timeScoreValue += Time.deltaTime;
    distanceScoreValue += Time.deltaTime * speed;
    timeScoreText.text = "Time: " + timeScoreValue.ToString();
    distanceScoreText.text = "Distance: " + distanceScoreValue.ToString();
  }
}
