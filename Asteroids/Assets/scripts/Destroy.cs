using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
    //destroys bullet after 2sec (stops lag hopefully)
    void Start()
    {
        StartCoroutine(DestroyAfterDelay(2f));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
