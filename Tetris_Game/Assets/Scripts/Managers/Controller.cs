using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	Board m_gameBoard; 
	Spawner m_spawner;
	Shape m_activeShape;
    ScoreScript m_score;


	float m_dropInterval = 0.35f;
	float m_timeToDrop;
	float m_timeToNextKeyLeftRight;
	[Range(0.02f,1f)]
	public float m_keyRepeatRateLeftRight = 0.25f;
	float m_timeToNextKeyDown;
	[Range(0.01f,0.5f)]
	public float m_keyRepeatRateDown = 0.01f;
	float m_timeToNextKeyRotate;
	[Range(0.02f,1f)]
	public float m_keyRepeatRateRotate = 0.25f;
	public GameObject m_gameOverPanel;
	bool m_gameOver = false;

    public static bool m_isPaused = false;
    public GameObject m_pausePanel;




    void Start () 
	{

        m_gameBoard = GameObject.FindWithTag("Board").GetComponent<Board>();
        m_spawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
        m_score = GameObject.FindObjectOfType<ScoreScript>();
 

        if (m_spawner)
		{
			m_spawner.transform.position = VectorF.Round(m_spawner.transform.position);

			if (!m_activeShape)
			{
				m_activeShape = m_spawner.SpawnShape();
			}
		}

		if (m_gameOverPanel)
		{
			m_gameOverPanel.SetActive(false);
		}

        if (m_pausePanel)
        {
            m_pausePanel.SetActive(false);
        }


	}


	void Update () 
	{

		if (!m_spawner || !m_gameBoard || !m_activeShape || m_gameOver || !m_spawner)
		{
			return;
		}
        CheckInput();
	}

	void CheckInput ()
	{

		if (Input.GetKeyDown(KeyCode.RightArrow)) 
		{
			m_activeShape.MoveRight ();
			m_timeToNextKeyLeftRight = Time.time + m_keyRepeatRateLeftRight;


            if (!m_gameBoard.IsValidPosition (m_activeShape)) 
			{
                m_activeShape.MoveLeft ();
            }

		}
		else if  (Input.GetKeyDown(KeyCode.LeftArrow)) 
		{
			m_activeShape.MoveLeft ();
			m_timeToNextKeyLeftRight = Time.time + m_keyRepeatRateLeftRight;

			if (!m_gameBoard.IsValidPosition (m_activeShape)) 
			{
				m_activeShape.MoveRight ();
			}

		}
		else if  (Input.GetKeyDown(KeyCode.X)) 
		{
			m_activeShape.RotateRight();
			m_timeToNextKeyRotate = Time.time + m_keyRepeatRateRotate;

			if (!m_gameBoard.IsValidPosition (m_activeShape)) 
			{
				m_activeShape.RotateLeft();
			}

		}

        else if (Input.GetKeyDown(KeyCode.Z))
        {
            m_activeShape.RotateLeft();
            m_timeToNextKeyRotate = Time.time + m_keyRepeatRateRotate;

            if (!m_gameBoard.IsValidPosition(m_activeShape))
            {
                m_activeShape.RotateLeft();
            }

        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_activeShape.RotateLeft();
            m_timeToNextKeyRotate = Time.time + m_keyRepeatRateRotate;

            if (!m_gameBoard.IsValidPosition(m_activeShape))
            {
                m_activeShape.RotateLeft();
            }

        }

        else if  (Input.GetKey(KeyCode.DownArrow) && (Time.time > m_timeToNextKeyDown) ||  (Time.time > m_timeToDrop)) 
        {
        	m_timeToDrop = Time.time + m_dropInterval;
        	m_timeToNextKeyDown = Time.time + m_keyRepeatRateDown;

        	m_activeShape.MoveDown ();

        	if (!m_gameBoard.IsValidPosition (m_activeShape)) //Если заходит за рамки
        	{
        		if (m_gameBoard.IsOverLimit(m_activeShape)) 
                {
                    GameOver();

                }
                else
        		{
        			LandShape ();
        		}
        	}

        }

    }


    void LandShape () //Нижняя грань
	{

		m_activeShape.MoveUp ();
		m_gameBoard.StoreShapeInGrid (m_activeShape);


		m_activeShape = m_spawner.SpawnShape ();


		m_timeToNextKeyLeftRight = Time.time;
		m_timeToNextKeyDown = Time.time;
		m_timeToNextKeyRotate = Time.time;


		m_gameBoard.ClearAllRows();

        if (m_gameBoard.m_completedRows > 0)
        {
            m_score.ScoreLines(m_gameBoard.m_completedRows);
        }

	}


	void GameOver ()
	{

		m_activeShape.MoveUp ();


		if (m_gameOverPanel) {
            m_gameOverPanel.SetActive (true);
        }


		m_gameOver = true;
	}


    public void TogglePause()  //Пауза
    {
        if(m_gameOver)
        {
            return;
        }
        m_isPaused = !m_isPaused;
        if(m_pausePanel)
        {
            m_pausePanel.SetActive(m_isPaused);
            Time.timeScale = (m_isPaused) ? 0 : 1;
        }
    }
}
