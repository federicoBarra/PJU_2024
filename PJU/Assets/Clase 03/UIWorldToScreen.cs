using UnityEngine;

public class UIWorldToScreen : MonoBehaviour
{
	public Transform enemy;
	public float angle;

	RectTransform thisRT;
	Camera cam;

	private void Start()
	{
		thisRT = GetComponent<RectTransform>();
		cam = Camera.main;
	}

	private void LateUpdate()
	{
		//Vector3 enemyCamDir = enemy.transform.position - cam.transform.position;
		//angle = Vector3.Angle(cam.transform.forward, enemyCamDir);

		//https://docs.unity3d.com/ScriptReference/RectTransform.html
		thisRT.position = cam.WorldToScreenPoint(enemy.position);
	}
}
