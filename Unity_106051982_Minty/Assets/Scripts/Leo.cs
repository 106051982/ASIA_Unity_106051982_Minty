using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leo : MonoBehaviour
{
    #region 欄位
    [Header("移動速度")]
    [Range(1, 2500)]
    public int speed = 10;
    [Header("旋轉速度"), Tooltip("leo旋轉速度")]
    [Range(1.5f, 200f)]
    public float turn = 100f;
    [Header("是否完成任務")]
    public bool mission;
    [Header("玩家名稱")]
    public string _name = "leo";
    #endregion

    

  
   
    public Transform tran;
    public Rigidbody rig;
    public Animator ani;
    [Header("catch")]
    public Rigidbody RigCatch;

    private void Update()
    {
        Turn();
        Walk();
        Take();
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.name);
        if (other.name == "sword" && ani.GetCurrentAnimatorStateInfo(0).IsName("take"))
        {
            Physics.lgnoreCollision(other, GetComponent<Collider>());
            other.GetComponet<HingeJoint>().connectedBody = rigCatch;
        }
    }


    #region 移動
    private void Walk()
    {   if (ani.GetCurrentAnimatorStateInfo(0).IsName("take")) return;

        float v = Input.GetAxis("Vertical");
        rig.AddForce(tran.forward * speed * v * Time.deltaTime);
        ani.SetBool("walk",v != 0);
    }

    private void Turn()
    {
        float h = Input.GetAxis("Horizontal");
        tran.Rotate(0, turn * h * Time.deltaTime, 0);
    }

    private void Take()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("take");
        }
    }
    #endregion

}
