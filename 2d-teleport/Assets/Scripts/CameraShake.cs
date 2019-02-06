using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//From YouTube tutorial: https://youtu.be/9A9yj8KnM8c
public class CameraShake : MonoBehaviour
{
    public float magnitude = 0.0f;

    public IEnumerator Shake (float duration, float magnitude)
    {
        if (Mathf.Abs(this.magnitude) < 0.001f)
        {
            this.magnitude = magnitude;
        }
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
        this.magnitude = 0.0f;
    }
}
