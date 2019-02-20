using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {


    public Transform figura;

    public bool m_canRotate = true; //Можно вращать??
	void Move(Vector3 moveDirection) //Процедура для перемещения префабов
	{
		transform.position += moveDirection; //Принимает значение (куда двигаться)
	}

	public void MoveLeft() //Двигать влево
	{
        transform.position += new Vector3(-1, 0, 0);
    }

	public void MoveRight() //Двигать вправо
	{
        transform.position += new Vector3(1, 0, 0);

    }

	public void MoveDown() //Двигать вниз
	{
        transform.position += new Vector3(0, -1, 0);
    }

	public void MoveUp() //Двигать вверх
	{
        transform.position += new Vector3(0, 1, 0);
    }

	public void RotateRight()  //Вращать направо
	{
		if (m_canRotate) { 
			transform.Rotate (0, 0, -90);
		}
	}

	public void RotateLeft() //Вращать налево
	{
		transform.Rotate (0, 0, 90);
	}

	void Start () {

	}
	
	void Update () {
        

    }

    }
