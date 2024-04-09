using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IHittable
{
	public float health =100;
	private NavMeshAgent agent;

	public Transform target;

	private Animator animator;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		if (agent)
		{
			agent.SetDestination(target.position);
			animator.SetFloat("Velocidad", agent.velocity.magnitude);
		}
	}

	public void ReceiveDamage(float damage)
	{
		health -= damage;
	}
}


