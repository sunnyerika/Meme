using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStatic : MonoBehaviour
{
    [SerializeField]
    private float _timeToDestroy = 2f;
    private bool _isCollided = false;
    private void Update()
    {
        if (_isCollided && _timeToDestroy>=0f) {
            _timeToDestroy -= Time.deltaTime;
        }
        if (_timeToDestroy<=0f) {
            SetStatic();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            
            if (collision.collider.gameObject.tag.Equals("Bottom") || collision.collider.gameObject.tag.Equals("Dead"))
            {
                _isCollided = true;

               
            }


        }

        
    }
    private void SetStatic() {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        _timeToDestroy = 2f;
    }
}
