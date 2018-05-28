// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour {

	public GameObject bulletPrefab;
    public float bulletSpeed = 5.0f;
    public bool TriggerShoot;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (TriggerShoot)
        {
            GameObject instance = Instantiate(bulletPrefab);
            instance.transform.position = transform.position;
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            Camera camera = GetComponentInChildren<Camera>();
            rb.velocity = camera.transform.rotation * Vector3.forward * bulletSpeed;
			TriggerShoot = false;
        }
    }
}
