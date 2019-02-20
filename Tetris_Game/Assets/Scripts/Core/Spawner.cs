using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Shape[] m_allShapes; // Открытый массив m_allShapes типа shape (в лаунчере юнити в него вставлены префабы)


    Shape GetRandomShape() //Создание блоков с определенной вероятностью
	{
        int b = Random.Range((int)0, (int)100);

        if (Board.m_game2 == true)
        {
            if (b >= 0 && b < 10)
                return m_allShapes[0];

            else if (b >= 10 && b < 25)
                return m_allShapes[1];

            else if (b >= 25 && b < 40)
                return m_allShapes[2];

            else if (b >= 40 && b < 55)
                return m_allShapes[3];

            else if (b >= 55 && b < 70)
                return m_allShapes[4];

            else if (b >= 70 && b < 80)
                return m_allShapes[5];

            else if (b >= 80 && b < 85)
                return m_allShapes[6];

            else if (b >= 85 && b < 90)
                return m_allShapes[7];

            else if (b >= 90 && b < 95)
                return m_allShapes[8];

            else if (b >= 95 && b <= 100)
                return m_allShapes[9];

            else return null;
        }


        else 
        {
            if (b >= 0 && b < 10)
                return m_allShapes[0];

            else if (b >= 10 && b < 25)
                return m_allShapes[1];

            else if (b >= 25 && b < 40)
                return m_allShapes[2];

            else if (b >= 40 && b < 55)
                return m_allShapes[3];

            else if (b >= 55 && b < 70)
                return m_allShapes[4];

            else if (b >= 70 && b < 80)
                return m_allShapes[5];

            else if (b >= 80 && b <= 100)
                return m_allShapes[6];
            else return null;
        }
        }

        public Shape SpawnShape() //Функция Создания блоков на опр координате 
	{
		Shape shape = null; //Несуществует
		shape = Instantiate (GetRandomShape (), transform.position, Quaternion.identity) as Shape; //Создание блока путем прим функц GetRandomShape(),с коор-ми уств юнити и неизмененным rotate
        if (shape) { //Создание на выбранной точке коор-нат префаба
			return shape;
		} else {
			return null;
		}
	}


	void Start () {
		Vector2 originalVector = new  Vector2 (4.3f, 1.3f); //Вектор2 originalVector с коор-ами 4.3f, 1.3f
        Vector2 newVector = VectorF.Round(originalVector); //Вектор2 newVector возвр округл коорд originalVector

    }
	

	void Update () {
		
	}
}
