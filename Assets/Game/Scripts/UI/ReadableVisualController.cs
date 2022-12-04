using System.Collections;
using UnityEngine;

public class ReadableVisualController : MonoBehaviour
{
    GameObject currentReadingObject;
    private bool interactable;

    public void showReadable(GameObject objectToRead)
    {
        Time.timeScale = 0;
        interactable = false;
        StartCoroutine(delayInteractable());
        currentReadingObject = Instantiate(objectToRead);
        currentReadingObject.transform.SetParent(gameObject.transform, false);
    }

    private void Update()
    {
        if(currentReadingObject != null && interactable)
        {
            if (Input.GetButtonDown("A"))
            {
                Destroy(currentReadingObject);
                Time.timeScale = 1;
            }
        }
    }

    IEnumerator delayInteractable()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        interactable = true;
    }
}
