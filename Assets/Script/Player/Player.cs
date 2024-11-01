using UnityEngine;

public class Player : MonoBehaviour{
    public static Player Instance;
    private PlayerMovement playerMovement;
    private Animator animator;

    private void Awake(){
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Start(){
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate(){
        playerMovement.Move();
    }

    private void LateUpdate(){
        if(animator != null){
            animator.SetBool("IsMoving", playerMovement.IsMoving());
        }
    }
}