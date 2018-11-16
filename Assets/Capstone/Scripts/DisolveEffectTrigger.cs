using UnityEngine;

public class DisolveEffectTrigger : MonoBehaviour {
    public Material disolveMaterial;
    public float speed, max, min;
    private bool started = false;

    private float currentY, startTime;

    private void Start()
    {
        currentY = 2;
        if(min == 0)
        {
            min = -25;
        }
        disolveMaterial.SetFloat("_DisolveY", currentY);
    }

    private void Update()
    {
        // If this is during the animation
        if(currentY < max && started && currentY > min)
        {
            disolveMaterial.SetFloat("_DisolveY", currentY);
            currentY -= Time.deltaTime * speed;
        }
    }

    public void TriggerEffect()
    {
        started = true;
        startTime = Time.deltaTime;
        currentY = 2;
        disolveMaterial.SetFloat("_DisolveY", currentY);
    }
}
