using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonusPickup : MonoBehaviour {

    private GameController gameController;

    private void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            gameController.UpdateLives(-1);

            Destroy(gameObject);
        }
    }
}
