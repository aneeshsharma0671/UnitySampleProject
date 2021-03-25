using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    public Animator head_anim;
    public GameManager GameManager;
    public int initial_shake_time = 2;
    public int shake_interval = 15;

    private void Start()
    {
        StartShake();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousepos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousepos2D, Vector2.zero);
            if(hit.collider !=null)
            {
                Debug.Log(hit.collider.gameObject.name);
                GameManager.GameWon();
                CancelInvoke();
            }

        }
    }

    public void StartShake()
    {
        InvokeRepeating("ShakeHead", initial_shake_time, shake_interval);
    }

    void StopShake()
    {
        CancelInvoke("ShakeHead");
    }


    void ShakeHead()
    {
        head_anim.SetTrigger("Shake");
    }
}
