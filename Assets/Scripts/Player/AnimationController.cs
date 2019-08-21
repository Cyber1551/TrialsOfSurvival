﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private EquipmentController equipmentController;
    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        equipmentController = GetComponent<EquipmentController>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateAnimator(float forwardAmount, float turnAmount)
    {
       animator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
       animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime); 
    }
    public void PlayAnimation(string anim)
    {
        animator.Play(anim);
    }
    private void FootR() { }
    private void FootL() { }

    private void MeleeStart()
    {
        equipmentController.equipmentSpawn.GetComponentInChildren<BoxCollider>().enabled = true;
    }
    private void Hit() 
    {
        equipmentController.equipmentSpawn.GetComponentInChildren<BoxCollider>().enabled = false;
        playerMovement.canMove = true;
    }
     private void MeleeEnd()
    {
       
    }
    IEnumerator HitCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
       
    }
}
