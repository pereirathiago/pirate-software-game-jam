using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private float _bulletForce = 20f;

    private PlayerItems _playerItems;

    private void Start()
    {
        _playerItems = GetComponent<PlayerItems>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
    }
    private void HandleShooting()
    {
        if (!_playerItems.WeaponEquipped)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
        }
    }
}
