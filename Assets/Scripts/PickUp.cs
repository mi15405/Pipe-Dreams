using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    private GameController gameController;

    private void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }


    private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))	
		{
            //kada pokupi pickup, updatuje se score za 10
            gameController.UpdateScore(10);

            Destroy(gameObject);
		}
	}

}
