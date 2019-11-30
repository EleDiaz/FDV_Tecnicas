using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{

    public float lifeTime;
    void OnEnable()
    {
        StartCoroutine(DisablingIn(lifeTime));
    }

    IEnumerator DisablingIn(float lifeTime) {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
}
