using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientListScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
                FindObjectOfType<GameManager>().LoadNextScene(transform);
        }
    }
}
