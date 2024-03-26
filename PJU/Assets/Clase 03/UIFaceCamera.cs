using UnityEngine;

public class UIFaceCamera : MonoBehaviour
{
	public Camera cam;
	public bool matchYaxis;

	// Use this for initialization
	private void Start()
	{
		cam = Camera.main;
	}

	// Update is called once per frame
	private void Update()
	{

		Vector3 pos = cam.transform.position;
		if (matchYaxis)
			pos.y = transform.position.y;

		transform.LookAt(pos, Vector3.up);
	}
}
