using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float m_StartingHealth = 100f;          
    //public Slider m_Slider;                        
    //public Image m_FillImage;                      
    //public Color m_FullHealthColor = Color.green;  
    //public Color m_ZeroHealthColor = Color.red;    
    public GameObject m_ExplosionPrefab;
    
    
    //private AudioSource m_ExplosionAudio;          
    private ParticleSystem m_ExplosionParticles;   
    public float m_CurrentHealth;
    private float m_MaxHealth;
    private bool m_Dead;
    private float damageCooldown = 2.5f;
    private float damageTimer = 0f;

    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        //m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_MaxHealth = m_StartingHealth;
        m_Dead = false;

        

       // SetHealthUI();
    }

    public bool IsDead()
    {
        return m_Dead;
    }

    public void Reset()
    {
        m_CurrentHealth = m_StartingHealth;
        m_MaxHealth = m_StartingHealth;
        m_Dead = false;
        damageTimer = 0f;
    }

    public void Repair(float amount)
    {
        m_CurrentHealth += amount;
        m_CurrentHealth = (m_CurrentHealth > m_MaxHealth) ? m_MaxHealth : m_CurrentHealth;
    }

    public void IncreaseMaxHealth(float amount) 
    {
        m_MaxHealth += amount;
        m_MaxHealth = (m_MaxHealth > 250) ? 250 : m_MaxHealth;
        Repair(amount);
    }


    public void TakeDamage(float amount)
    {
        if (damageTimer >= damageCooldown || gameObject.tag == "Enemy")
        {
            damageTimer = 0f;
            amount = (amount > 20f) ? 20f : amount;
            // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
            m_CurrentHealth -= amount;
            
            if (m_CurrentHealth <= 0f && !m_Dead)
            {
                OnDeath();
            }
        }
    }

    private void Update()
    {
        damageTimer += Time.deltaTime;
    }


    //private void SetHealthUI()
    //{
    //    // Adjust the value and colour of the slider.
    //}


    private void OnDeath()
    {
        // Play the effects for the death of the tank and deactivate it.
        m_Dead = true;

        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);

        m_ExplosionParticles.Play();

        if (gameObject.tag == "Player")
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(false);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}