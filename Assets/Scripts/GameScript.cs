using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject collidersParent;

    public GameObject collidersParent2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FindAnimal();
    }

    private void FindAnimal()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
            else
            {
                Debug.Log("nope");
            }
        }
    }
}
