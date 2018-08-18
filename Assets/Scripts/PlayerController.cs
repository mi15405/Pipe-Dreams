using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float distanceFromCenter;

	// ROTATION
	[SerializeField]
	private float rotateSpeed;

	// JUMP
	private enum JumpType { Big, Mini};
	private JumpType jumpType;

	[SerializeField]
	private float jumpTime;     // Trajanje velikog skoka

	[SerializeField]
	private float miniJumpTime;  // Trajanje malog skoka

	private float jumpStartTime;  // Trenutak kada je skok zapocet
	private Vector3 jumpOrigin;   // Tacka sa koje se skace
	private Vector3 jumpTarget;   // Tacka na koju se skace

	private bool isJumping = false;     // Skok je u toku
	private bool isRotating = true;     // Rotacija je u toku

	private bool rotatingRight;           
	private bool changeDirectionPressed;
	private bool jumpPressed;
	private bool miniJumpPressed;

	// TOUCH
	[SerializeField]
	private float minSwipeLength;
	private Vector2 touchOrigin;

	private void Start()
	{
		// Postavlja se rastojanje igraca od centra
		transform.localPosition = new Vector3(0f, distanceFromCenter, 0f);
	}

	private void Update()
	{
		GetInput();

		if (!isJumping && (jumpPressed || miniJumpPressed))
		{
			// Cuvamo vrstu skoka
			if (jumpPressed)
				jumpType = JumpType.Big;
			else if (miniJumpPressed)
				jumpType = JumpType.Mini;

			// Zapocinjemo skok
			StartJump();
		}

		if (isRotating)
			Rotate();

		if (isJumping)
			Jump();
	}

	private void GetInput()
	{
#if UNITY_STANDALONE
		changeDirectionPressed = Input.GetKeyDown(KeyCode.Space);
		jumpPressed = Input.GetKeyDown(KeyCode.S);
		miniJumpPressed = Input.GetKeyDown(KeyCode.D);
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

	private void StartJump()
	{
		// Vreme pocetka skoka
		jumpStartTime = Time.time;

		// Pozicija sa koje se skace
		jumpOrigin = transform.position;

		if (jumpPressed)
		{
			/* 
			 * Odredjuje se pozicija tacke na koju se skace. Mnozenjem x i y koordinata sa -1 dobija
			 * se tacka na suprotnoj strani kruga
			 */
			jumpTarget = jumpOrigin;
			jumpTarget.x *= -1;
			jumpTarget.y *= -1;
		}
		else
		{
			/* Ciljna tacka je centar kruga */
			jumpTarget = Vector3.zero;
		}

		// Postavljamo fleg da je skok u toku
		isJumping = true;

		// Gasimo rotaciju prilikom skoka 
		isRotating = false;
	}
	
	private void Jump()
	{
		// Proteklo vreme od pocetka skoka
		var elapsedTime = Time.time - jumpStartTime;

		// Izvrsava se odredjeni skok
		if (jumpType == JumpType.Big)
			BigJump(elapsedTime);
		else if (jumpType == JumpType.Mini)
			MiniJump(elapsedTime);
	}

	private void BigJump(float elapsedTime)
	{
		// Procenat proteklog vremena
		var jumpFraction = elapsedTime / jumpTime;

		// Ukoliko je manje od 1 (100%) vrsi se interpolacija pozicije igraca
		if (jumpFraction < 1f)
			transform.position = Vector3.Lerp(jumpOrigin, jumpTarget, jumpFraction);
		else
		{
			// Inace je skok zavrsen
			transform.position = jumpTarget;
			isJumping = false;
			isRotating = true;
		}
	}

	private void MiniJump(float elapsedTime)
	{
		// Procenat proteklog vremena
		var jumpFraction = elapsedTime / miniJumpTime;

		if (jumpFraction < 1f)
		{
			/* 
			 * Interpoliramo sa sinusnom funkcijom, na intervalu [0, PI].
			 * Dobijacemo vrednosti od 0 do 1, pa od 1 do 0, sto nam predstavlja visinu skoka.
			 * Kada je 0, igrac je na ivici cevi, a kada je 1 igrac je u centru cevi
			 */
			var jumpHeight = Mathf.Sin(Mathf.PI * jumpFraction);
			transform.position = Vector3.Lerp(jumpOrigin, jumpTarget, jumpHeight);
		}
		else
		{
			// Inace je skok zavrsen, krajnja tacka je ona sa koje smo skocili
			transform.position = jumpOrigin;
			isJumping = false;
			isRotating = true;
		}
	}
	
	private void Rotate()
	{
		if (changeDirectionPressed)
		{
			rotatingRight = !rotatingRight;
			changeDirectionPressed = false;
		}

		// Rotacija igraca oko globalnog koordinatnog pocetka
		if (rotatingRight)
			transform.RotateAround(Vector3.zero, Vector3.forward, rotateSpeed * Time.deltaTime);
		else
			transform.RotateAround(Vector3.zero, Vector3.forward, -rotateSpeed * Time.deltaTime);
	}

	public void TakeDamage(float damage)
	{
		// Implementirati skidanje zivota	
	}

}
