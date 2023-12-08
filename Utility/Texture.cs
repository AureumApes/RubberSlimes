using System.Reflection;
using UnityEngine;

namespace RubberSlimeRemaster.Utility
{
    public static class Texture
    {
        public static Texture2D LoadTextureFromAssembly(string filename)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var manifestResourceStream =
                executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + "." + filename + ".png");
            var numArray = new byte[manifestResourceStream.Length];
            manifestResourceStream.Read(numArray, 0, numArray.Length);
            var tex = new Texture2D(1, 1);
            tex.LoadImage(numArray);
            tex.filterMode = FilterMode.Bilinear;
            return tex;
        }

        public static Sprite ConvertToSprite(this Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f),
                1f);
        }
    }
}