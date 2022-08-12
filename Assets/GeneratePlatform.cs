using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
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

    GameObject floor;

    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        floor = Instantiate(floor5, new Vector3(0, -540, 0), Quaternion.identity);
        distance = -floor.transform.localScale.x / 2.0f + 960;
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * floor.GetComponent<PlatformMovement>().speed;
        if (distance > 300)
        {
            Debug.Log(distance);
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
            floor = Instantiate(tempFloor, new Vector3(960 + tempFloor.transform.localScale.x / 2.0f, -540, 0), Quaternion.identity);
            distance = -floor.transform.localScale.x;
        }
    }
}
