using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float startMovementSpeed = 5f;
    private float startRotateTurret = 2f;
    private float startRotateChassis = 2f;
    private float startReloadSpeed = 5f;

    public float movementSpeed;
    public float rotateTurret;
    public float rotateChassis;
    public float reloadSpeed;

    private float maxMovementSpeed = 10f;
    private float maxRotateTurret = 4f;
    private float maxRotateChassis = 4f;
    private float minReloadSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        movementSpeed = startMovementSpeed;
        rotateTurret = startRotateTurret;
        rotateChassis = startRotateChassis;
        reloadSpeed = startReloadSpeed;
    }

    public void ModifyStats(string upgradeType)
    {

        if (upgradeType == "Move Speed") ModifyMovementSpeed();
        if (upgradeType == "Turret Rotate Speed") ModifyTurretRotate();
        if (upgradeType == "Reload Speed") ModifyReloadSpeed();
        if (upgradeType == "Chassis Rotate Speed") ModifyChassisRotate();
        if (upgradeType == "Repair Kit") gameObject.GetComponent<TankHealth>().Repair(25f);
        if (upgradeType == "Max HP") gameObject.GetComponent<TankHealth>().IncreaseMaxHealth(25f);
    }

    private void ModifyMovementSpeed()
    {
        movementSpeed += startMovementSpeed * (maxMovementSpeed - startMovementSpeed) / 20;
        if (movementSpeed >= maxMovementSpeed)
        {
            movementSpeed = maxMovementSpeed;
            gameObject.GetComponent<TankHealth>().Repair(25f);
        }
    }
    private void ModifyChassisRotate()
    {
        rotateChassis += startRotateChassis * (maxRotateChassis - startRotateChassis) / 20;
        if (rotateChassis >= maxRotateChassis)
        {
            rotateChassis = maxRotateChassis;
            gameObject.GetComponent<TankHealth>().Repair(25f);
        }
    }

    private void ModifyTurretRotate()
    {
        rotateTurret += startRotateTurret * (maxRotateTurret - startRotateTurret) / 20;
        if (rotateTurret >= maxRotateTurret)
        {
            rotateTurret = maxRotateTurret;
            gameObject.GetComponent<TankHealth>().Repair(25f);
        }
    }

    private void ModifyReloadSpeed()
    {
        reloadSpeed += startReloadSpeed * (minReloadSpeed - startReloadSpeed) / 20f;
        if (reloadSpeed <= minReloadSpeed)
        {
            reloadSpeed = minReloadSpeed;
            gameObject.GetComponent<TankHealth>().Repair(25f);
        }
    }
}
