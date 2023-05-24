using UnityEngine;
[CreateAssetMenu(fileName = "Game" +
    "Configuration", menuName = "Create Game Configuration")]
public class GameConfiguration : ScriptableObject
{
    public Vector2 m_StartPos = new Vector2(-1, -0.31f);
    public string m_botPile = "BotPipe";
    public string m_topPile = "TopPipe";
    public string m_ground = "Ground";
    public Vector3 m_moveLeft = new Vector3(0.5f, 0, 0);
    public Vector2 m_velodown = new Vector2(0, -3);
    public Vector2 m_velostop = new Vector2(0, 0);
    public Vector2 m_velodie = new Vector2(0, -20);
    public Vector2 m_velomax = new Vector2(0, 7.2f);
    public Vector3 m_rotate = new Vector3(0, 0, -1);
    public float m_angle = 90;
    public float m_maxRotation = 30; 
    public Vector2 m_translate = new Vector2(0, 1);
    public bool m_isPre = false;
    public int m_count = 1;
    public int m_countMin = 40;
    public int m_countMax = 80;
    public Vector3 m_vectorMove = new Vector3(0, 0.0025f, 0);
    public float m_RotateUp = -4f;
    public float m_RotateDown = 0.8f;
    public float m_timereset = 0.15f;
    public Vector2 m_force = new Vector2(0, 800);
    public bool m_Rotate = false;
    public float time = 0;
    public float m_gravity = 3f;
    public float m_maxRotationZ = 0.25f;
    public Vector3 m_rotation = new Vector3(0, 0, 25);
    public float m_maxvelo = 7.2f;
}
