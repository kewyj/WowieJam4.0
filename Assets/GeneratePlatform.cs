using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
    public float platformSpeed;
    private float originalSpeed;
    public float pitfallLength;

    private float distance;

    [SerializeField]
    GameObject floor1;
    [SerializeField]
    GameObject floor2;
    [SerializeField]
    GameObject floor3;
    [SerializeField]
    GameObject floor4;
    [SerializeField]
    GameObject floor5;
    [SerializeField]
    GameObject jump;
    [SerializeField]
    GameObject canon;

    public bool started;
    private bool runOnlyOnce;
    GameObject floor;
    GameObject spikeStrip;
    GameObject roof;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        runOnlyOnce = false;
        originalSpeed = platformSpeed;
        platformSpeed = 0;
        floor = Instantiate(floor5, new Vector3(0, -600, 0), Quaternion.identity);
        distance = -floor.transform.localScale.x * 45.714f + 960;
        floor.GetComponent<PlatformMovement>().speed = platformSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (started && !runOnlyOnce)
        {
            platformSpeed = originalSpeed;
            runOnlyOnce = !runOnlyOnce; 
        }
        distance += Time.deltaTime * floor.GetComponent<PlatformMovement>().speed;
        if (distance > pitfallLength)
        {
            int temp = Random.Range(1, 6);
            GameObject tempFloor = floor1;
            switch (temp)
            {
                case 1:
                    tempFloor = floor1;
                    break;
                case 2:
                    tempFloor = floor2;
                    break;
                case 3:
                    tempFloor = floor3;
                    break;
                case 4:
                    tempFloor = floor4;
                    break;
                case 5:
                    tempFloor = floor5;
                    break;
            }
            floor = Instantiate(tempFloor, new Vector3(960 + tempFloor.transform.localScale.x * 45.714f, -600, 0), Quaternion.identity);
            floor.GetComponent<PlatformMovement>().speed = platformSpeed;
            distance = -floor.transform.localScale.x * 91.4285f;

            if (Random.Range(0,2) == 1 && temp == 5)
            {
                spikeStrip = Instantiate(canon, new Vector3(Random.Range(460 + tempFloor.transform.localScale.x * 45.714f, 
                    1360 + tempFloor.transform.localScale.x * 45.714f), -252, 0), Quaternion.identity);
                spikeStrip.GetComponent<PlatformMovement>().speed = platformSpeed;
            }
            else
            {
                if (temp == 4 || temp == 5)
                {
                    roof = Instantiate(jump, new Vector3(960 + tempFloor.transform.localScale.x * 45.714f +
                        Random.Range(-tempFloor.transform.localScale.x * 45.714f + 240 + pitfallLength, 0 - 480), -235, 0),
                        Quaternion.identity);
                    roof.GetComponent<PlatformMovement>().speed = platformSpeed;

                    roof = Instantiate(jump, new Vector3(960 + tempFloor.transform.localScale.x * 45.714f + 
                        Random.Range(0 + 480, tempFloor.transform.localScale.x * 45.714f - 240 - pitfallLength), -235, 0), 
                        Quaternion.identity);
                    roof.GetComponent<PlatformMovement>().speed = platformSpeed;
                }
                else
                {
                    roof = Instantiate(jump, new Vector3(960 + tempFloor.transform.localScale.x * 45.714f + 
                        Random.Range(-tempFloor.transform.localScale.x * 45.714f + 240 + pitfallLength, tempFloor.transform.localScale.x * 45.714f - 240 - pitfallLength), -235, 0), 
                        Quaternion.identity);
                    roof.GetComponent<PlatformMovement>().speed = platformSpeed;
                }
            }
        }
    }

    public void SpeedUp(float multiplier)
    {
        platformSpeed *= multiplier;
        foreach (PlatformMovement gOb in FindObjectsOfType<PlatformMovement>())
            gOb.speed = platformSpeed;
    }

    public void Restart()
    {
        foreach (PlatformMovement gOb in FindObjectsOfType<PlatformMovement>())
            Destroy(gOb.gameObject);
        platformSpeed = originalSpeed;
        Start();
    }

    public void QuickRestart()
    {
        Restart();
        started = true;
    }
}
