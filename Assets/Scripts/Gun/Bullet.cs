using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private float _destroyTime = 10f;

    private void Start()
    {
        Destroy(gameObject, _destroyTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);

        //Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
