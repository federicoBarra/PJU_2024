using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	public Transform sphere01;
	public Transform sphere02;

	public Transform center;

	public float angle;
	public float signedAngle;

	public AudioClip clip;

	// Start is called before the first frame update
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
		if (VerboseConfig.Get().playerVerbose)
			Debug.Log("PLayer alive");
#endif

		Vector3 dir01 = sphere01.position - center.position;
	    Vector3 dir02 = sphere02.position - center.position;

	    angle = Vector3.Angle(dir01, dir02);
	    signedAngle = Vector3.SignedAngle(dir01, dir02, Vector3.up);

		AudioSource.PlayClipAtPoint(clip, transform.position);
	}
}
