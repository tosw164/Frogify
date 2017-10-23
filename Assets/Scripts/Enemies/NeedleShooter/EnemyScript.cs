using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour
{
    private WeaponScript[] weapons; // store the weapons as a child of this object

    void Awake()
    {
        // Retrieve the weapon only once
        weapons = GetComponentsInChildren<WeaponScript>();
    }

    void Update()
    {
        foreach (WeaponScript weapon in weapons)
        {
            // Auto-fire
            if (weapon != null && weapon.CanAttack)
            {
                weapon.Attack(true);
            }
        }
    }
}
