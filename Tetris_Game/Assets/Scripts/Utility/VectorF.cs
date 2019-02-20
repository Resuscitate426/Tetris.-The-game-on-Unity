using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorF {

	public static Vector2 Round(Vector2 v) //Статическая функция Round 
    {
		return new Vector2 (Mathf.Round (v.x), Mathf.Round (v.y)); //Возвращает округленные координаты вектора 2

	}
	public static Vector2 Round(Vector3 v)
	{
		return new Vector3 (Mathf.Round (v.x), Mathf.Round (v.y), Mathf.Round (v.z)); //Возвращает округленные координаты вектора 3
    }
}
