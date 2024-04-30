using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "My SOs/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
	public float initialHealth;
	public float meleeDamage;
}



public class ItemConfig : ScriptableObject
{
	public string displayName;
	public string displayDescription;
	public int value;
}