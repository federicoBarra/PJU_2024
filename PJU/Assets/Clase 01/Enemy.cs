using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public float health =100;
	private NavMeshAgent agent;

	public Transform target;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		agent.SetDestination(target.position);
	}

	public void ReceiveDamage(float damage)
	{
		health -= damage;
	}
}
