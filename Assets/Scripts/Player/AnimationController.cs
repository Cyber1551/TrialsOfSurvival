using System.Collections;
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

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length >
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    public bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
    public void SetSpeed(float speed)
    {
      animator.speed = speed;
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
