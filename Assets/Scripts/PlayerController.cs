using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	// ROTATION
	[SerializeField]
	private float rotateSpeed;

	[SerializeField]
	private float rotateSpeedIncrease;

	[SerializeField]
	private float maxBonusRotateSpeed;
	private float bonusRotateSpeed;

	// FORWARD MOVEMENT
	[SerializeField]
	private float relativeSpeed;
	public float RelativeSpeed {get {return relativeSpeed;} set {relativeSpeed = value;}}

	[SerializeField]
	private GameObject explosionObject;

	// JUMP
	[SerializeField]
	private Vector3 targetPosition;

	[SerializeField]
	private float jumpSpeed;

	private bool isJumping = false;
	private bool isRotating = true;

	private bool rotatingRight;
	private bool changeDirection;

	private void Update()
	{
		GetInput();

		if (Input.GetKeyDown(KeyCode.S) && !isJumping)
		{
			targetPosition = transform.position;
			targetPosition.x *= -1;
			targetPosition.y *= -1;
			isJumping = true;
			isRotating = false;
		}

		if (isRotating)
			Rotate();
		else if (isJumping)
			Jump();
	}

	private void Jump()
	{
		transform.position = Vector3.Lerp(transform.position, targetPosition, jumpSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
		{
			transform.position = targetPosition;
			isJumping = false;
			isRotating = true;
		}
	}

	private void GetInput()
	{
		changeDirection = Input.GetKeyDown(KeyCode.Space);
	}

	private void Rotate()
	{
		if (changeDirection)
		{
			rotatingRight = !rotatingRight;
			bonusRotateSpeed /= 2;
		}
		else
			bonusRotateSpeed += Time.deltaTime * rotateSpeedIncrease;

		// Limit bonus speed
		bonusRotateSpeed = Mathf.Clamp(bonusRotateSpeed, 0f, maxBonusRotateSpeed);

		var speed = rotateSpeed + bonusRotateSpeed;

		if (rotatingRight)
			transform.RotateAround(Vector3.zero, Vector3.forward, speed * Time.deltaTime);
		else
			transform.RotateAround(Vector3.zero, Vector3.forward, -speed * Time.deltaTime);
	}

	public void Die()
	{
		var explosion = Instantiate(explosionObject);
		explosion.transform.position = transform.position;

		Destroy(explosion, 4f);
	}


}
