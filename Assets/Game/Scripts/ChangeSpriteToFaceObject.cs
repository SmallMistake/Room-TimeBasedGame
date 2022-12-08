using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteToFaceObject : AIAction
{
    public Transform target;
    public Sprite leftFacingSprite;
    public Sprite rightFacingSprite;

    public SpriteRenderer spriteRenderer;

    public override void PerformAction()
    {
        float transformXChange = transform.position.x - target.transform.position.x;
        if (transformXChange >= 0)
        {
            spriteRenderer.sprite = leftFacingSprite;
        }
        else
        {
            spriteRenderer.sprite = rightFacingSprite;
        }
    }
}
