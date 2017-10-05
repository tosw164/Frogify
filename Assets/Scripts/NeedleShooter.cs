using UnityEngine;
using System.Collections;

public class NeedleShooter : MonoBehaviour {

	public GameObject projectile;

	public float shootingRate;
	float shootingRateCounter;
	// Use this for initialization
	void Start () {
		shootingRateCounter = shootingRate;
	}
	
	// Update is called once per frame
	void Update () {
		shootingRateCounter -= Time.deltaTime;
		if (shootingRateCounter <= 0.0f) {
			GameObject needle = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			shootingRateCounter = shootingRate;
		}
	}
}
