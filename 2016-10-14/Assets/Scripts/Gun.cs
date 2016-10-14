using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public float fireRate = .2f;
	float fireCooldown = 0;
	public GameObject muzzle;
	public float shotForce = 400f;
	public GameObject bullet;

	public void TryFire(Vector3 target)
	{
		if (Time.time > fireCooldown)
		{
			fireCooldown = Time.time + fireRate;
			Fire (target);
		}
	}

	public void Fire(Vector3 target)
	{
		if (bullet != null && muzzle != null)
		{
			Vector3 direction = target - muzzle.transform.position;
			GameObject bulletInstance = GameObject.Instantiate (bullet, muzzle.transform.position, muzzle.transform.rotation) as GameObject;
			Rigidbody rbody = bulletInstance.GetComponent<Rigidbody> ();
			rbody.AddForce (direction.normalized * shotForce);
		}

	}
}

