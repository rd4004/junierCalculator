using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class appliQuestion : MonoBehaviour
{
    public GameObject printQuestText;
    int NumberA ;
    int NumberB ;
    int NumberC ;
    int RdName;
    int twoName;

    string[] names = {

        "小明",
        "小羽",
        "小強",
        "翔翔",
        "小哲",
        "國國",
        "宏明",
        "偉霖",
        "小武",
        "小美",

        "美美",
        "小雯",
        "小菲",
        "薇薇",
        "琳琳",
        "小蘭",
        "千千",
        "夢夢"
    };
    string[] unit = {
        "本",
        "顆",
        "串",
        "籃",
        "束",

        "輛",
        "包",
        "張",
        "疊"
    };
    string[] objects ={
        "書",
        "蘋果",
        "香蕉",
        "草莓",
        "花",

        "車",
        "貓砂",
        "門票",
        "考卷"
    };

    public string getARndNAme()
    {
        return names[Random.Range(0,names.Length-1)];
    }

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int gettwoName(int j)
    {
        int twoNum = Random.Range(0, names.Length - 2);
        int twoName = j + twoNum;
        if (j + twoNum > names.Length)
        {
            twoName = twoName - names.Length;
        };
        return twoName;
    }

    public void QuestA()
    {
        int Qtype = Random.Range(1, 4);//含前面不含後面
        int i = Random.Range(0, unit.Length - 1);//單位＋物品
        RdName = Random.Range(0, names.Length - 1);//名字
        int ans1;
        int ans2;
        switch (Qtype)
        {
            
            case 1:

                //商店裡有27(A)本書，先賣出了12(B)本，又賣了5(C)本，一共賣了幾本書？現在還有幾本書？
                NumberA = Random.Range(11, 99);
                NumberB = Random.Range(1, NumberA);
                NumberC = Random.Range(1, NumberA - NumberB);
                ans1 = NumberB+ NumberC;
                ans2 = NumberA-ans1;
                printQuestText.GetComponent<Text>().text = "商店裡有" + NumberA + unit[i] + objects[i] + "，先賣出了" + NumberB + unit[i] + objects[i] + "，又賣了" + NumberC + unit[i] + objects[i] + "，請問一共賣了幾" + unit[i] + objects[i] + "？現在還有幾" + unit[i] + objects[i] + "？\n" + "答案：(1)"+ ans1 + unit[i]+ "(2)" + ans2+ unit[i]+"。";


                break;
  
            case 2:
                //小芳有13（Ａ）顆星，小蘭給了小芳5（Ｂ）顆後就和小芳一樣多，小蘭有幾顆星？
                NumberB = Random.Range(11, 99);
                NumberA = Random.Range(1, NumberB);
                twoName = gettwoName(RdName);
                
                ans1 = NumberA + NumberB;
                printQuestText.GetComponent<Text>().text = ""+ names[RdName] + "有"+ NumberA + unit[i] + objects[i]+","+names[twoName] + "給了"+ names[RdName] + NumberB + unit[i] + objects[i] + "後就和"+ names[RdName] +"一樣多，" +names[twoName] +"有幾" + unit[i] + objects[i]+"?\n" + "答案：" + ans1 + unit[i]+"。";


                break;

            case 3:
                //外公有19包糖，給了明明和強強各6包後，還有幾包？
                NumberA = Random.Range(11, 99);
                NumberB = Random.Range(1, NumberA/2-1);
                twoName = gettwoName(RdName);
                ans1 = NumberA - (NumberB * 2);
                printQuestText.GetComponent<Text>().text = "外公有" + NumberA + unit[i] + objects[i] + "，給了" + names[RdName] + "和"  + names[twoName] + "各" + NumberB + unit[i] + "後，還有幾" + unit[i] + "?\n" + "答案：" + ans1 + unit[i] + "。";
                break;


            case 4:
               // 藍藍、玲玲、小胖每人做了15朵紅花，他們一共做了幾朵紅花？

                break;

            default:

                break;




        }
       
    }



}
