using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePatient : MonoBehaviour
{
    private Animator animator;

    private void Start() => animator = GetComponent<Animator>();

    public void ChoosePatientTrigger()
    {
        animator.SetTrigger("Pick");
    }
}
