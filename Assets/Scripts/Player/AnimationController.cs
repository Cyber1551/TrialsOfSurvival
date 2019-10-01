using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    private PlayerController playerController;
    public GameObject TestMagicCircle;
    public Transform magicT;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerController = GetComponent<PlayerController>();
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
    public void SetBool(string name, bool val)
    {
        animator.SetBool(name, val);
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
    private void Shoot()
    {
        Instantiate(TestMagicCircle, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(-90, 0, 0));
    }

}
