using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingWithEnums : MonoBehaviour
{
    public enum Weapons { fist, sword, bow }
    [SerializeField] private Weapons _equippedWeapon;

    [SerializeField] private bool _switchWeapon;
    [SerializeField] private Weapons _switchWeaponTo;
    [SerializeField] private bool _displayWeaponStats;


    [System.Flags] public enum Magic { arcane = 0, fire = 1, water = 2, earth = 4, wind = 8, dark = 16, blood = 32, light = 64 }
    [SerializeField] private Magic _currentMagic;

    [SerializeField] private bool _addMagic, _removeMagic, _setToSpecificMagic, _randomlySelectAnActiveMagic;
    [SerializeField] private Magic _magicAdjustment;

    
    [System.Flags] public enum StatusEffects { burning = 1, blinded = 2, frozen = 4, electrocuted = 8, slowed = 16, rooted = 32, lifeDraining = 64, poisoned = 128 }
    [SerializeField] private StatusEffects _currentStatusEffect;
    [SerializeField] private bool _hasStatusEffect;
    [SerializeField] private bool _randomlySelectStatusEffect;


    private void Update()
    {
        ChangeWeapon();
        WeaponStatDisplay();

        AddMagic();
        RemoveMagic();
        SetToSpecificMagic();

        if (_hasStatusEffect && _randomlySelectAnActiveMagic)
        {
            Debug.Log("Apply " + RandomlySelectStatus() + " status");
            _randomlySelectAnActiveMagic = false;
        }
        RandomlySelectStatus();
    }

    private void ChangeWeapon()
    {
        if (_switchWeapon)
        {
            _equippedWeapon = _switchWeaponTo;
            _switchWeapon = false;
        }
    }

    private void AddMagic()
    {
        if (_addMagic)
        {
            _currentMagic |= _magicAdjustment;
            _addMagic = false;
        }
    }

    private void RemoveMagic()
    {
        if (_removeMagic)
        {
            _currentMagic &= ~_magicAdjustment;
            _removeMagic = false;
        }
    }

    private void SetToSpecificMagic()
    {
        if (_setToSpecificMagic)
        {
            _currentMagic = _magicAdjustment;
            _setToSpecificMagic = false;
        }
    }
    private void WeaponStatDisplay()
    {
        if (_displayWeaponStats)
        {
            switch (_equippedWeapon)
            {
                case Weapons.fist:
                    Debug.Log("fist attack damage = 5");
                    break;

                case Weapons.sword:
                    Debug.Log("sword attack damage = 25");
                    break;

                case Weapons.bow:
                    Debug.Log("bow attack damage = 18");
                    break;
            }

            _displayWeaponStats = false;
        }
    }

    public Magic GetRandomMagic()
    {
        // Get all the active status effects from currentStatusEffects
        Magic[] activeEffects = Enum.GetValues(typeof(Magic)) as Magic[];
        Magic[] activeStatusEffects = Array.FindAll(activeEffects, effect => _currentMagic.HasFlag(effect));

        // If no active status effects found, return default value (0)
        if (activeStatusEffects.Length == 0)
        {
            Debug.Log("no active effects found");
            return 0;
        }

        // Choose a random index within the range of active status effects
        int randomIndex = UnityEngine.Random.Range(1, activeStatusEffects.Length);

        // Return the randomly selected active status effect
        return activeStatusEffects[randomIndex];
    }

    private StatusEffects RandomlySelectStatus()
    {


        return StatusEffects.burning;
    } 
}
