using System.Collections.Generic;
using UnityEngine;
using System;
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
    [HideInInspector] public AnimationController animationController;
    public GameObject testAttack;
    public bool isAttacking = false;
    public PlayerStates State = PlayerStates.Idle;
    private PlayerMovement playerMovement;
    float forwardAmount;
    float turnAmount;
    private RaycastHit hit;
    [HideInInspector] public PlayerHealth playerHealth;

    public List<Stat> stats;
    public List<Material> materials;

    public Animator TestBowAnimator;

    float attackSpeedTimer = float.MaxValue;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = PlayerInput.Instance;
        playerMovement = GetComponent<PlayerMovement>();
        animationController = GetComponent<AnimationController>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        stats = new List<Stat>()
        {   
            new Stat("PhysicalDamage", 5),
            new Stat("MagicalDamage", 100), 
            new Stat("CritChance", 10),
            new Stat("CritDamage", 100),
            new Stat("AttackSpeed", 0.5f),
            new Stat("CastingSpeed", 2f),
            new Stat("CooldownReduction", 0), 
            new Stat("LifeSteal", 1)
        };

        materials = new List<Material>()
        {
            new Material("Wood", 10),
            new Material("Stone"),
            new Material("Iron")

        };


    }
    public Stat GetStat(string name)
    {
        Stat ret = stats.Find(stat => stat.Name.Equals(name));
        if (ret == null)
            Debug.LogException(new NullReferenceException("Stat couldn't be found"));

        return ret;


    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        if (Input.GetMouseButton(0))
        {
             if (attackSpeedTimer > GetStat("AttackSpeed").Value)
            {
                animationController.animator.Play("Shooting-Fire-Rifle1");
                attackSpeedTimer = 0;
            }
           
 
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            playerHealth.TakeDamage(Mathf.RoundToInt(playerHealth.MaxHealth * 0.05f), false);
        }
        attackSpeedTimer += Time.deltaTime;

    }

    [System.Serializable]
    public class Stat
    {
        public string Name;
        public float Value;

        public Stat(string name, float value)
        {
            Name = name;
            Value = value;
        }
        public Stat(string name) : this(name, 0)
        {
            Name = name;
        }
    }
    [System.Serializable]
    public class Material
    {
        public string Name;
        public int Amount;
        public MaterialType Type;

        public Material(string name, int value)
        {
            Name = name;
            Amount = value;
            Type = MaterialType.Raw;
        }
        public Material(string name) : this(name, 0)
        {
            Name = name;
        }
        public void AddMaterial(int amt)
        {
            Amount += amt;
        }
        public bool RemoveMaterial(int amt)
        {
           if((Amount -= amt) >= 0)
           {
                return true;
           }
           else
            {
                Amount = 0;
                return false;
            }
        }
         public void ChangeMaterialType(MaterialType type)
        {
            Type = type;
        }
    }
    

}
public enum MaterialType
{
    Raw,
    Refined,
    Processed
}
