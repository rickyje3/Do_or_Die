using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StacheAttacks : MonoBehaviour
{
    public GameObject projectilePrefab; //projectile
    public Transform shootPoint; //point the projectile is spawned at
    public float speed = 10f; //how fast the projectile moves

    //Whatever prefab you are using for the projectile must also have this script assigned. The spawn function doesn't need to be assigned

    //trigger for the activator
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnAndShoot();
        }
    }

    //collision for the projectile
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if the collided object is the player
        {
            // Call the DamageHealth method in the PlayerMovement script attached to the player
            collision.gameObject.GetComponent<PlayerMovement>().DamageHealth();
            Debug.Log("Projectile hit player");
        }
		
		if (collision.gameObject.CompareTag("Boss") && this.gameObject.CompareTag("Boss Coin")) // Check if the collided object is the boss
        {
			Destroy(this.gameObject);
            // Call the DamageHealth method in the script with boss
            collision.gameObject.GetComponent<StacheHealth>().DamageHealth();
            Debug.Log("Projectile hit Stache");
        }
		
        //place particle effect here
        Destroy(gameObject, 10); 
    }

    //Projectile shot function
    public void SpawnAndShoot()
    {
        //play animation
		
        //Instantiate a new projectile at the shootPoint position and rotation
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        //Get the rigidbody component of the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        //Check if the rigidbody component exists
        if (rb != null)
        {
            // Apply force to shoot the projectile. I have it shooting right because the card moving forward makes it shoot vertically 
            rb.AddForce(shootPoint.right * speed, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Rigidbody component not found in the projectile prefab!");
        }
    }
}