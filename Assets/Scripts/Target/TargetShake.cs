using System.Collections;
using UnityEngine;

public class TargetShake : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float shakeOffset = 0.1f;
    [Tooltip("Shake time value between 0 and 1.")] [Range(0, 1)]
    [SerializeField] private float shakeTime = 0.05f;
    
    public void Shake()
    {
        transform.Translate(Vector3.up * shakeOffset, Space.World);
        StartCoroutine(ShakeTick());
    }

    private IEnumerator ShakeTick()
    {
        yield return new WaitForSeconds(shakeTime);
        transform.Translate(Vector3.down * shakeOffset, Space.World);
    } 
}
