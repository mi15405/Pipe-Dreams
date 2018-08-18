using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSegment : MonoBehaviour {

	[SerializeField]
	private Transform end;
	public Transform End
	{ 
		get { return end; } 
		set { end = value; } 
	}

	private Vector3 pipeDirection;
	private float pipeLength;

	private void Awake()
	{
		// Smer pruzanja segmenta cevi
		pipeDirection = (end.position - transform.position).normalized;

		// Duzina segmenta cevi
		pipeLength = (end.position - transform.position).magnitude;
	}

	public void SpawnObjects(List<GameObject> objects)
	{
		// Udaljenost od centra
		var offset = 5f;	

		// Razmak izmedju dva objekta
		var step = pipeLength / objects.Count;

		// Trenutna pozicija na liniji koja spaja pocetak i kraj cevi
		var currentPosition = transform.position + pipeDirection * step / 2;

		foreach (var obj in objects)
		{
			var angle = Random.Range(0, 360);

			// Generisemo objekat sa zadatim odstojanjem (offset) i rotacijom (angle) u odnosu na centar (currentPosition)
			SpawnAt(obj, currentPosition, offset, angle);

			// Pomeramo trenutni centar u smeru cevi za izracunati korak
			currentPosition += pipeDirection * step;
		}
	}

	private void SpawnAt(GameObject obj, Vector3 position, float offset, float angle)
	{
		var spawnedObject = Instantiate(obj, transform);	
		
		// Pozicija sa zadatim odstojanjem
		spawnedObject.transform.position = position + new Vector3(0f, offset, 0f);

		// Rotacija oko centra trenutnog poprecnog preseka
		spawnedObject.transform.RotateAround(position, pipeDirection, angle);	
	}

}
