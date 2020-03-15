namespace Seedling
{
  using UnityEditor;
  using UnityEngine;

  [CustomEditor(typeof(Seedling))]
  public class SeedlingEditor : Editor
  {
    public override void OnInspectorGUI()
    {
      DrawDefaultInspector();
    }
  }
}
