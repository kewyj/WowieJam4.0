using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWinLose : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject GeneratorController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerJump>().death)
            GeneratorController.GetComponent<ControlGeneration>().Restart();
    }
}
