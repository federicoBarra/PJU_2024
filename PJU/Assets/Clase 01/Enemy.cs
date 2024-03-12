using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float health =100;

	public void ReceiveDamage(float damage)
	{
		health -= damage;
	}
}
