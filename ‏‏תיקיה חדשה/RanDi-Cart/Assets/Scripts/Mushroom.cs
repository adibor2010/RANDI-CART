using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    bool startBigScaleTimer;
    [SerializeField] float bigScaleTimeRate = 3f;
    float bigScaleTime;
    Vector3 regularScale = new Vector3(1f, 1f, 1f);
    Vector3 bigScale = new Vector3(3f, 3f, 1f);

    private void OnEnable()
    {
        startBigScaleTimer = true;
        bigScaleTime = 0;
        transform.localScale = bigScale;
    }

    private void Update()
    {
        if (startBigScaleTimer == true)
        {
            BigScaleTimer();
        }
    }

    void BigScaleTimer()
    {
        if (bigScaleTime < bigScaleTimeRate)
        {
            bigScaleTime += Time.deltaTime;

            if (bigScaleTime >= bigScaleTimeRate)
            {
                startBigScaleTimer = false;
                bigScaleTime = 0;

                transform.localScale = regularScale;

                this.enabled = false;
            }
        }
    }
}
