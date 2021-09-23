using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialog : MonoBehaviour
{
    //Usar siempre Colliders como trigger para marcar zonas donde los npc son interactuables

    private DialogueManager dialogueManager;

    //Npc interactuable en el momento, null de no existir uno
    private GameObject interactableNpc;

    private bool _isTalking;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (interactableNpc != null && !_isTalking)
            {
                StartCoroutine(Dialog());
            }
        }
    }

    private IEnumerator Dialog()
    {
        _isTalking = true;
        GetComponent<PlayerMovement>().enabled = false;
        interactableNpc.GetComponent<DialogueTrigger>().TriggerDialogue();
                
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil(() => Input.GetKey(KeyCode.E));
            
            dialogueManager.DisplayNextSentence();

            if (dialogueManager.sentences.Count == 0)
            {
                _isTalking = false;
                interactableNpc = null;
                yield return new WaitForSeconds(0.5f);
                yield return new WaitUntil(() => Input.GetKey(KeyCode.E));
                dialogueManager.DisplayNextSentence();
                GetComponent<PlayerMovement>().enabled = true;
                yield break;
            }
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
