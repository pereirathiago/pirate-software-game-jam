using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Anim : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }

    void OnMove()
    {
        anim.SetFloat("Horizontal", -transform.position.y);
        anim.SetFloat("Vertical", transform.position.x);
        anim.SetFloat("Speed", transform.position.sqrMagnitude);
    }
}
