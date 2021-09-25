using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Image face;
	public Text nameText;
	public Text dialogueText;

	
	public Animator animator;
	private AudioSource audioSource;

	public Queue<string> sentences;

    private void Awake() => audioSource = GetComponent<AudioSource>();

    // Use this for initialization
    void Start() => sentences = new Queue<string>();

    public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;
		face.sprite = dialogue.face;
		audioSource.clip = dialogue.voice;


		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		audioSource.Play();
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			yield return new WaitForSeconds(.05f);
			dialogueText.text += letter;
			yield return null;
		}
		audioSource.Stop();
	}

    void EndDialogue() => animator.SetBool("IsOpen", false);

}
