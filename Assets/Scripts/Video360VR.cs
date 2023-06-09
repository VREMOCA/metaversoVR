using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Video360VR : MonoBehaviour
{
    public GameObject player;
    public float maxDist;
    public string videoName;
    public GameObject map;
    public GameObject vd360;

    private bool playerInside;
    private VideoPlayer vd;
    private AudioSource audi;

    private void Awake()
    {
        playerInside = false;
        vd = GetComponent<VideoPlayer>();
        audi = GetComponent<AudioSource>();

        vd.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
    }

    private void Update()
    {
        CheckPlayerInside();
        CheckPlayerOutside();
    }

    private void CheckPlayerInside()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < maxDist)
        {
            playerInside = true;
            map.SetActive(false);
            vd360.SetActive(true);
            vd.Play();
        }
    }

    private void CheckPlayerOutside()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > maxDist)
        {
            playerInside = false;
            map.SetActive(true);
            vd360.SetActive(false);
            vd.Stop();
        }
    }

}
