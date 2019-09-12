using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private EquipmentController equipmentController;
    private PlayerMovement playerMovement;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        equipmentController = GetComponent<EquipmentController>();
        playerMovement = GetComponent<PlayerMovement>();
        playerController = GetComponent<PlayerController>();
    }

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length >
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    public void SetWeaponType(int et)
    {
        animator.SetInteger("EquippedWeapon", et);
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

private void AnimationStart()
{
  playerController.isAttacking = true;
}

#region Melee
    private void MeleeStart()
    {
      AnimationStart();
        equipmentController.equipmentSpawn.GetComponentInChildren<BoxCollider>().enabled = true;
    }
    private void Hit()
    {
        equipmentController.equipmentSpawn.GetComponentInChildren<BoxCollider>().enabled = false;
        playerMovement.canMove = true;
    }
#endregion

#region Ranged
    private void Shoot()
    {
      GameObject projectile = playerController.animations.GetAnimation(WeaponType.Bow).helperObjects[0];
      GameObject proj = Instantiate(projectile, equipmentController.equipmentSpawn.position, Quaternion.LookRotation(transform.up, transform.forward));
      proj.transform.localScale = new Vector3(2, 2, 2);
      float testCharge = 1;
      Vector3 destination = transform.position + (15 * testCharge) * proj.transform.up;
      Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      //proj.GetComponent<Rigidbody>().velocity = proj.transform.up * 10;
      proj.GetComponent<Projectile>().Destination = destination;
       
    }
#endregion
     private void AnimationEnd()
    {
      playerController.isAttacking = false;
    }
    IEnumerator HitCoroutine()
    {
        yield return new WaitForSeconds(0.1f);

    }
}
