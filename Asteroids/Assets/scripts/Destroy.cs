using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
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
