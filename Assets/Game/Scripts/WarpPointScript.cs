using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPointScript : MonoBehaviour
{
    private bool preventRewarp = false;
    public WarpPointScript endWarpPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!preventRewarp) //Dont rewarp if the player just walked through
            {
                if (endWarpPoint != null)
                {
                    endWarpPoint.PreventRewarp();
                }
                collision.gameObject.transform.position = endWarpPoint.transform.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        preventRewarp = false;
    }

    public void PreventRewarp()
    {
        preventRewarp = true;
    }

}
