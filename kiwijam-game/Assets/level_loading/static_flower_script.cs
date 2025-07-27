using UnityEngine;

public class static_flower_script : MonoBehaviour
{
    public GameObject flower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Random.Range(0, 3) < 1)
        {

            Vector3 shift = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(1.1f, 1.7f), 0f);
            Instantiate(flower, transform.position + shift, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
