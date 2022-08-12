using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateParallax : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject background;
    [SerializeField]
    GameObject middleground; 
    [SerializeField]
    GameObject foreground;

    private GameObject leftBack;
    private GameObject leftMid;
    private GameObject leftFore;
    private GameObject rightBack;
    private GameObject rightMid;
    private GameObject rightFore;

    private float prevPos;

    void Start()
    {
        leftBack = Instantiate(background, new Vector3(0, 0, 0), Quaternion.identity);
        leftMid = Instantiate(middleground, new Vector3(0, 0, 0), Quaternion.identity);
        leftFore = Instantiate(foreground, new Vector3(0, 0, 0), Quaternion.identity);
        rightBack = Instantiate(background, new Vector3(1920, 0, 0), Quaternion.identity);
        rightMid = Instantiate(middleground, new Vector3(1920, 0, 0), Quaternion.identity);
        rightFore = Instantiate(foreground, new Vector3(1920, 0, 0), Quaternion.identity);

        leftBack.GetComponent<ParallaxMovement>().speed = rightBack.GetComponent<ParallaxMovement>().speed = 500;
        leftMid.GetComponent<ParallaxMovement>().speed = rightMid.GetComponent<ParallaxMovement>().speed = 800;
        leftFore.GetComponent<ParallaxMovement>().speed = rightFore.GetComponent<ParallaxMovement>().speed = 1100;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
