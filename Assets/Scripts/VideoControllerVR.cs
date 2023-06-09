using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControllerVR : MonoBehaviour
{
    public GameObject player;
    public float maxDist;

    private bool playerInside;
    public VideoPlayer vd;
    private AudioSource audi;

    private void Awake()
    {
        playerInside = false;
        audi = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(!playerInside)
        {
            CheckPlayerInside();
        }
        
        if(playerInside)
        {
            CheckPlayerOutside();
        }
    }

    private void CheckPlayerInside()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < maxDist)
        {
            playerInside = true;
            vd.Play();
            //player.GetComponent<AudioSource>().mute = true;
            Debug.Log("he entrado");
        }
    }

    private void CheckPlayerOutside()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > maxDist)
        {
            playerInside = false;
            vd.Stop();
            //player.GetComponent<AudioSource>().mute = false;
            Debug.Log("he salido");
        }
    }
}
