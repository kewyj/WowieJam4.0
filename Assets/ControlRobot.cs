using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRobot : MonoBehaviour
{
    public float yPos = -450;
    public float xPos = 400;
    public float platformSpeed;
    private float originalSpeed;
    private GameObject[] randomRobotsPos = new GameObject[3];
    [SerializeField]
    GameObject[] randomRobotsType;

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = platformSpeed;

        randomRobotsPos[0] = Instantiate(randomRobotsType[0], new Vector3(-xPos, yPos - 18, 1), Quaternion.identity);
        randomRobotsPos[1] = Instantiate(randomRobotsType[1], new Vector3(0, yPos, 1), Quaternion.identity);
        randomRobotsPos[2] = Instantiate(randomRobotsType[2], new Vector3(xPos, yPos, 1), Quaternion.identity);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("MenuManager").GetComponent<MenuManager>().paused) return;

<<<<<<< Updated upstream
        var _i = 0;
        var _xPos = -xPos;
        foreach (var obj in randomRobotsType)
=======
        float _xPos = -xPos;
        for (var _i = 0; _i < 3; ++_i)
>>>>>>> Stashed changes
        {
            if (randomRobotsPos[_i].GetComponent<Drag>().isPlaced)
            {
                randomRobotsPos[_i].GetComponent<RobotMovement>().speed = platformSpeed;
                int botType = Random.Range(0, 3);
                if (botType == 0) {
                    randomRobotsPos[_i] = Instantiate(randomRobotsType[botType], new Vector3(_xPos, yPos - 18, 1), Quaternion.identity);
                }else{
                    randomRobotsPos[_i] = Instantiate(randomRobotsType[botType], new Vector3(_xPos, yPos, 1), Quaternion.identity);
                }
            }
            ++_i;
            _xPos += xPos;
        }
    }
    
    public void SpeedUp(float multiplier)
    {
        platformSpeed *= multiplier;
        foreach (RobotMovement gOb in FindObjectsOfType<RobotMovement>())
            gOb.speed *= multiplier;
    }

    public void Restart()
    {
        foreach (RobotMovement gOb in FindObjectsOfType<RobotMovement>())
            Destroy(gOb.gameObject);
        platformSpeed = originalSpeed;
        Start();
    }
}
