using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRobot : MonoBehaviour
{
    public float platformSpeed;
    //[SerializeField]
    //GameObject bridge;
    [SerializeField]
    GameObject jump;
    [SerializeField]
    GameObject cannon;

    //GameObject bridgeRobot;
    GameObject jumpRobot;
    GameObject cannonRobot;

    // Start is called before the first frame update
    void Start()
    {
        //bridgeRobot = Instantiate(bridge, new Vector3(300, -300, 1), Quaternion.identity);
        jumpRobot = Instantiate(jump, new Vector3(500, -450, 1), Quaternion.identity);
        cannonRobot = Instantiate(cannon, new Vector3(700, -450, 1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpRobot.GetComponent<Jumppad>().isPlaced)
        {
            jumpRobot.GetComponent<RobotMovement>().speed = platformSpeed;
            jumpRobot = Instantiate(jump, new Vector3(500, -450, 1), Quaternion.identity);
        }
        if (cannonRobot.GetComponent<Cannon>().isPlaced)
        {
            cannonRobot.GetComponent<RobotMovement>().speed = platformSpeed;
            cannonRobot = Instantiate(cannon, new Vector3(700, -450, 1), Quaternion.identity);
        }
    }
    
    public void SpeedUp(float multiplier)
    {
        platformSpeed *= multiplier;
        foreach (RobotMovement gOb in FindObjectsOfType<RobotMovement>())
            gOb.speed *= multiplier;
    }
}
