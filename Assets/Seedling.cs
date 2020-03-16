namespace Seedling
{
  using UnityEngine;

  [CreateAssetMenu(menuName = "Seedling")]
  public class Seedling : ScriptableObject
  {
    private const float SCALE = 0.9f;

    public float Amplitude = 1;
    public float Frequency = 1;
    public bool Inverted;

    public float Sample(float x, float y) => Sample(new Vector2(x, y));

    public float Sample(float x) => Sample(new Vector2(x, 0));

    public float Sample(Vector2 point)
    {
      point *= SCALE;

      float sample = Mathf.PerlinNoise(point.x * Frequency, point.y * Frequency) * Amplitude;

      if (Inverted)
      {
        sample = 1f - sample;
      }
      
      return Mathf.Clamp01(sample);
    }
  }
}
