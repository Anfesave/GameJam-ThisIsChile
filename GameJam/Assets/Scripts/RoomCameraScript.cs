using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomCameraScript : MonoBehaviour
{
    CinemachineVirtualCamera roomCamera;

    // Start is called before the first frame update
    void Start() => roomCamera = GetComponent<CinemachineVirtualCamera>();    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            roomCamera.Priority++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            roomCamera.Priority--;
    }
}
