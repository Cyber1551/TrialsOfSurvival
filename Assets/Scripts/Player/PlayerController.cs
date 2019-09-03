using UnityEngine;

public enum PlayerStates
{
   Idle, 
   Moving,
   Attacking
}
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(AnimationController))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    public AnimationController animationController;
    public GameObject testAttack; 

    public PlayerStates State = PlayerStates.Idle;
    private PlayerMovement playerMovement;
    float forwardAmount;
    float turnAmount;
    private RaycastHit hit;

    private EquipmentController equipmentController;
    public BaseEquipment equippedWeapon;

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
       if (Input.GetMouseButtonUp(0))
        {
            if (equipmentController.equipmentSpawn.GetComponentInChildren<Equipment>().equipment.locksMotion)
            {
                playerMovement.canMove = false;
            }
            animationController.PlayAnimation("2Hand-Sword-Attack1"); 
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
            GetComponent<PlayerHealth>().TakeDamage(10, true);
        }
      
    }
    private void Attack ()
    {
        State = PlayerStates.Attacking;
    
    }


}
