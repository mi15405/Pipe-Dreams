using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	[SerializeField]
	private Vector3 targetPosition;

	[SerializeField]
	private float jumpSpeed;

	private void Start()
	{
		transform.position = targetPosition;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			targetPosition.y *= -1;
		}

		transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, jumpSpeed * Time.deltaTime);
	}

}
