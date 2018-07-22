using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	[SerializeField]
	private float breakSpeed;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			var player = other.gameObject.GetComponentInParent<PlayerController>();	

			if (player != null)
			{
				if (breakSpeed > player.RelativeSpeed)
					player.Die();
				else
					Destroy(gameObject);
			}
			else
				Debug.LogError("Can't find PlayerController in Obstacle OnTriggerEnter!");
		}
	}
}
