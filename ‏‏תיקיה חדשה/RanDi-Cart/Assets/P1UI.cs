using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1UI : MonoBehaviour
{
    [SerializeField] int place;

    [SerializeField] int lapsNumber;

    [SerializeField] int powerUpType;

    [SerializeField] GameObject placeObejct;

    [SerializeField] GameObject lapsNumberObject;

    [SerializeField] GameObject powerUpObject;
    [SerializeField] Sprite[] powerUpImages = new Sprite[6];

    [SerializeField] Color[] powerUpColors = new Color[2];

    PowerUpBoxScript powerUpBoxScript;

    private void Start()
    {
        powerUpBoxScript = FindObjectOfType<PowerUpBoxScript>();
    }

    private void Update()
    {
        if (powerUpBoxScript.GetPlayerHasPowerUp(1) == true)
        {
            SetPowerUpImage();
        }
    }

    void SetPowerUpImage()
    {
        Image powerUpImage = powerUpObject.GetComponent<Image>();

        switch(powerUpBoxScript.GetPowerUpType())
        {
            case "Mushroom":
                powerUpImage.sprite = powerUpImages[0];
                break;
            case "Lightning":
                powerUpImage.sprite = powerUpImages[1];
                break;
            case "Banana":
                powerUpImage.sprite = powerUpImages[2];
                break;
            case "Bomb":
                powerUpImage.sprite = powerUpImages[3];
                break;

        }

        powerUpImage.color = powerUpColors[1];

    }

}
