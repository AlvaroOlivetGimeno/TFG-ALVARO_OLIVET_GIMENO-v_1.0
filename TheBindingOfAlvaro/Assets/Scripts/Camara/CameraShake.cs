using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = this.transform.position;
        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f,1f) * magnitude;
            float y = Random.Range(-1f,1f) * magnitude;

            this.transform.position = new Vector3(this.transform.position.x + x,this.transform.position.y + y,originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        this.transform.position = originalPosition; 
    }
}
