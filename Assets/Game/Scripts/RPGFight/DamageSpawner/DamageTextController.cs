using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathCountdown());
    }

    IEnumerator DeathCountdown()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
