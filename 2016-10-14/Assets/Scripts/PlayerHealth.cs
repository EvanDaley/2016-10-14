using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth;
	public float maxShields;

	private float curHealth;
	private float curSheilds;

	public float healthRegenRate;
	public float shieldRegenRate;


	void Start () 
	{
		curHealth = maxHealth;
		curSheilds = maxShields;
	}

	public float Health
	{
		get{ return curHealth; }
	}

	public float HealthNormalized
	{
		get{ return curHealth / maxHealth; }
	}

	public float Shields
	{
		get{ return curSheilds; }
	}

	public float ShieldsNormalized
	{
		get{ return curSheilds / maxShields; }

	}

	void Update()
	{
		Regen ();
		BindHealth ();
	}

	void BindHealth()
	{
		if (curHealth > maxHealth)
			curHealth = maxHealth;

		if (curSheilds > maxShields)
			curSheilds = maxShields;

		if (curHealth < 0)
			curHealth = 0;

		if (curSheilds < 0)
			curSheilds = 0;
	}

	void Regen()
	{
		if(curHealth < maxHealth)
			curHealth += Time.deltaTime * healthRegenRate;

		if (curSheilds < maxShields)
			curSheilds += Time.deltaTime * shieldRegenRate;
	}

}
