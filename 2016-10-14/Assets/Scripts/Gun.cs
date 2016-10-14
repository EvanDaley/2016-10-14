using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public float fireRate = .2f;
	float fireCooldown = 0;
	public GameObject muzzle;
	public float shotForce = 400f;
	public GameObject bullet;

	private int roundsInClip = 0;
	public int clipSize = 4;
	public bool firing = false;
	private Vector3 target;

	public float reloadCooldown = 0;
	public float reloadInterval = 1f;

	public void TryFire(Vector3 target)
	{
		this.target = target;
		firing = true;
	}

	void Start()
	{
		roundsInClip = clipSize;
	}

	void Update()
	{
		if (firing && Time.time > fireCooldown && Time.time > reloadCooldown)
		{
			if (roundsInClip > 0)
			{
				fireCooldown = Time.time + fireRate;
				Fire (target);

			} else
			{
				firing = false;
				reloadCooldown = Time.time + reloadInterval;
				Reload ();
			}

		}
	}

	void Reload()
	{
		roundsInClip = clipSize;
	}

	public void Fire(Vector3 target)
	{
		if (bullet != null && muzzle != null)
		{
			roundsInClip--;
			Vector3 direction = target - muzzle.transform.position;
			GameObject bulletInstance = GameObject.Instantiate (bullet, muzzle.transform.position, muzzle.transform.rotation) as GameObject;
			Rigidbody rbody = bulletInstance.GetComponent<Rigidbody> ();
			rbody.AddForce (direction.normalized * shotForce);
		}
	}
}

