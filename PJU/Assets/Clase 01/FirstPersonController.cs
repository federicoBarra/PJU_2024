using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Input = UnityEngine.Input;

public interface IHittable
{
	public void ReceiveDamage(float damage);
	//public bool IsAlive { get; set; }
}

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour, IHittable
{
	public AnimationCurve headAnimationCurve;
	public Transform cameraTransform;

	public void ReceiveDamage(float damage)
	{
		Debug.Log("Me pegaron");
	}

	public float health = 100;

	public Transform look; //pivot
	[Header("Player Movement")]
	[Tooltip("Move speed of the character in m/s")]
	public float moveSpeed = 4.0f;
	[Tooltip("Sprint speed of the character in m/s")]
	public float sprintSpeed = 6.0f;
	[Tooltip("Rotation speed of the character")]
	public float rotationSpeed = 1.0f;

	[Space(10)]
	[Tooltip("The height the player can jump")]
	public float jumpHeight = 1.2f;
	[Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
	public float gravity = -15.0f;
	public float terminalVelocity = 53.0f;

	[Header("Player Grounded")]
	[Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
	public bool grounded = true;
	[Tooltip("Offset to mark feet position")]
	public float groundedOffset = 0.85f;
	[Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
	public float groundedRadius = 0.5f;
	[Tooltip("What layers the character uses as ground")]
	public LayerMask groundLayers;

	[Header("Camera Limits")]
	public float minCameraAngle = -90F;
	public float maxCameraAngle = 90F;

	public float crashForce = 10;

	private CharacterController controller;

	private Quaternion characterTargetRot;
	private Quaternion cameraTargetRot;

	private float verticalVelocity;

	private bool sprint;
	private bool jump;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
		characterTargetRot = transform.localRotation;
		cameraTargetRot = look.localRotation;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public float t;
	public float duration = 1;

	void Update()
	{
		jump = Input.GetKeyDown(KeyCode.Space);
		sprint = Input.GetKey(KeyCode.LeftShift);
		GroundedCheck();
		JumpAndGravity();
		Move();
		LookRotation();

		t += Time.deltaTime;
		if (t >= duration)
			t -= duration;
		Vector3 camPos = cameraTransform.localPosition;
		camPos.y = headAnimationCurve.Evaluate(t / duration);
		cameraTransform.localPosition = camPos;
	}

	private void GroundedCheck()
	{
		Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);
		grounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers, QueryTriggerInteraction.Ignore);
	}

	//public void Jump() //un evento que se llama desde el manager de Input.
	//{
	//	if (grounded && jump)
	//	{
	//		// the square root of H * -2 * G = how much velocity needed to reach desired height
	//		verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
	//	}
	//}

	private void JumpAndGravity()
	{
		if (grounded && jump)
		{
			// the square root of H * -2 * G = how much velocity needed to reach desired height
			verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
		else
		{
			// if we are not grounded, do not jump
			jump = false;
		}

		// apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
		if (verticalVelocity < terminalVelocity)
			verticalVelocity += gravity * Time.deltaTime;
	}

	private void Move()
	{
		float hor = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");

		Vector3 direction = new Vector3(hor, 0, vert);

		direction = direction.x * transform.right + direction.z * transform.forward;

		// set target speed based on move speed, sprint speed and if sprint is pressed
		float targetSpeed = sprint ? sprintSpeed : moveSpeed;

		// move the player
		controller.Move(direction.normalized * (targetSpeed * Time.deltaTime) + new Vector3(0.0f, verticalVelocity, 0.0f) * Time.deltaTime);
	}

	public void LookRotation()
	{
		float yRot = Input.GetAxis("Mouse X") * rotationSpeed;
		float xRot = Input.GetAxis("Mouse Y") * rotationSpeed;

		characterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
		cameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

		cameraTargetRot = ClampRotationAroundXAxis(cameraTargetRot);

		transform.localRotation = characterTargetRot;
		look.localRotation = cameraTargetRot;
	}

	Quaternion ClampRotationAroundXAxis(Quaternion q)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;

		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
		angleX = Mathf.Clamp(angleX, minCameraAngle, maxCameraAngle);

		q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

		return q;
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		//Debug.Log("Choque contra: " + hit.gameObject.name);
		//if (hit.gameObject.name == "Sphere (1)")
		//{
		//	hit.gameObject.GetComponent<Rigidbody>().isKinematic = false;
		//}
		//
		//Rigidbody rig = hit.gameObject.GetComponent<Rigidbody>();
		//
		//if (!rig) 
		//	return;
		//
		//Vector3 dir = rig.transform.position - transform.position;
		//dir.Normalize();
		//
		//rig.AddForce(dir * crashForce, ForceMode.VelocityChange);
		//rig.AddExplosionForce();
	}

	
}
