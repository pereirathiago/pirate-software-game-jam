using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int _numberBullets;

    [SerializeField] private bool _weaponEquipped = false;
    [SerializeField] private bool _flashlightEquipped = false;

    [SerializeField] private GameObject _weapon;
    [SerializeField] private GameObject _flashlight;

    public bool WeaponEquipped { get => _weaponEquipped; }
    public bool FlashlightEquipped { get => _flashlightEquipped; }

    private void Update()
    {
        EquipItem();
    }

    private void EquipItem()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _weaponEquipped = !WeaponEquipped;

            if (_weaponEquipped)
            {
                _flashlightEquipped = false;
                _weapon.SetActive(true);
                _flashlight.SetActive(false);
            }
            else
            {
                _weapon.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _flashlightEquipped = !FlashlightEquipped;
            if (_flashlightEquipped)
            {
                _weaponEquipped = false;
                _weapon.SetActive(false);
                _flashlight.SetActive(true);
            }
            else
            {
                _flashlight.SetActive(false);
            }
        } 
    }
}
