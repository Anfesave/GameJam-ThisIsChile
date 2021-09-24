using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialog : MonoBehaviour
{
    //Usar siempre Colliders como trigger para marcar zonas donde los npc son interactuables

    private DialogueManager dialogueManager;

    //Npc interactuable en el momento, null de no existir uno
    public GameObject interactableNpc;

    public bool _isTalking;

    // Start is called before the first frame update
    void Start() => dialogueManager = FindObjectOfType<DialogueManager>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Dialog();
        }
    }

    public void Dialog()
    {
        if (_isTalking)
        {
            if (dialogueManager.sentences.Count != 0)
                dialogueManager.DisplayNextSentence();
            else
            {
                dialogueManager.DisplayNextSentence();
                GetComponent<PlayerMovement>().enabled = true;
                _isTalking = false;
            }
        }
        else if (interactableNpc != null)
        {
            GetComponent<PlayerMovement>().enabled = false;
            interactableNpc.GetComponent<DialogueTrigger>().TriggerDialogue();
            _isTalking = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Npc"))
            interactableNpc = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Npc"))
            interactableNpc = null;
    }
}
