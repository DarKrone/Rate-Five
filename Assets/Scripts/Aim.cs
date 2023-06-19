using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject aimPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        Vector2 dir = mouseWorldPosition - transform.position;
        transform.right = dir;
        if (dir.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, -1f, transform.localScale.z);
        }

        if (dir.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
        }
    }
}
