using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1UI : MonoBehaviour
{
    [SerializeField] int place;

    [SerializeField] int lapsNumber;

    public string powerUpType;

    [SerializeField] GameObject placeObejct;

    [SerializeField] GameObject lapsNumberObject;

    [SerializeField] GameObject powerUpObject;

    PowerUpScript powerUpScript;

    private void Start()
    {
        powerUpScript = FindObjectOfType<PowerUpScript>();
    }

    private void Update()
    {
        powerUpType = powerUpScript.GetPowerUpType();
    }

}
