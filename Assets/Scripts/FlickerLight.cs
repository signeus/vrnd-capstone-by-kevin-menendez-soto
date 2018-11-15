using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour {
    Light testLight;

    // Flicking of the Bulb
    public bool flicking = true;
    public float minWaitTime;
    public float maxWaitTime;

    // Intensity of the Bulb
    public bool intensity = true;
    public float maxIntesity;
    public float minIntesity;

    float timeNext;
    float currentTime = 0.0f;

    private float minTime = 2f;
    private float maxTime = 6f;
    bool changeDirection = false;


    void Start()
    {
        testLight = GetComponent<Light>();
        if (flicking)
        {
            StartCoroutine(Flashing());
        }
        NextTime();
    }

    void OnEnable()
    {
        testLight = GetComponent<Light>();
        if (flicking)
        {
            StartCoroutine(Flashing());
        }
        NextTime();
    }

    private void OnDisable()
    {
        if (flicking)
        {
            StopCoroutine(Flashing());
        }
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            testLight.enabled = !testLight.enabled;
        }
    }

    private void Update()
    {
        if (intensity)
        {
            currentTime += Time.deltaTime;
            if (testLight.intensity >= minIntesity && testLight.intensity <= maxIntesity)
            {
                if (changeDirection)
                {
                    testLight.intensity += currentTime * Time.deltaTime;
                }
                else
                {
                    testLight.intensity -= currentTime * Time.deltaTime;
                }
            }

            checkExtremeIntesity();

            if (currentTime >= timeNext)
            {
                NextTime();
            }
        }
    }

    void NextTime()
    {
        timeNext = Random.Range(minTime, maxTime);
        currentTime = 0.0f;
        changeDirection = !changeDirection;
    }

    void checkExtremeIntesity()
    {
        if (testLight.intensity < minIntesity)
        {
            testLight.intensity = minIntesity;
        }
        if (testLight.intensity > maxIntesity)
        {
            testLight.intensity = maxIntesity;
        }
    }
}
