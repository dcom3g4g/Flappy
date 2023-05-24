using UnityEngine;
[CreateAssetMenu(fileName = "MoveAndScroll" +
    "Configuration", menuName = "Create Scroll And Move Configuration")]
public class MoveAndScrollConfiguration : ScriptableObject
{
    public float m_posReset = 1.42f;
    public Vector2 m_veloMove = new Vector2(-3f, 0);
    public Vector2 m_veloStop = new Vector2(0, 0);
    public bool m_start = false;
    public string m_bird = "Bird";
}
