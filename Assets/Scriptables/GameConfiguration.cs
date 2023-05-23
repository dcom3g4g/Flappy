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
    public Vector2 m_translate = new Vector2(0, 1);
}
