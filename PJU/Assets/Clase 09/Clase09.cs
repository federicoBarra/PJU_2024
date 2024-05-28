using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase09 : MonoBehaviour
{
	private Weapon__ currentWeapon;
	public Pistol pistol;
	public Melee melee;

	public Transform weaponTransform;
	public Transform hipBone;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
	    //Time.unscaledDeltaTime;
	    //Time.timeScale = 0;
        //Time.fixedDeltaTime
        //Time.fixedUnscaledDeltaTime
		//recibo un input de cambiar de arma.
		currentWeapon = melee;
		currentWeapon = pistol;



		if (currentWeapon is Melee)
		{

		}
		if (currentWeapon is IAttack01Handling)
		{

		}

		weaponTransform.localPosition = Vector3.forward;

		if (currentWeapon is IAttack01Handling ||
		    currentWeapon is IAttack02Handling)
		{

		}

		//hipBone.localRotation = 

	}

    public void PlayerAttack()
    {
		currentWeapon.Attack();
    }

    IEnumerator Coru()
    {
	    yield return new WaitForSecondsRealtime(5);

		yield return null;
    }
}

public interface IAttack01Handling
{
	void HandleAttackButton01();
}

public interface IAttack02Handling
{
	void HandleAttackButton02();
}


public class Weapon__ : MonoBehaviour
{
	public float rateOfFire;
	//burst
	public virtual void Attack()
	{

	}

	public virtual void HandleAttackButton01()//boton izq
	{

	}
	public virtual void HandleAttackButton02() //boton derecho
	{

	}
}

public class Pistol : Weapon__, IAttack01Handling
{
	public override void Attack()
	{
		base.Attack();
	}

	public override void HandleAttackButton01()
	{
		base.HandleAttackButton01();
	}
}

public class AK47 : Weapon__
{
	public override void Attack()
	{
		base.Attack();
	}
}

public class Melee : Weapon__, IAttack01Handling, IAttack02Handling
{
	public override void Attack()
	{
		base.Attack();
	}
	public override void HandleAttackButton01()
	{
		base.HandleAttackButton01();
	}

	public override void HandleAttackButton02()
	{
		base.HandleAttackButton01();
	}

}

public class RocketLauncher : Weapon__, IAttack01Handling, IAttack02Handling
{
	public override void Attack()
	{
		base.Attack();
	}
	public override void HandleAttackButton01()
	{
		base.HandleAttackButton01();
	}

	public override void HandleAttackButton02()
	{
		base.HandleAttackButton01();
	}

}

public class Enemy__
{
	private WaypointsPath path;

}

public class WaypointsPath
{
	private List<Waypoint> waypoints;
}


public class Waypoint
{
	public Vector3 pos;
}

public class Pickup : MonoBehaviour
{
	public enum PickupType
	{
		Life, 
		Ammo,
		Pistol,
	}

	public PickupType pType;

	public void PickedUp()
	{
		switch (pType)
		{
			case PickupType.Life:
				break;
			case PickupType.Ammo:
				break;
			case PickupType.Pistol:
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}

		//apagar renderer y collider
		Invoke(nameof(Respawn), 10);
	}

	public void Respawn()
	{
		//asigna nueva posicion.
		//prende renderer y collider
	}
}