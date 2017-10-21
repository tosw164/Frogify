using UnityEngine;
using System.Collections;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
    //--------------------------------
    // 1 - Designer variables
    //--------------------------------

    /// <summary>
    /// Projectile prefab for shooting
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    /// Cooldown in seconds between two shots
    /// </summary>
    public float shootingRate = 0.25f;

    public int shotAngleInZ;

    //--------------------------------
    // 2 - Cooldown and animator
    //--------------------------------

    private float shootCooldown;
    private Animator shooting;

    void Start()
    {
        Debug.Log("In WeaponScript start");
        shooting = GetComponentInParent<Animator>();
        shootCooldown = 0f;
        transform.rotation = Quaternion.Euler(0, 0, shotAngleInZ);
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    //--------------------------------
    // 3 - Shooting from another script
    //--------------------------------

    /// <summary>
    /// Create a new projectile if possible
    /// </summary>
    public void Attack(bool isEnemy)
    {
        shooting.SetBool("Shoot", true);
        if (CanAttack)
        {

            StartCoroutine(Waiting());

            shootCooldown = shootingRate;

            // Create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Assign position
            shotTransform.position = transform.position;

            // The is enemy property
            NeedleShooterShot shot = shotTransform.gameObject.GetComponent<NeedleShooterShot>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // Make the weapon shot always towards it
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                move.direction = this.transform.right; // towards in 2D space is the right of the sprite
            }
            shooting.SetBool("Shoot", false);
            Debug.Log(shooting.GetBool("Shoot"));
        }
    }

    /// <summary>
    /// Is the weapon ready to create a new projectile?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }

    IEnumerator Waiting() {
       
        yield return new WaitForSeconds(2.75f);
        shooting.SetBool("Shoot", true);
        Debug.Log(shooting.GetBool("Shoot"));
        //yield return new WaitForSeconds(1f);
    }

}