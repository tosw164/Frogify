using UnityEngine;

//===========================
//Spawner class that is used to spawn a spawnee with a fixed time interval.
// Source: https://unity3d.com/learn/tutorials/projects/survival-shooter/more-enemies
//===========================
public class Spawner : MonoBehaviour
{
	//public fields which can be customized. Drag the relevant spawnee using the unity interface.
	public GameObject spawnee;                // The enemy prefab to be spawned.
	public float spawnTime = 3f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	//repetitively caled from start.
	void Spawn ()
	{
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		// Create an instance of the prefab at the randomly selected spawn point's position and rotation.
		Instantiate (spawnee, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}

