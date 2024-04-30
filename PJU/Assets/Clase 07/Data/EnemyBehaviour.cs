using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
	private bool seEstaMoviendo;
	private bool isAlive;

	private NavMeshAgent agent;

	public enum EnemyState
	{
		Patrol,
		GointToTarget,
		Attacking,
		Etc
	}

	public EnemyState state;
	public Animator animator;

    // Update is called once per frame
    void Update()
    {
	    switch (state)
	    {
		    case EnemyState.Patrol:
			    break;
		    case EnemyState.GointToTarget:
				//llegue al player
				//setState(EnemyState.Attacking)

				break;
		    case EnemyState.Attacking:
			    break;
		    case EnemyState.Etc:
			    break;
		    default:
			    throw new ArgumentOutOfRangeException();
	    }
    }

	public void SetState(EnemyState newState)
	{
		Debug.Log("Enemy SET State: " + newState);
		state = newState;

		switch (state)
		{
			case EnemyState.Patrol:
				break;
			case EnemyState.GointToTarget:
				break;
			case EnemyState.Attacking:
				agent.isStopped = true; //EnemyMover, EntityMover //EnemyAnimations
				animator.SetTrigger("Attack");
				break;
			case EnemyState.Etc:
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

}


public class enemyanimtion : MonoBehaviour
{
	public Animator animator;
	public void Attack()
	{
		animator.SetTrigger("Attack");
	}
	//manejasr la animacion de enemigo
}