using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSwitchScript : MonoBehaviour, I_Interactable
{
    public bool on = true;

    public List<Light2D> lightsToEffect;

    public Sprite onSprite;
    public Sprite offSprite;
    private SpriteRenderer renderer;

    private float offIntensity = 0f;
    private float onIntensity = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void InteractedWith(PlayerInventory playerInventory)
    {
        on = !on;
        SetVisual();
    }

    private void SetVisual()
    {
        if (on)
        {
            renderer.sprite = onSprite;
            foreach(Light2D light in lightsToEffect)
            {
                light.intensity = onIntensity;
            }
        }
        else
        {
            renderer.sprite = offSprite;
            foreach (Light2D light in lightsToEffect)
            {
                light.intensity = offIntensity;
            }
        }
    }
}
