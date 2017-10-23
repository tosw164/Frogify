using UnityEngine;
using System.Collections;

/*
 * This needleshooter was unfortunately not used in the final product.
 * It instantiates a needle at a given rate.
 */
public class NeedleShooter : MonoBehaviour {

	// The needle projectile that is instantianted
	public GameObject projectile;

	// The time between each shot
	public float shootingRate;

	//The counter is the timer that increments down every update call. 
	float shootingRateCounter;

	// Sets the shooting rate counter to the rate, to start the down counter
	void Start () {
		shootingRateCounter = shootingRate;
	}
	
	// Decrements the counter by the time passed, delta time.
	// Once it reaches 0, instantiates the needle and fires, before resetting the counter back to the set rate.
	void Update () {
		shootingRateCounter -= Time.deltaTime;
		if (shootingRateCounter <= 0.0f) {
			GameObject needle = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			shootingRateCounter = shootingRate;
		}
	}
}
