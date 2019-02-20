using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    Transform[,] m_grid;  //Определение двумерного массива m_grid типа Transform

    public GameObject m_grani;

    public int m_completedRows = 0; //Выполненно блоков для сгорания за раз
    public Transform m_emptySprite; //Определение m_emptySprite типа Transform
    public int m_height = 20;  //Определение высоты клетки
    public static int m_width;  //Определение длины клетки
    public static bool m_game2; //Режим 2
    int g2 = 0;


    void Awake()
	{
        if (m_game2 == true)
        { m_grid = new Transform[12, 20]; } //Присвоение массиву m_grid'у длины и высоты
        else if (m_game2 == false)
        { m_grid = new Transform[10, 20]; } //Присвоение массиву m_grid'у длины и высоты

        if (m_game2 == true)
        {
            m_width = 12;
            g2 = 1;
        }
        else if (m_game2 == false)
        {
            m_width = 10;
        }
    }
	 

	void Start () { 
		DrawEptyCells (); //Приминение отрисовки границы
    }
	

	void Update () {
		
	}


	bool IsWithinBoard(int x, int y) //Булева функция принимает x,y
	{
		return (x >= 0 && x < m_width && y >= 0); //Возвращает правду, если коор-аты не заходят ниже клеточной границы
	}

    bool IsOccupied(int x, int y, Shape shape)
    {
        return (m_grid[x, y] != null && m_grid[x, y].parent != shape.transform); 
    }

	public bool IsValidPosition(Shape shape) 
    {
		foreach (Transform child in shape.transform) { //Принимает коллекцию (массив) 
			Vector2 pos = VectorF.Round (child.position); //Вектор pos принимает округленное значение элемента массива
			if (!IsWithinBoard ((int)pos.x, (int)pos.y)) { //Если коорд заходят ниже границы, то "ложь"
				return false;
			}

            if (IsOccupied((int) pos.x, (int) pos.y, shape))
            {
                return false;
            }

		}
		return true; //Во всех других случаях "тру"
	}

        
    void DrawEptyCells() //Процедура DrawEptyCells для отрисовки поля (клетки)
    {
        if (m_emptySprite != null)
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < m_width; x++)
                {
                    Transform clone;
                    clone = Instantiate(m_emptySprite, new Vector3(x, y, 0), Quaternion.identity) as Transform; //Рисуем сетку из блоков
                                                                                                                //clone.name = "Board Space ( x = " + x.ToString () + " , y =" + " )"; 
                    clone.transform.parent = transform;
                }
            }
        }
    }


    public void StoreShapeInGrid(Shape shape) 
    {
        if (shape == null) 
        {
            return;
        }
            foreach (Transform child in shape.transform)
            {
                Vector2 pos = VectorF.Round(child.position); 
                m_grid[(int) pos.x, (int)pos.y] = child;  
            }
        }


    public bool IsOverLimit(Shape shape)
    {
        foreach (Transform child in shape.transform)
        {
            if (child.transform.position.y >= m_height -2)
            {
                return true;
            }
        }
        return false;
    }

    public void ClearAllRows() //Очистка всех строк
    {
        m_completedRows = 0;
        for (int y = 0; y < m_height; ++y)
        {
            if (IsComplete(y))
            {
                m_completedRows++;
                ClearRow(y);
                ShiftRowsDown(y+1); 

                y--;
            }
        }
    }

    bool IsComplete(int y) //Проверяет, готовы ли блоки для уничтожения
    {

        for (int x = 0; x < m_width; ++x)
        {
            if (m_grid[x, y + g2] == null) 
            {
                return false;
            }

        }
        return true;
    }

    void ClearRow(int y)
    {
        for (int x = 0; x < m_width; ++x)
        {
            if (m_grid[x, y] != null)
            {

                if (m_game2 == true)
                {
                    Destroy(m_grid[x, y].gameObject);
                    Destroy(m_grid[x, y + g2].gameObject);
                }
                else
                {
                    Destroy(m_grid[x, y].gameObject);
                }

            }
            m_grid[x, y] = null;

        }
    }

    void ShiftOneRowDown(int y) //Сдвиг вниз
    {

        for (int x = 0; x < m_width; ++x)
        {
            if (m_grid[x, y] != null)
            {
                m_grid[x, y - 1 - g2] = m_grid[x, y];
                m_grid[x, y] = null;
                m_grid[x, y - 1 - g2].position += new Vector3(0, -1 - g2, 0);
            }
        }
    }



    void ShiftRowsDown(int startY)
    {

        for (int i = startY; i < m_height; ++i)
        {
            ShiftOneRowDown(i+ g2);
        }
    }

    }


