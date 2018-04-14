using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FOOTBALL
{
    public class MemoryGraph
    {
        public Bitmap Image;
        public Graphics Graphics;

        public MemoryGraph(int width, int height)
        {
            Create(width, height);
        }

        public void Create(int width, int height)
        {
            if (this.Image != null)
            {
                this.Image.Dispose();
                this.Image = null;
            }

            if (this.Graphics != null)
            {
                this.Graphics.Dispose();
                this.Graphics = null;
            }

            this.Image = new Bitmap(width >= 10 ? width : 10, height >= 10 ? height : 10);
            this.Graphics = Graphics.FromImage(this.Image);
        }
    }
}
