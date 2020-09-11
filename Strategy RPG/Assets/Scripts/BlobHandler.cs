using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobHandler : MonoBehaviour
{
    public GameObject Blob;
    public GameObject Point;
    private Transform SpawnPoint;
    public int BlobCount;
    public int MaxBlobCount;
    float locationx, locationy;
    Vector2 pos;

    void Start() 
    {
        BlobCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (BlobCount == 0)
        {
            for (int i = 0; i < MaxBlobCount; i++)
            {
                locationx = Random.Range(-5,6);
                locationy = Random.Range(-5,6);
                pos = new Vector2(locationx, locationy);
                Instantiate(Blob, pos, transform.rotation);
                BlobCount++;
            }
        }
    }
}
