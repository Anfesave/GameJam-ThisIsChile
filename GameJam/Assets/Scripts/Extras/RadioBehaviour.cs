using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioBehaviour : MonoBehaviour
{
    public Transform player;

    public AudioSource music;
    public AudioSource button;

    public bool radioEnabled = false;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < 2 && Input.GetKeyDown(KeyCode.E))
        {
            if (!radioEnabled)
            {
                button.Play();
                music.Play();
            }


            else
            {
                button.Play();
                music.Stop();
            }
                

            radioEnabled = !radioEnabled;
        }
    }
}
