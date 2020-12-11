using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    //public int m_PlayerNumber = 1;       
    public Rigidbody m_Shell;            
    public Transform m_FireTransform;    
    //public Slider m_AimSlider;           
    //public AudioSource m_ShootingAudio;  
    //public AudioClip m_ChargingClip;     
    //public AudioClip m_FireClip;         
    public float m_LaunchForce = 15f;
    //public float m_MaxLaunchForce = 30f; 
    //public float m_MaxChargeTime = 0.75f;
    Enemy_Tank_Tracking trackingInfo;
    
    //private string m_FireButton;         
    //private float m_CurrentLaunchForce;  
    //private float m_ChargeSpeed;         
    private bool m_Fired;
    private float timer = 0.0f;
    public float Fire_Interval = 5.0f;
    private bool aggro;

    private void OnEnable()
    {
        //m_CurrentLaunchForce = m_MinLaunchForce;
        //m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start()
    {
        // m_FireButton = "Fire" + m_PlayerNumber;

        //m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
        trackingInfo = gameObject.GetComponent<Enemy_Tank_Tracking>();
    }


    private void Update()
    {
        // Track the current state of the aggro timer and decide if should fire
        aggro = trackingInfo.IsAggro();

        if (aggro)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
        }

        if (timer > Fire_Interval && !m_Fired)
        {
            Fire();
        }
        else if (timer > Fire_Interval && m_Fired)
        {
            m_Fired = false;
            timer = 0.0f;
        }

    }


	private void Fire()
    {
        // Instantiate and launch the shell.
        m_Fired = true;

        // Create instance of shell and store reference to its rigidBody
        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Set the shells velocity to the launch force in the fires position forward direction
        shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;
    }
}