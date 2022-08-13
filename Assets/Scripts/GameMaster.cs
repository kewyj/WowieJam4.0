using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {
  public static Helper helper;
  public static SceneChanger sceneChanger;

  // Start is called before the first frame update
  void Start() {
    sceneChanger = new SceneChanger();
    helper = new Helper();
  }

  // Update is called once per frame
  void Update() {
  }
}

public class SceneChanger {
  public void SwitchScene(string str) {
    SceneManager.LoadScene(str);
  }

}

public class Helper {
  private Camera cam;
  public Vector3 ScreenToWorld(Vector3 pos) {
    cam = GameObject.Find("Main Camera").GetComponent<Camera>();

    return new Vector3((pos.x - Screen.width / 2) / Screen.height * 2 * cam.orthographicSize,
                       (pos.y - Screen.height / 2) / Screen.height * 2 * cam.orthographicSize, 0);
  }

  public Vector3 WorldToScreen(Vector3 pos) {
    cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    return new Vector3((pos.x / cam.orthographicSize / 2 * Screen.height) + Screen.width / 2,
                       (pos.y / cam.orthographicSize / 2 * Screen.height) + Screen.height / 2, 0);
  }

  public float Abs(float num) {
    return num < 0 ? -num : num;
  }
}