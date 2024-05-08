using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                moleMove moleMove = hitInfo.collider.GetComponent<moleMove>();
                if (moleMove != null)
                {
                    if (moleMove._hit)
                    {
                        moleMove.OnHit();
                    }
                }
            }
        }
    }
}
