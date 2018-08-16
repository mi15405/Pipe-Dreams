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
	private bool changeDirectionPressed;
	private bool jumpPressed;

	// TOUCH
	[SerializeField]
	private float minSwipeLength;
	private Vector2 touchOrigin;

	private void Update()
	{
		GetInput();

		if (jumpPressed && !isJumping)
			StartJump();

		if (isRotating)
			Rotate();

		if (isJumping)
			Jump();
	}

	private void StartJump()
	{
		targetPosition = transform.position;
		targetPosition.x *= -1;
		targetPosition.y *= -1;
		isJumping = true;
		isRotating = false;
		jumpPressed = false;
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
#if UNITY_STANDALONE
		changeDirectionPressed = Input.GetKeyDown(KeyCode.Space);
		jumpPressed = Input.GetKeyDown(KeyCode.S);
#else

		if (Input.touchCount <= 0)
			return;

		var touch = Input.GetTouch(0);

		if (touch.phase == TouchPhase.Began)
		{
			touchOrigin = touch.position;
		}
		else if (touch.phase == TouchPhase.Ended)
		{
			var swipeDirection = touch.position - touchOrigin;

			if (swipeDirection.magnitude < minSwipeLength)
				changeDirectionPressed = true;
			else
				jumpPressed = true;	
		}
#endif
	}

	private void Rotate()
	{
		if (changeDirectionPressed)
		{
			rotatingRight = !rotatingRight;
			bonusRotateSpeed /= 2;
			changeDirectionPressed = false;
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
