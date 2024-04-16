using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurveTest : MonoBehaviour
{
	//pos
	//rot
	//public Animator ani;

	public AnimationCurve curve;
	public AnimationCurve curveColor;
	public Material sharedMaterial;
	public Material newInstanceMaterial;

	public Color originalColor;
	public Color hitcolor;

	public float duration = 2;
	//public float scaleMaxSize = 2;
	private float t;

	private Renderer renderer;

	void Awake()
	{
		renderer = GetComponent<Renderer>();
		sharedMaterial = GetComponent<Renderer>().sharedMaterial;
		newInstanceMaterial = GetComponent<Renderer>().material;
		originalColor = sharedMaterial.color;
	}

    // Update is called once per frame
    void Update()
    {
		//uso del renderer

		//t += Time.deltaTime;
		//
		//if (t >= duration)
		//    t = 0;
		//
		//float valorDe0a1 = t / duration;
		//
		//float scale = curve.Evaluate(valorDe0a1);
		//
		//transform.localScale = Vector3.one * scale;

		if (Input.GetKeyDown(KeyCode.Space))
	    {
		    StartCoroutine(Hit());
	    }
	}

    IEnumerator Hit()
    {
	    float tt = 0;

	    while (tt<=duration)
	    {
		    tt += Time.deltaTime;
		    float valorDe0a1 = tt / duration;

		    float scale = curve.Evaluate(valorDe0a1);

		    transform.localScale = Vector3.one * scale;

		    float colorVal = curveColor.Evaluate(valorDe0a1);

		    sharedMaterial.color = Color.Lerp(originalColor, hitcolor, colorVal);

			yield return null;
		}
	}
}


public class Weapon : MonoBehaviour
{
	[SerializeField]
	[Tooltip("The damage the weapon makes")]
	private float damage;

	/// <summary>
	/// Toda la descrtion de que hjace esto
	/// </summary>
	/// <param name="p"> Este parecejkask jasldkj ha</param>
	public void LoadFirstLevel(float p)
	{
		SceneManager.LoadScene("Level 01");
	}

	/// <summary>
	/// Option
	/// </summary>
	public void Option()
	{
		SceneManager.LoadScene("Level 01");
	}

	/// <summary>
	/// open credits.
	/// </summary>
	public void CreditButton() //NO
	{
		SceneManager.LoadScene("Level 01");
	}

	public void OpenCreditsWindow() //NO
	{
		//SceneManager.LoadScene("Level 01");
		//options.setActive(true)
		//Time.timeScale = 0; NO
	}


	/// <summary>
	/// Play the game.
	/// </summary>
	public void Exit()
	{
		SceneManager.LoadScene("Level 01");
	}
}


public class PlayerLoco : MonoBehaviour
{
	private Action onDeath;

	void Awake()
	{
		//onDeath += ShowScore;
		//onDeath += ExplosionAnim;
		//onDeath += ExplosionAnim02;
		//onDeath += ExplosionAnim03;
		//onDeath += ExplosionAnim04;

		//onDeath += OnDeath;
	}

	void OnDeath()
	{
		//ShowScore();
		//ExplosionAnim();
		//ExplosionAnim02();
		//ExplosionAnim03();
		//ExplosionAnim04();
	}


	void Die()
	{
		onDeath?.Invoke();
		ShowScore();
		ExplosionAnim();
	}


	void ShowScore()
	{

	}

	void ExplosionAnim()
	{

	}


}