using UnityEngine;

public class tree_rotation_control : MonoBehaviour
{

    public GameObject tree_up;
    public GameObject tree_down;
    public GameObject tree_left;
    public GameObject tree_right;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] all_orientations = new GameObject[] { tree_up, tree_left, tree_down, tree_right };
        int orientation = (int)Mathf.Floor(Random.Range(0, 4));
        Instantiate(all_orientations[orientation], transform.position, Quaternion.Euler(0f, 0f, (float)(90*orientation)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
