using UnityEngine;
using System.Collections;

public class NeedleShooterShot : MonoBehaviour
{
  // 1 - Designer variables

  /// <summary>
  /// Damage inflicted
  /// </summary>
  public int damage = 1;
	public float bulletTimeAlive = 2f; // time bullet stays alive in seconds


    /// <summary>
    /// Projectile damage player or enemies?
    /// </summary>
    public bool isEnemyShot = true;

    void Start()
    {
        // 2 - Limited time to live to avoid any leak
        Destroy(gameObject, bulletTimeAlive); // 20sec
    }
}
