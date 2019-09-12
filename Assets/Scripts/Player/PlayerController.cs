using UnityEngine;

public enum PlayerStates
{
   Idle,
   Moving
}
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(AnimationController))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    public AnimationController animationController;
    public GameObject testAttack;
    public bool isAttacking = false;
    public PlayerStates State = PlayerStates.Idle;
    private PlayerMovement playerMovement;
    float forwardAmount;
    float turnAmount;
    private RaycastHit hit;

    private EquipmentController equipmentController;
    public BaseEquipment equippedWeapon;
    public EquipmentAnimations animations;
    public int critChanceTest = 1;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = PlayerInput.Instance;
        playerMovement = GetComponent<PlayerMovement>();
        animationController = GetComponent<AnimationController>();
        equipmentController = GetComponent<EquipmentController>();

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButton(0))
        {
            if (isAttacking)
            {
              return;
            }
            else
            {
              //animationController.SetSpeed(equipmentController.equipmentSpawn.GetComponentInChildren<Equipment>().equipment.AttackSpeed + GetComponent<BaseStats>().GetStat(Stat.AttackSpeed));
              //Debug.Log(equipmentController.equipmentSpawn.GetComponentInChildren<Equipment>().equipment.AttackSpeed + GetComponent<BaseStats>().GetStat(Stat.AttackSpeed));
              if (equipmentController.equipmentSpawn.GetComponentInChildren<Equipment>().equipment.locksMotion)
              {
                  playerMovement.canMove = false;
              }
              else
              {
                playerMovement.canMove = true;
              }
              switch(GetComponent<BaseStats>().CurrentWeapon)
              {
                case WeaponType.Sword:
                  animationController.PlayAnimation(animations.GetAnimation(WeaponType.Sword).animations[0].name);
                break;
                case WeaponType.Bow:
                  animationController.PlayAnimation(animations.GetAnimation(WeaponType.Bow).animations[0].name);
                break;
              }

            }

        }
        else if (Input.GetMouseButtonUp(1))
        {
            if (equipmentController.equipmentSpawn.GetComponentInChildren<Equipment>().equipment.locksMotion)
            {
                playerMovement.canMove = false;
            }
            animationController.PlayAnimation("2Hand-Sword-Attack2");
        }
       else if (Input.GetKeyUp(KeyCode.I))
        {
            equipmentController.SetEquipmentType(WeaponType.Unarmed);
        }
        else if (Input.GetKeyUp(KeyCode.O))
         {
             equipmentController.SetEquipmentType(WeaponType.Sword);
         }
         else if (Input.GetKeyUp(KeyCode.P))
          {
              equipmentController.SetEquipmentType(WeaponType.Bow);
          }

          State = SetState();

    }

    public PlayerStates SetState()
    {
      if (Vector3.Distance(Vector3.zero, playerMovement.moveVelocity) > 0)
      {
        return PlayerStates.Moving;
      }
      else if (playerMovement.moveVelocity == Vector3.zero)
      {
        return PlayerStates.Idle;
      }

      return PlayerStates.Idle;
    }

}
