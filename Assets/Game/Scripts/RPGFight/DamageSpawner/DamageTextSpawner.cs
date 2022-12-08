using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextSpawner : MonoBehaviour
{
    public GameObject damageTextObject;

    public void SpawnDamageText(string damageText)
    {
        GameObject createdObject = Instantiate(damageTextObject);
        createdObject.transform.SetParent(transform);
        createdObject.transform.localPosition = new Vector3(0, 0, 0);
        createdObject.transform.localScale = new Vector3(0, 0, 0);
    }
}
