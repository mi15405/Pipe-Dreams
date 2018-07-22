using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private bool hasRelativeSpeed = true;

	private PlayerController relativeTo;

	private void Awake()
	{
		if (hasRelativeSpeed)
			relativeTo = FindObjectOfType<PlayerController>();
	}

	private void Update()
	{
		var speed = moveSpeed;

		if (hasRelativeSpeed)
			speed *= relativeTo.RelativeSpeed;

		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
