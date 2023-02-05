using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private Transform tracker;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;

    private Animator animator;
    private CharacterController controller;
    private PlayerState playerState;

    private float idleTime = 0.0f;
    private float setIdleTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerState = PlayerState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        switch(playerState) {
            case PlayerState.IDLE:
                playerState = PlayerIdle();
                break;
            case PlayerState.IDLING:
                playerState = PlayerIdling();
                break;
            case PlayerState.RUN:
                playerState = PlayerRun();
                break;
            case PlayerState.RUNNING:
                playerState = PlayerRunning(Time.deltaTime);
                break;
        }
    }

    public PlayerState PlayerRun()
    {
        animator.SetInteger("state", (int)PlayerState.RUN);

        return(PlayerState.RUNNING);
    }

    public PlayerState PlayerRunning(float dt)
    {
        MoveToTargetPoint(tracker.transform.position, dt);

        return(PlayerState.RUNNING);
    }

    public PlayerState PlayerIdle()
    {
        animator.SetInteger("state", (int)PlayerState.IDLE);

        return(PlayerState.IDLING);
    }

    public PlayerState PlayerIdling()
    {
        idleTime += Time.deltaTime;

        return((idleTime > setIdleTime) ? PlayerState.RUN : PlayerState.IDLING); 
    }

    private void MoveToTargetPoint(Vector3 target, float dt)
    {
        float distance = Vector3.Distance(target, transform.position);
        Vector3 direction = (target - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * dt);

        controller.Move(transform.forward * moveSpeed * dt);
    }
}

public enum PlayerState 
{
    IDLE = 0,
    IDLING = 1,
    RUN = 2,
    RUNNING = 3
}
