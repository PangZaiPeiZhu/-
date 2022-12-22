using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�ƶ��ٶ�
    public float c_speed;

    //���Ѫ��
    public float m_maxHp ;

    //���뷽�����
    Vector3  c_input;

    //�ж��Ƿ�����
    bool LifeState=true;

    //��ǰѪ��
    private float c_Hp;

    Weapon weapon;

    //����
    private Rigidbody playerRigidbody;
    public float force=15;
    
    void Start()
    {
        //��ȡ�������
        playerRigidbody = GetComponent<Rigidbody>();
        //�տ�ʼ��Ѫ
        c_Hp = m_maxHp;
        //�����������������ýű�
        weapon = GetComponent<Weapon>();
    }



   
    void Update()
    {
        //������Ծ
        if (transform.position.y <= 1.89)
        {
            if (Input.GetKeyDown(KeyCode.Space))

            {
                Debug.Log("�ո������");
                playerRigidbody.AddForce(0, force, 0);
            }
        }
        
        //�����̵ĺ����������룬������input��
        c_input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        bool fireKeyDown = Input.GetKeyDown(KeyCode.J);
        bool fireKeyPressed = Input.GetMouseButton(0);
        bool changeWeapon = Input.GetKeyDown(KeyCode.Q);


        //�ж��Ƿ�dead�������žͿ��Զ�

        Debug.Log("���ڻ�ʣѪ����" + c_Hp);
        if (LifeState==true )
        {

            //rotate();
            Move();
            weapon.Fire(fireKeyDown, fireKeyPressed);
            if (changeWeapon)
            {
                weapon.Change();
            }
            

        }
        else { Time.timeScale = 0; }

        void Move()
        {
            
            //�ȹ�һ������������������ֱ�ӣ�����ͬʱб���ƶ�ʱ�ٶȳ������ֵ
            c_input =c_input.normalized;
            transform.position += c_input * c_speed * Time.deltaTime;
            //���ɫǰ�����ƶ�����һ��
            if (c_input.magnitude > 0.1f)
            {
                transform.forward = c_input;
            }
            
            




            //�����ƶ���Χ
            Vector3 c_VectorTemp=transform.position ;
            const float m_border = 20f;
            if(c_VectorTemp.x < -m_border)
            {
                c_VectorTemp.x = -m_border;

            }
            if (c_VectorTemp.x > m_border)
            {
                c_VectorTemp.x = m_border;

            }
            if (c_VectorTemp.z < -m_border)
            {
                c_VectorTemp.z = -m_border;

            }
            if (c_VectorTemp.z > m_border)
            {
                c_VectorTemp.z = m_border;

            }

            transform.position = c_VectorTemp;




        }
        /*void rotate()
        {
            float mouse_x = Input.GetAxis("Mouse X");
            float mouse_y = Input.GetAxis("Mouse Y");
            Quaternion qx = Quaternion.Euler(0, mouse_x, 0);
            Quaternion qy = Quaternion.Euler(-mouse_y, 0, 0);

            //��ס��ǰ�˻�˳��
            transform.rotation = qx*transform.rotation ;//������y������ת

            transform.rotation = transform.rotation*qy;//����������x��ת
        
        }*/



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            if (c_Hp <= 0) { return; }
            c_Hp-=1;
            if (c_Hp == 0) { LifeState = false; }
        }
    }
}
