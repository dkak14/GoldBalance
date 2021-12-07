using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float speed;
    [SerializeField] float boundX;
    [SerializeField] float startX;
    float temp;
    
    Vector2 previousPos;
    Camera mainCamera;
    void Start()
    {
        BackGround bg;
        if (!spriteRenderer.TryGetComponent(out bg)) {
            boundX = spriteRenderer.bounds.size.x;
            startX = transform.position.x;
            GameObject back1 = Instantiate(spriteRenderer.gameObject, transform.position + Vector3.right * boundX, Quaternion.identity);
            GameObject back2 = Instantiate(spriteRenderer.gameObject, transform.position - Vector3.right * boundX, Quaternion.identity);
            back1.transform.parent = transform;
            back2.transform.parent = transform;
            mainCamera = Camera.main;
        }
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
