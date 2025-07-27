using UnityEngine;

public class cell_detail_loader : MonoBehaviour
{
    public GameObject enemy;



    public GameObject rock;
    public GameObject tree;
    public GameObject bush;

    private GameObject[] objectlist = new GameObject[3];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectlist = new GameObject[] { rock, tree, bush };

        int num_objects = (int)(Random.Range(2, 6));

        for (int i = 0; i < num_objects; i++)
        {
            int choice = (int)Mathf.Floor(Random.Range(0, 3));
            Instantiate(objectlist[choice], transform.position + new Vector3(Random.Range(1, 19), Random.Range(1, 19), 0), transform.rotation);
        }

        for (int i = 0; i < (Random.Range(10, 15)); i++)
        {
            Instantiate(enemy, transform.position + new Vector3(Random.Range(5, 15), Random.Range(5, 15), 0), transform.rotation);
        }



    }
}
