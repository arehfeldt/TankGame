using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;       
    //public AudioSource m_ExplosionAudio;              
    public float m_MaxDamage = 20f;                  
    //public float m_ExplosionForce = 1000f;            
    public float m_MaxLifeTime = 2f;                  
    public float m_ExplosionRadius = 5f;              


    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Find all the tanks in an area around the shell and damage them.
        // change tank mask, currenlty used in tutorial to find all tanks, so need it to be only player 
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

        // Go through all the colliders
        for (int i = 0; i < colliders.Length; i++)
        {
            // Get the rigid body of the current collider
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            // If they don't have a rigidbody, then ignore it and go to next collider
            if (!targetRigidbody) continue;

            // Find health script
            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

            // If no health script, then ignore and go to next collider
            if (!targetHealth) continue;

            // Calculate damage based on distance to shell
            float damage = CalculateDamage(targetRigidbody.position);

            // Deal the damage
            targetHealth.TakeDamage(damage);
		}

        // Unparent the particles from the shell
        m_ExplosionParticles.transform.parent = null;

        // Play the particle system
        m_ExplosionParticles.Play();

        // Once particles have played, destroy them 
        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);

        // Destroy the shell
        Destroy(gameObject);
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.

        // Create a vector from shell to target
        Vector3 explosionToTarget = targetPosition - transform.position;

        // Calculate distance from shell to target
        float explosionDistance = explosionToTarget.magnitude;

        // Calculate proportio of the maximum distance (explosionRadius) the target is away
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        // Calculate damage as this proprotion of the emaximum possible damage
        float damage = relativeDistance * m_MaxDamage;

        // Make sure the minimum damage is 0
        damage = Mathf.Max(0f, damage);

        return damage;
    }
}