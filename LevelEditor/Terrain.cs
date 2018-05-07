using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditor
{
    internal class Terrain
    {

        

        public Terrain(ContentManager content, string heightMapPath)
        {

            var texture = content.Load<Texture2D>(heightMapPath);

            float[] height = new float[] 

            texture.GetData();

        }

    }
}
