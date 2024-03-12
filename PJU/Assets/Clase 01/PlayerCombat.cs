using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	public LayerMask enemies;

	public Vector3 offset;

	public float gunDamage = 10;


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

	    if (Input.GetMouseButtonDown(0))
	    {
		    Shoot();
	    }
    }

    void Shoot()
    {
	    RaycastHit hit;

	    Vector3 sourcePos = transform.position + offset;

	    // Does the ray intersect any objects excluding the player layer
	    if (Physics.Raycast(sourcePos, transform.forward, out hit, Mathf.Infinity, enemies))
	    {
		    Enemy e = hit.transform.GetComponentInParent<Enemy>();
			e.ReceiveDamage(gunDamage);

		    //hit.point

		    //Debug.DrawRay(sourcePos, transform.forward * hit.distance, Color.yellow, 2);
		    //Debug.Log("Did Hit");

		    //mi codigo de cuando le pego al chabon
	    }
	    else
	    {
		    //Debug.DrawRay(sourcePos, transform.forward * 1000, Color.white, 2);
		    //Debug.Log("Did not Hit");
	    }
	}
}
