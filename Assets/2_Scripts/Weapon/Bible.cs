using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


//https://unity-programmer.tistory.com/3
public class Bible : Weapon
{
    public override void Start()
    {
        base.Start();
        BC.size = new Vector2(0.27f, 0.31f);
    }

    public override void Update()
    {
        if (Mine == null)   // 코루틴 말고 해결책이 있었네? // Mine이 null이면 꺼져.
            return;

        Weapon_Time += Time.deltaTime * Weapon_Speed;
        if (Weapon_Time < 360)
        {
            float x = Weapon_Range * Mathf.Cos(Weapon_Time);
            float y = Weapon_Range * Mathf.Sin(Weapon_Time);
            this.transform.position = Mine.transform.position + new Vector3(x, y, 0);
            // 오류 이유 Mine이 생성되기 전에 불러와서
            // 해결책 내가 아는건 코루틴 
        }
        else
        {
            Weapon_Time = 0;
        }

    }
    
    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }

}

/*
 // 변수들
{
    int count = 5;              // 공회전할 객체 개수
    float distance = 300.0f;    // 중심에서 부터의 거리
    vector<Rect*> others;       // 공회전할 객체
    vector<float> radians;      // 공회전할 객체들의 각도 값
}

// 생성
{
    for (int i = 0; i < count; i++)
    {
        // 객체는 일단 아무렇게나 생성해도 됨
        others.push_back(new Rect({ -5000, -5000,0 }, { 100,100,1 }));

        // 각도들은 360도 / 객체 개수 * 객체 번호 순으로
        radians.push_back((360.0f / count) * i);
    }
}

// 업데이트
{
    for (int i = 0; i < count; i++)
    {
        // 각도 360넘어가는거 방지
        if (radians[i] >= 360.0f) radians[i] = 0.0f;
        radians[i] += 2.0f; // 회전값 // 커지면 빨리 돔

        // 각도 값을 라디안 값으로 변환 (각도값 * 3.14(파이값) / 180 하면 됨)
        float radian = D3DXToRadian(radians[i]);

        // x좌표 = 중심 위치 x 값 + 중심에서의 거리 * cos(라디안값)
        float x = player->GetPosition().x + distance * cos(radian);
        // y좌표 = 중심 위치 y 값 + 중심에서의 거리 * sin(라디안값)
        float y = player->GetPosition().y + distance * sin(radian);

        // 객체 좌표 지정
        others[i]->SetPosition({ x,y,player->GetPosition().z });
    }
}
*/

//time += Time.deltaTime * speed;
//if (time < 360)
//{
//    for (int i = 0; i < level; i++)
//    {
//        float rad = Mathf.Deg2Rad * (time + (i * (360 / level)));
//        float x = range * Mathf.Sin(rad);
//        float y = range * Mathf.Cos(rad);
//        this.transform.localPosition = target.position + new Vector3(x, y);
//        this.transform.rotation = Quaternion.Euler(0, 0, (time + (i * (360 / level))) * -1); //가운데를 바라보게 각도 조절
//    }
//}
//else
//{
//    time = 0;
//}