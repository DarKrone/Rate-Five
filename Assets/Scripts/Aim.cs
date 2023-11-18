using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); // получаем позицию мыши
        mouseWorldPosition.z = 0f;
        Vector2 dir = mouseWorldPosition - head.transform.position; // получаем вектор направления
        head.transform.right = dir;
        if (dir.x < 0) // переворачиваем обьект при повороте 
        {
            head.transform.localScale = new Vector3(head.transform.localScale.x, -1f, head.transform.localScale.z);
        }

        if (dir.x > 0)
        {
            head.transform.localScale = new Vector3(head.transform.localScale.x, 1f, head.transform.localScale.z);
        }
    }
}
