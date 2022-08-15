using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWinLose : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject GeneratorController;

    private AudioSource Sound;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerJump>().death)
        {
            Sound.Play();
            GeneratorController.GetComponent<ControlGeneration>().Restart();
        }
    }
}
