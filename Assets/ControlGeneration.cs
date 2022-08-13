using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGeneration : MonoBehaviour
{
    [SerializeField]
    GameObject platformGenerator;
    [SerializeField]
    GameObject parallaxGenerator;

    public float speedIncrease;
    public float timeInterval;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeInterval)
        {
            timer = 0;
            platformGenerator.GetComponent<GeneratePlatform>().SpeedUp(speedIncrease);
            parallaxGenerator.GetComponent<GenerateParallax>().SpeedUp(speedIncrease);
        }
    }
}
