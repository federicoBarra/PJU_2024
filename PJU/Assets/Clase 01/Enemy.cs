using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IHittable
{
	public float health =100;
	private NavMeshAgent agent;

	public Transform target;

	private Animator animator;

	public static event Action<Enemy> OnEnemySpawned;
	public static event Action<Enemy> OnEnemyDeath;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
		GameObject target = MegaObjetoDeInformacionDelJuego.Get().player;
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


