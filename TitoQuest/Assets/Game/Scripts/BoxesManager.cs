using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesManager : MonoBehaviour
{
    public GameObject box;
    public int cantBoxes;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cantBoxes; i++)
        {
            GameObject auxBox = Instantiate(box, new Vector3(Random.Range(135f, 185f), Random.Range(65f, 100f), 460), Quaternion.identity);
        }
    }
}
