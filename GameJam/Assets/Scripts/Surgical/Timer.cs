using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //VARIABLES
    [Header("Timer")]
    [SerializeField] private Image uiFill;
    [SerializeField] private Text uiText;
    public int duration;
    private int remainingDuration;

    public GameObject nurseNpc;
    public PlayerDialog player;
    public ChoosePatient patient1;
    public ChoosePatient patient2;

    void Start(){
        Begin(duration);
    }

    private void Begin(int second){
        remainingDuration = second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer(){
        while(remainingDuration >= 0){
            uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
            uiFill.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        uiText.text = "FIN!";
        OnEnd();
    }

    private void OnEnd(){
        player.interactableNpc = nurseNpc;
        player.Dialog();

        if (Random.value > 0.5f)
            patient1.ChoosePatientTrigger();
        else
            patient1.ChoosePatientTrigger();
        print("End");
    }

}
