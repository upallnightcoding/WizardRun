using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCntrl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;

    private CharacterController controller;
    private Animator animator;

    private HeroState heroState = HeroState.IDLE;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void ManageState() 
    {
        switch(heroState) {
            case HeroState.IDLE:
            break;
        }
    }

    private void Move() {
        if (Input.GetKeyDown(KeyCode.D)) {
            animator.SetInteger("state", (int)HeroState.WALK);
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            animator.SetInteger("state", (int)HeroState.RUN);
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            animator.SetInteger("state", (int)HeroState.TURN);
        }
    }

    private void xMove() 
    {
        float xdirection = Input.GetAxis("Horizontal");
        Debug.Log($"Direction: {xdirection}");

        moveDirection = new Vector3(xdirection, 0.0f, 0.0f); 
        moveDirection *= walkSpeed;

        controller.Move(moveDirection * Time.deltaTime);
    }
}

public enum HeroState {
    IDLE = 1,
    WALK = 2,
    RUN = 3,
    JUMP = 4,
    TURN = 5
}
