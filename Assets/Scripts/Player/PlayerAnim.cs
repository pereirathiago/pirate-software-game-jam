using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private PlayerMovement playerMove;
    private Animator anim;

    [SerializeField] private float speedRunningAnimation;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement

    void OnMove()
    {
        anim.SetFloat("Horizontal", playerMove.Direction.y);
        anim.SetFloat("Vertical", playerMove.Direction.x);
        anim.SetFloat("Speed", playerMove.Direction.sqrMagnitude);
    }

    void OnRun()
    {
        if(playerMove.IsRunning)
        {
            anim.speed = speedRunningAnimation;
            return;
        }

        anim.speed = 1f;
    }

    #endregion
}
