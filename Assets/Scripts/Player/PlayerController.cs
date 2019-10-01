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
    public int critChanceTest = 1;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = PlayerInput.Instance;
        playerMovement = GetComponent<PlayerMovement>();
        animationController = GetComponent<AnimationController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animationController.SetBool("Casting", true);
        }
        else
        {
            animationController.SetBool("Casting", false);
        }

    }

}
