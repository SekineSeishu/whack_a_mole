using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moleMove : MonoBehaviour
{
    public bool _hit;
    [SerializeField]private float nowTime;
    private float coolTime;
    private float speed = 1f;
    [SerializeField] private Vector3 topPosition;
    [SerializeField] private bool work;
    [SerializeField]private Vector3 bottomPosition;

    // Start is called before the first frame update
    void Start()
    {
        _hit = false;
        work = false;
        SetCoolTime();
        bottomPosition = gameObject.transform.position;
        topPosition = transform.position + new Vector3(0,1,0);
    }

    // Update is called once per frame
    void Update()
    {
        nowTime -= Time.deltaTime;
        if (nowTime <= 0.0f)
        {
            work = true;
            _hit = true;
        }

        if (_hit)
        {
            if (gameObject.transform.position.y <= topPosition.y)
            {
                if (work)
                {
                    MoveUpDown();
                }
            }
            else
            {
                work = false;
            }
        }
        if (!_hit)
        {
            if (gameObject.transform.position.y > bottomPosition.y)
            {
                if (work)
                {
                    MoveUpDown();
                }
            }
            else
            {
                work = false;
            }
        }
    }

    void MoveUpDown()
    {
        float step = speed * Time.deltaTime;
        if (_hit)
        {
            transform.position = Vector3.MoveTowards(transform.position, topPosition, step);
        }
        else if (!_hit)
        {
            transform.position = Vector3.MoveTowards(transform.position, bottomPosition, step);
        }
    }
    void SetCoolTime()
    {
        Debug.Log("Start!");
        coolTime = Random.Range(3f, 8f);
        nowTime = coolTime;
    }
    public void OnHit()
    {
        Debug.Log("a");
        work = true;
        SetCoolTime();
        _hit = false;
    }
}
