using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 touchPos;
    public float moveRate=3f;
    public float limitX;
    private Vector3 touchPosition;
    public float moveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButton(0)){
        //     touchPos=Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //     Vector2 newPos=transform.position;
        //     newPos.x = touchPos.x;
        //     //limitX
        //     newPos.x=Mathf.Clamp(newPos.x,-limitX,limitX);
        //     transform.position =Vector2.Lerp(transform.position,newPos,moveRate);
            
        // }

         if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, touchPosition, moveSpeed * Time.deltaTime);
            }
        }
    }
}
