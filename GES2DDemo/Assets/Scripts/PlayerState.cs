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

    private PlayerStates currentState;
    // Use this for initialization
    void Start ()
    {
        currentState = PlayerStates.InAir;
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
        if (objects.Length > 0 && (currentState == PlayerStates.InAir || currentState == PlayerStates.DoubleAir))
        {
            currentState = PlayerStates.OnGround;
        }
    }

    public PlayerStates GetState()
    {
        return currentState;
    }

    public void SetState(PlayerStates state)
    {
        currentState = state;
    }
}
