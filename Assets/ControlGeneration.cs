using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGeneration : MonoBehaviour
{
    [SerializeField]
    GameObject platformGenerator;
    [SerializeField]
    GameObject parallaxGenerator;
    [SerializeField]
    GameObject robotGenerator;
    [SerializeField]
    GameObject mainCharacter;

    public float speedIncrease;
    public float timeInterval;

    private float timer;

    public bool started;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
            timer += Time.deltaTime;

        if (timer > timeInterval)
        {
            timer = 0;
            platformGenerator.GetComponent<GeneratePlatform>().SpeedUp(speedIncrease);
            parallaxGenerator.GetComponent<GenerateParallax>().SpeedUp(speedIncrease);
            robotGenerator.GetComponent<ControlRobot>().SpeedUp(speedIncrease);
        }
    }

    public void Restart()
    {
        platformGenerator.GetComponent<GeneratePlatform>().Restart();
        parallaxGenerator.GetComponent<GenerateParallax>().Restart();
        robotGenerator.GetComponent<ControlRobot>().Restart();
        mainCharacter.GetComponent<PlayerJump>().Restart();
        Start();
    }

    public void QuickRestart()
    {
        Restart();
        platformGenerator.GetComponent<GeneratePlatform>().QuickRestart();
        started = true;
    }
}
