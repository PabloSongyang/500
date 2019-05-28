using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking_list : MonoBehaviour {

    [SerializeField]
    Image panel,image;
    [SerializeField]
    Sprite champion, runner_up, bronze,fourth,fifth, champion_image, runner_up_iamge, bronze_image;

    [SerializeField]
    Color champion_color, runner_up_color, bronze_color, fourth_color,fifth_color,other_color;


    public void getranking(string value)
    {

        switch (value)
        {
            case "1":
                panel.sprite = champion;
                image.sprite = champion_image;
                panel.color = new Color(1, 1, 1, 1);
                image.color = new Color(1, 1, 1, 1);
                setcolor(champion_color);
                break;
            case "2":
                panel.sprite = runner_up;
                image.sprite = runner_up_iamge;
                panel.color = new Color(1, 1, 1, 1);
                image.color = new Color(1, 1, 1, 1);
                setcolor(runner_up_color);
                break;
            case "3":
                panel.sprite = bronze;
                image.sprite = bronze_image;
                panel.color = new Color(1, 1, 1, 1);
                image.color = new Color(1, 1, 1, 1);
                setcolor(bronze_color);
                break;
            case "4":
                panel.sprite = fourth;
                panel.color = new Color(1, 1, 1, 1);
                image.color = new Color(1, 1, 1, 0);
                setcolor(fourth_color);
                break;

            case "5":
                panel.sprite = fifth;
                panel.color = new Color(1, 1, 1, 1);
                image.color = new Color(1, 1, 1, 0);
                setcolor(fifth_color);
                break;
            default:
                panel.color = new Color(1, 1, 1, 0);
                image.color = new Color(1, 1, 1, 0);
                setcolor(other_color);
                break;

        }
    }

    void setcolor(Color color)
    {
        selectallFuntion(transform.parent.parent,color);
    }


    public static void selectallFuntion(Transform obj,Color color)
    {
        foreach (Transform i in obj)
        {
            if (i.GetComponent<Text>())
                i.GetComponent<Text>().color = color;
            if (i.transform.childCount > 0)
                selectChild(i.transform,color);
        }
    }

    public static void selectChild(Transform obj, Color color)
    {
        foreach (Transform i in obj)
        {
            if (i.GetComponent<Text>())
                i.GetComponent<Text>().color = color;
            selectChild(i,color);
        }

    }
}
