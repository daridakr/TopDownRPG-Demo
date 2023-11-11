using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyJoystick2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public int distance = 100; //Joystick max range
    public float min = 0.1f; //Minimun range for the joystick to move
    
    public static float JHV2; //Horizontal movement variable
    public static float JVV2; //Vertical movement variable

    [HideInInspector]
    public Vector3 startPos;
    [HideInInspector]
    public Vector3 origin;

    public GameObject mobileJoystick;
    public GameObject circleJoystick;

    void Start()
    {
        startPos = transform.position;
    	origin = transform.position;
    	
    	//If there is not an event system created, we create one
    	EventSystem asy = FindObjectOfType<EventSystem>();

    	if (asy == null)
    	{
    		GameObject es = new GameObject("EventSystem");

    		es.AddComponent<EventSystem>();
    		es.AddComponent<StandaloneInputModule>();
    	}
    }

    //Calculate the values for JHV and JVV
    void CalculateVector(Vector3 pos)
    {
    	if (Vector2.Distance(startPos, pos)/distance > min)
    	{
    		Vector2 v = startPos - pos;
    		JHV2 = -(v.x / distance);
    		JVV2 = -(v.y / distance);
    	}
    	else
    	{
    		JHV2 = 0;
    		JVV2 = 0;
    	}
    }

    
    //Calculate the vector of the new position
    public void OnDrag(PointerEventData data)
    {
    	Vector3 newPos = Vector3.zero;
    	
    	int a = (int)(data.position.x - startPos.x);
    	newPos.x = a;
    	int b = (int)(data.position.y - startPos.y);
    	newPos.y = b;
    	
    	transform.position = Vector3.ClampMagnitude(new Vector3(newPos.x, newPos.y, newPos.z), distance) + startPos;
    	mobileJoystick.transform.position = transform.position;
    	CalculateVector(transform.position);
    }

    //Return joystick to origin
    public void OnPointerUp(PointerEventData data)
    {
    	startPos = origin;
    	circleJoystick.transform.position = origin;
    	transform.position = origin;
    	mobileJoystick.transform.position = origin;
    	CalculateVector(origin);
    }

    //Move joystick to click position
    public void OnPointerDown(PointerEventData data)
    {
    	circleJoystick.transform.position = data.position;
    	startPos = data.position;
    }
}
