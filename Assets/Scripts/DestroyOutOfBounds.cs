using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20f;
    private GridManager gridManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gridManagerScript = GameObject.Find("GridManager").GetComponent<GridManager>();
        UpdateTopBound();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTopBound();
        if (transform.position.y > topBound)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateTopBound()
    {
        topBound = gridManagerScript.NextSpawnYPos + 40;
    }
}
