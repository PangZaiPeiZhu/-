using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //�ӵ���Ԥ����
    public GameObject prefabBullet;

    //����������CD����
    public float pistolFireCD = 0.2f;
    public float shotgunFireCD = 0.5f;
    public float rifleFireCD = 0.1f;

    //�ϴο���ʱ��
    float lastFireTime;

    //��ǰ������
    public int curGun    //  0:��ǹ��1������ǹ��2���Զ���ǹ
    {
        get;
        private set;
    }

    //���ÿ�����
    //keyDownָ�����䣬keyPressedָ������
    public void Fire(bool keyDown,bool keyPressed)
    {
        switch (curGun)
        {
            case 0:
            if (keyDown)
                {
                    PistolFire();
                }
                break;
            case 1:
                if (keyDown)
                {
                    ShotgunFire();
                }
                break;
            case 2:
                if(keyPressed)
                {
                    RifleFire();
                }
                break;

        }

    }

    //��������
    public int Change()
    {
        if (curGun != 3)
        {
            curGun++;
        }
        else
        {
            curGun = 0;
        }
        return curGun;
    }

    //��ǹ���ר�ú���
    public void PistolFire()
    {
        if (lastFireTime + pistolFireCD > Time.time)
            return;
        lastFireTime = Time.time;

        GameObject bullet = Instantiate(prefabBullet, null);
        bullet.transform.position = transform.position + transform.forward * 1f;
        bullet.transform.forward = transform.forward;
    }
    //�������ר�ú���
    public void ShotgunFire()
    {
        if (lastFireTime + shotgunFireCD > Time.time)
            return;
        lastFireTime = Time.time;

       //����5���ӵ����໥����10�ȣ��ֲ���ǰ����������
       for(int i = -2; i <= 2; i++)
        {
            GameObject bullet = Instantiate(prefabBullet, null);
            Vector3 dir = Quaternion.Euler(0, i * 10, 0) * transform.forward;

            bullet.transform.position = transform.position + dir * 1f;
            bullet.transform.forward = dir;

            //����ǹ���ӵ��������̣ܶ�����޸��ӵ�����������
            Bullet b = bullet.GetComponent<Bullet>();
            b.lifeTime = 0.3f;
        }
    }
    //�Զ���ǹ���ר�ú���
    public void RifleFire()
    {
        if (lastFireTime + rifleFireCD > Time.time)
            return;
        lastFireTime = Time.time;

        GameObject bullet = Instantiate(prefabBullet, null);
        bullet.transform.position = transform.position + transform.forward * 1.2f;
        bullet.transform.forward = transform.forward;
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
