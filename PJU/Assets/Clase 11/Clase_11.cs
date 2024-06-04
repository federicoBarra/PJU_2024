using System;
using System.Collections;
using System.Collections.Generic;
using nullbloq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

//MVVM
public class PlayerConUI
{
	public float health;
	public Image healthBar;

	//void Update()
	//{
	//	//rece
	//}

	void ReceiveDamage()
	{
		health -= 10;
		if (healthBar)
			healthBar.fillAmount = health / 100;

		// lei archivo
		//healthBar = null

		try
		{
			//healthBar.fillAmount = health / 100;
			File.ReadAllBytes("c:\titi.txt");
			//leer algo de la web
		}
		catch (NullReferenceException e)
		{
			Console.WriteLine(e);
			throw;
		}
	}
}

public class PlayerSinUI
{
	public float health;
	public event Action<float> OnDamageReceived;

	void ReceiveDamage()
	{
		health -= 10;
		OnDamageReceived?.Invoke(health);
		//healthBar.fillAmount = health / 100;
	}
}

public class PlayerUI
{
	private PlayerSinUI player; //HealthComponent
	public Image healthBar;

	void Start()
	{
		player.OnDamageReceived += Refresh;
	}

	private void Refresh(float obj)
	{
		healthBar.fillAmount = player.health / 100;
	}

	//corutina FX, puede tirar texto

}

public class AchievementsManager
{
	private PlayerSinUI player; //HealthComponent

	public float damageAmoutn;

	void Start()
	{
		player.OnDamageReceived += AddToReceivaDaamgeAchievemnt;
	}

	private void AddToReceivaDaamgeAchievemnt(float obj)
	{
		damageAmoutn += obj;
		if (damageAmoutn > 100)
			; //tiro achievemtn

	}
}






public class EnemyManager
{
	public List<Enemy> enemies;

	public static event Action OnAllEnemiesDied;
	void Start()
	{
		Enemy.OnEnemySpawned += EnemySpawned;
		Enemy.OnEnemyDeath += EnemyDied;

		float lTimer = MegaObjetoDeInformacionDelJuego.Get().levelTimer;

		//GetComponent<Collider>();
	}
	public int enemiesCount;
	private void EnemySpawned(Enemy obj)
	{
		enemies.Add(obj);
		enemiesCount++;
	}

	private void EnemyDied(Enemy obj)
	{
		enemies.Remove(obj);
		enemiesCount--;
		//|if (enemyList.count <= 0)
		//|	termina el nivel OnAllEnemiesDied?.invoke()
		//|
	}
}

public class Clase_11 : MonoBehaviourSingleton<Clase_11> //Game Manager
{
	public Transform bone;
	public Animator animator;
	public float angle;
	public Transform lookObj;
	public Transform rightHandObj;

	public bool ikActive;

	[Header("Needed")]
	public List<GameObject> neededPrefabsList;

	public Enemy[] enemyList;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		Enemy.OnEnemySpawned += EnemySpawned;
		Enemy.OnEnemyDeath += EnemyDied;

		//GetComponent<Collider>();
	}
	public int enemiesCount;
	private void EnemySpawned(Enemy obj)
	{
		enemiesCount++;
	}

	private void EnemyDied(Enemy obj)
	{
		enemiesCount--;
		//|if (enemyList.count <= 0)
		//|	termina el nivel
		//|
	}

	// Update is called once per frame
	void Update()
    {
		if (VerboseConfig.Get().playerVerbose)
			Debug.Log("ikActive: " + ikActive);

		enemyList = FindObjectsOfType<Enemy>();

		//|if (enemyList.count <= 0)
		//|	termina el nivel
		//|
	}




	void LateUpdate()
    {
        //Quaternion newQuat = Quaternion.Euler(0, angle, 0);
		//
        //bone.localRotation = newQuat;
    }

    void OnAnimatorIK()
    {
	    if (animator)
	    {

		    //if the IK is active, set the position and rotation directly to the goal.
		    if (ikActive)
		    {

			    // Set the look target position, if one has been assigned
			    if (lookObj != null)
			    {
				    animator.SetLookAtWeight(1);
				    animator.SetLookAtPosition(lookObj.position);
			    }

			    // Set the right hand target position and rotation, if one has been assigned
			    if (rightHandObj != null)
			    {
				    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
				    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
				    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
				    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
			    }

		    }

		    //if the IK is not active, set the position and rotation of the hand and head back to the original position
		    else
		    {
			    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
			    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
			    animator.SetLookAtWeight(0);
		    }
	    }
    }
}

