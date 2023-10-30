using UnityEngine;

public class OscillateColor : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public float duration = 2.0F;
    
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }


    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.color = Color.Lerp(color1, color2, lerp);
    }
}