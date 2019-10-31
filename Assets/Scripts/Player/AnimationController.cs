using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    public Animator animator;
    private PlayerMovement playerMovement;
    private PlayerController playerController;
    public GameObject Bullet;
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

    public void UpdateAnimator(float forwardAmount, float turnAmount)
    {
       animator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
       animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
    }

    private void FootR() { }
    private void FootL() { }
    private void AnimationStart()
    {
    }
    private void Shoot()
    {
        Debug.Log("SHOOT");
        Transform spawn = GameObject.Find("ProjectileSpawn").transform;
        GameObject g= Instantiate(Bullet, spawn.position, Quaternion.identity);

        var mousePos = Input.mousePosition;
        mousePos.z = 13; // select distance = 10 units from the camera
        Vector3 mPos = Camera.main.ScreenToWorldPoint(mousePos);
        spawn.LookAt(mPos);
       
        g.GetComponent<Rigidbody>().AddForce(transform.forward * 750);

        
    }
    private void AnimationEnd ()
    {

    }

}
