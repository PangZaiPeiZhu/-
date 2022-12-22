using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float c_bulletSpeed = 10f;
    //�����ӵ�����������
    public float lifeTime = 2;
    //�ӵ����ɵ�ʱ��
    float startTime;
   
    void Start()
    {
        startTime = Time.time;
    }

   
    void Update()
    {
        //�ӵ��ƶ�
        transform.position+= c_bulletSpeed * transform.forward * Time.deltaTime;
        //�Ի�װ��
        if (startTime + lifeTime < Time.time)
            Destroy(gameObject);
    }

    //�е��¼�
    private void OnTriggerEnter(Collider other)
    {
        //ͬ���ӵ���ײ������
        if (CompareTag(other.tag))
            return;

        Destroy(gameObject);
    }
}
