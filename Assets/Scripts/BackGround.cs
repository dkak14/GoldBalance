using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> backGround;
    [SerializeField] float speed;
    [SerializeField] float boundX;
    [SerializeField] float startX;
    float temp;
    
    Vector2 previousPos;
    Camera mainCamera;
    void Start()
    {
        startX = transform.position.x;
        boundX = backGround[0].bounds.size.x;
        backGround[1].transform.position = backGround[0].transform.position + Vector3.right * boundX;
        backGround[2].transform.position = backGround[0].transform.position - Vector3.right * boundX;
        mainCamera = Camera.main;
    }
    void Update()
    {       
        transform.position += Vector3.right * (mainCamera.transform.position.x - previousPos.x) * speed;
        temp = mainCamera.transform.position.x - transform.position.x;

        if(Mathf.Abs(temp) > boundX) {
            if(temp > 0) {
                transform.position += Vector3.right * boundX;
            }
            else {
                transform.position -= Vector3.right * boundX;
            }
        }
        previousPos = mainCamera.transform.position;
    }
}
