using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStates { OnGround, InAir, DoubleAir }

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private Transform groundDetectPoint;
    [SerializeField]
    private float groundDetectRadius = 0.2f;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private LayerMask secondGroundLayer;

    private PlayerStates currentState;

    public delegate void PlayerStateDelegate(PlayerStates previousState, PlayerStates newState);
    public event PlayerStateDelegate PlayerChangedStates;

    // Use this for initialization
    void Start ()
    {
        currentState = PlayerStates.OnGround;
	}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (currentState == PlayerStates.InAir)
    //    {
    //        currentState = PlayerStates.OnGround;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        UpdateGroundState();
    }

    private void UpdateGroundState()
    {
        Vector2 colliderPoint = new Vector2(groundDetectPoint.position.x, groundDetectPoint.position.y);
        Collider2D[] objects = Physics2D.OverlapCircleAll(colliderPoint, groundDetectRadius, groundLayer);
        Collider2D[] objects2 = Physics2D.OverlapCircleAll(colliderPoint, groundDetectRadius, secondGroundLayer);
        if (objects.Length > 0 && (currentState == PlayerStates.InAir || currentState == PlayerStates.DoubleAir))
        {
            SetState(PlayerStates.OnGround);
        }
        if(objects2.Length > 0 && (currentState == PlayerStates.InAir || currentState == PlayerStates.DoubleAir))
        {
            SetState(PlayerStates.OnGround);
        }
    }

    public PlayerStates GetState()
    {
        return currentState;
    }

    public void SetState(PlayerStates state)
    {
        if(state != currentState)
        {
            PlayerStates previous = currentState;
            currentState = state;
            if (PlayerChangedStates != null)
            {
                PlayerChangedStates.Invoke(previous, currentState);
            }
        }
    }
}
