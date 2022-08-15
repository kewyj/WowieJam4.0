using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateParallax : MonoBehaviour
{
    public float backgroundSpeed;
    public float middlegroundSpeed;
    public float foregroundSpeed;

    private float originalBgdSpeed;
    private float originalMgdSpeed;
    private float originalFgdSpeed;

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

    void Start()
    {
        originalBgdSpeed = backgroundSpeed;
        originalMgdSpeed = middlegroundSpeed;
        originalFgdSpeed = foregroundSpeed;
        leftBack = Instantiate(background, new Vector3(0, 0, 0), Quaternion.identity);
        leftMid = Instantiate(middleground, new Vector3(0, 0, 0), Quaternion.identity);
        leftFore = Instantiate(foreground, new Vector3(0, 0, 0), Quaternion.identity);
        rightBack = Instantiate(background, new Vector3(1920, 0, 0), Quaternion.identity);
        rightMid = Instantiate(middleground, new Vector3(1920, 0, 0), Quaternion.identity);
        rightFore = Instantiate(foreground, new Vector3(1920, 0, 0), Quaternion.identity);

        leftBack.GetComponent<ParallaxMovement>().speed = rightBack.GetComponent<ParallaxMovement>().speed = backgroundSpeed;
        leftMid.GetComponent<ParallaxMovement>().speed = rightMid.GetComponent<ParallaxMovement>().speed = middlegroundSpeed;
        leftFore.GetComponent<ParallaxMovement>().speed = rightFore.GetComponent<ParallaxMovement>().speed = foregroundSpeed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpeedUp(float multiplier)
    {
        backgroundSpeed *= multiplier;
        middlegroundSpeed *= multiplier;
        foregroundSpeed *= multiplier;

        foreach (ParallaxMovement gOb in FindObjectsOfType<ParallaxMovement>())
        {
            gOb.speed *= multiplier;
        }
    }

    public void Restart()
    {
        foreach (ParallaxMovement gOb in FindObjectsOfType<ParallaxMovement>())
            Destroy(gOb.gameObject);
        backgroundSpeed = originalBgdSpeed;
        middlegroundSpeed = originalMgdSpeed;
        foregroundSpeed = originalFgdSpeed;
        Start();
    }
}
