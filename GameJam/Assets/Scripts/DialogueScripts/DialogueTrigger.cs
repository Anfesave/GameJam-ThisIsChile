using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public bool _isAutomatic;
	public Dialogue dialogue;

    public void TriggerDialogue() => FindObjectOfType<DialogueManager>().StartDialogue(dialogue);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_isAutomatic)
            {
                PlayerDialog playerDialog = FindObjectOfType<PlayerDialog>();
                playerDialog.interactableNpc = gameObject;
                playerDialog.Dialog();
                _isAutomatic = false;
            }
        }
    }

}
