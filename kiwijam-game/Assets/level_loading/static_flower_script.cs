using UnityEngine;

public class static_flower_script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localPosition = new Vector3(Random.Range(-0.3f,0.3f), Random.Range(-0.3f, 0.3f),0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
