using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private GameController gameController;

    private void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    [SerializeField]
	private float damage;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
            //skini zivot kada player udari u prepreku
            gameController.UpdateLives(1);

			var player = other.gameObject.GetComponentInParent<PlayerController>();	

			if (player != null)
				player.TakeDamage(damage);
			else
				Debug.LogError("Can't find PlayerController in Obstacle OnTriggerEnter!");
		}
	}
}
