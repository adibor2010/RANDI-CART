using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePowerUp : MonoBehaviour
{
    CarMovement carMovementScript;
    PowerUpBoxScript powerUpBoxScript;

    [SerializeField] GameObject playerUI;

    [SerializeField] string powerUpKey;

    Mushroom mushroomScript;

    private void Start()
    {
        carMovementScript = GetComponent<CarMovement>();
        powerUpBoxScript = FindObjectOfType<PowerUpBoxScript>();
        mushroomScript = GetComponent<Mushroom>();
    }

    private void Update()
    {
        if (Input.GetKeyDown($"{powerUpKey}") &&
            powerUpBoxScript.GetPlayerHasPowerUp(carMovementScript.GetPlayerNumber()) == true)
        {
            powerUpBoxScript.SetPlayerHasPowerUp(false, carMovementScript.GetPlayerNumber());

            if (powerUpBoxScript.GetPowerUpType() == "Mushroom")
            {
                mushroomScript.enabled = true;
            }
        }
    }
}
