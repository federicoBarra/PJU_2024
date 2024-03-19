using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHUD : MonoBehaviour
{
	public FirstPersonController player;
	public PlayerCombat combat;

	public Image mira;
	public TMP_Text playerLife;

    // Update is called once per frame
    void Update()
    {
	    playerLife.text = player.health.ToString("N0");
	    mira.color = combat.aimingAtEnemy ? Color.red : Color.white;
    }
}
