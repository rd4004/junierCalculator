using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    int NumberA;//數值A
    int NumberB;//數值B
    int postive = 1;
    bool plus;//+ 或 - 1~5 是減 6~10是+
    string type;
    public GameObject printText;
    public GameObject Text10_Mother;
    public GameObject pos;
    private int BigCount = 10;
    private GameObject[] cloneText;
    

    int countNum;//計數器

    // Start is called before the first frame update
    void Start()
    {
           cloneText = new GameObject[BigCount];
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CalculateCenter()
    {
        //1.數值(Ａ)2.決定type3.數值(B)
        NumberA = Random.Range(11,99);

        int i = Random.Range(0, 10);
        if (i > 5)
        {
            plus = true;//+
            type = " + ";
            postive = 1;
        }
        else {
            plus = false;//-
            type = " - ";
            postive = -1;
        }

        if (plus)
        {//加
            int j = Random.Range(1,8);//1-8
            if (NumberA >= 90)//Ａ是9x
            {
                NumberA = (NumberA - 90)+(j*10);//Ａ-90加上隨機十位數
            }

            
            if (NumberA % 10 <=1 )//不能是1 , 0
            {
                int m = Random.Range(2, 9);//各位數2-9
                NumberA = NumberA - (NumberA % 10) + m;//如果A個位數是1就重新random加上去
            }

            int n = Random.Range(11 - (NumberA % 10),9);//ran一個個位數 2搭配9以上 3搭配8以上(11-2=9,11-9=2
            int b = Random.Range(0,9-((NumberA- (NumberA%10))/10));//ran一個十位數0~9-A的十位數
            NumberB = b*10 + n;
            Debug.Log("n:"+n+",b:"+b+ "NumberA各位：" + NumberA % 10);


            //int m = Random.Range(1, 99 - NumberA);

            //if (((m-(m%10))/10)+((NumberA-(NumberA%10))/10)==10)//十位數相加=10
            //{
            //    int n = Random.Range(-1, 9-((NumberA - (NumberA % 10)) / 10));
            //    m = n + m%10 ;
            //}

            //if ((NumberA % 10) + (m % 10) > 10)//個位數相加
            //{
            //    NumberB = m;
            //}
            //else
            //{
            //    int k = Random.Range((NumberA % 10)+1, 9);
            //    NumberB = m - (m % 10) + k;

            //}
            //if (NumberA+NumberB >=100 & NumberB>=10)//Ａ是8x
            //{
            //    NumberB = NumberB - 10;
            //}
        }
        else
        {//減
            if (NumberA % 10 == 9) {//如果A的個位數＝9強制-1
                NumberA = NumberA - 1;
            }
            
            int j = Random.Range(11, NumberA-1);

            if (NumberA - (NumberA % 10) == j - (j % 10))
            {

                j=j - 10;
            }
            
                int k = Random.Range(NumberA % 10 + 1, 9);
                NumberB = j - (j % 10) + k;

        }


    }

    public void TextPrint()
    {
        //Debug.Log(""+ NumberA +type + NumberB);
        CalculateCenter();
        printText.GetComponent<Text>().text = "" + NumberA + type + NumberB +" = "+(NumberA + (postive*NumberB));
    }

    public void TextPrint10()
    {
        clear();
        
        for (int i = 1; i <= BigCount; i++)
        {
            countNum++;
            cloneText[i - 1] = Instantiate(Text10_Mother, pos.transform);
            CalculateCenter();
            cloneText[i - 1].GetComponent<Text>().text = "" + NumberA +"\t"+ type +" \t " +NumberB + "\t=\t" + (NumberA + (postive * NumberB));
        }
       
    }
    private void clear()
    {
        for (int i = 1; i <= BigCount; i++)
        {
            GameObject.Destroy(cloneText[i - 1]);
        }

    }
}
