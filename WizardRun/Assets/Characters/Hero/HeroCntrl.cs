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

    private HeroState heroState = HeroState.IDLE;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
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

    private void Move() 
    {
        float xdirection = Input.GetAxis("Horizontal");
        Debug.Log($"Direction: {xdirection}");

        moveDirection = new Vector3(xdirection, 0.0f, 0.0f); 
        moveDirection *= walkSpeed;

        controller.Move(moveDirection * Time.deltaTime);
    }
}

public enum HeroState {
    IDLE = 0,
    WALK = 1,
    RUN = 2,
    JUMP = 3
}
