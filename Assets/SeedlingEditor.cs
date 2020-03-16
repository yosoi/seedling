namespace Seedling
{
  using System.Collections.Generic;
  using UnityEditor;
  using UnityEngine;

  [CustomEditor(typeof(Seedling))]
  public class SeedlingEditor : Editor
  {
    private const int PREVIEW_SIZE = 256;

    private Texture2D previewTexture;

    private void Awake()
    {
      previewTexture = new Texture2D(PREVIEW_SIZE, PREVIEW_SIZE);

      UpdatePreviewTexture();
    }

    public override void OnInspectorGUI()
    {
      GUILayout.Label(previewTexture);

      EditorGUI.BeginChangeCheck();

      DrawDefaultInspector();

      if (EditorGUI.EndChangeCheck())
      {
          UpdatePreviewTexture();
      }
    }

    private void UpdatePreviewTexture()
    {
      List<Color> pixels = new List<Color>();

      Seedling seedling = (Seedling)target;

      for (int x = 0; x < PREVIEW_SIZE; x++)
      {
        for (int y = 0; y < PREVIEW_SIZE; y++)
        {
          float pixelValue = seedling.Sample(x, y);

          Color pixelColor = new Color(pixelValue, pixelValue, pixelValue, 1);

          pixels.Add(pixelColor);
        }
      }

      previewTexture.SetPixels(pixels.ToArray());

      previewTexture.Apply();
    }
  }
}
