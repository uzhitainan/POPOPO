using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController cc;

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //取的方向輸入
        float h = joystick.Horizontal;
        float v = joystick.Vertical;

        //合成方向向量
        Vector3 dir = new Vector3(h, 0, v);

        //
        if (dir.magnitude > 0.1f)
        {
            //座標差取得角度
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;

            //讓角色旋轉到指定角度
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);
        }

        if (!cc.isGrounded)
        {
            dir.y = -20 * 30 * Time.deltaTime;
        }

        //移動
        cc.Move(dir * Time.deltaTime * 10);
    }
}
