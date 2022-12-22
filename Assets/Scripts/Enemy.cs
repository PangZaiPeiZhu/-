using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //��������Ԥ����
    public GameObject prefabBoomEffect;

    public float speed = 6;
    public float fireTime = 1f;
    public float maxHp=4;
    float m_time ;

    Vector3 input;

    Transform player;
    float hp;
    bool lifeState = true;

    Weapon weapon;


   
    void Start()
    {
        player = GameObject.Find("Player").transform;
        weapon = gameObject.GetComponent<Weapon>();
        m_time = Time.time;
        hp = maxHp;
        prefabBoomEffect = GameObject.Find("prefabDeath");
    }

  
    void Update()
    {
        

        EnemyMove();
        endFire();
        Debug.Log("���˻�ʣѪ����" + hp);
        if (hp <= 0)
        {
           // Instantiate(prefabBoomEffect, transform.position, transform.rotation);
            Destroy(gameObject);
           
                Debug.Log("��ϲ��Ӯ�ˣ���Ҫ������˵����");
                Debug.Log("��ϲ��Ӯ�ˣ���Ҫ������˵����");
                Debug.Log("��ϲ��Ӯ�ˣ���Ҫ������˵����");
          
           
        }

       
    }

    //���˵��ƶ�����
    void EnemyMove()
    {
        //���˵��ƶ���ʼ�ճ�����ҵģ�����ɵ�����
        input = player.position - transform.position;
        input = input.normalized;

        transform.position += input * speed * Time.deltaTime;
        if (input.magnitude > 0.1f)
        {
            transform.forward = input;
        }
    }

    //���ƹ������
    void endFire()
    {
        if (m_time + fireTime < Time.time)
        {
            Fire();
            m_time = Time.time;
        }

    }

    //���˵Ĺ�������
    void Fire()
    {
        weapon.Fire(true, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            if (hp <= 0) { return; }
            hp--;
            if (hp == 0) { lifeState = false; }
        }
    }
}
