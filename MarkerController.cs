using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    
    public GameObject Markerprefab;
    public static GameObject OldMarker = null;
    public GameObject Unitprefab;

    private Vector2 screenPosition;
    private Vector2 worldPosition;
    
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(OldMarker);
            OldMarker = Instantiate(Markerprefab, worldPosition, Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(OldMarker);
            OldMarker = null;
        }
        if (Input.GetMouseButtonDown(2))
        {
            Instantiate(Unitprefab, worldPosition, Quaternion.identity);
        }

    }
}
