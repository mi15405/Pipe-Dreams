using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] spawnObstacle;

	[SerializeField]
	private GameObject[] spawnPickup;

	[SerializeField]
	private float timeBetweenObstacleSpawns;

	[SerializeField]
	private float timeBetweenPickupSpawns;

	private float timeToSpawnObstacle;
	private float timeToSpawnPickup;

	private void Start()
	{
		timeToSpawnObstacle = timeBetweenObstacleSpawns;
		timeToSpawnPickup = timeBetweenPickupSpawns;
	}

	private void Update()
	{
		timeToSpawnObstacle -= Time.deltaTime;
		timeToSpawnPickup -= Time.deltaTime;

		if (timeToSpawnObstacle <= 0f)
		{
			SpawnItem(PickRandom(spawnObstacle));
			timeToSpawnObstacle = timeBetweenObstacleSpawns;
		}
		else if (timeToSpawnPickup <= 0f)
		{
			SpawnItem(PickRandom(spawnPickup));
			timeToSpawnPickup = timeBetweenPickupSpawns;
		}
	}

	private GameObject PickRandom(GameObject[] items)
	{
		return items[Random.Range(0, items.Length)];
	}

	private void SpawnItem(GameObject itemToSpawn)
	{
		var item = Instantiate(itemToSpawn);
		item.transform.position = transform.position;

		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360));
		item.transform.rotation = randomRotation;
	}

}
