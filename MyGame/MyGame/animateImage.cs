using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    public class AnimateImage : Form
    {

        //Create a Bitmpap Object.
        Bitmap animatedImage; /*= new Bitmap("SampleAnimation.gif");*/
        private string ImageName;
        bool CurrentlyAnimating { get; set; } = false;

        public AnimateImage(string imageName)
        {
            ImgFromFile(imageName);
        }


        //This method begins the animation.
        public void AniImage()
        {
            if (!CurrentlyAnimating)
            {
                //Begin the animation only once.
                ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
                CurrentlyAnimating = true;
            }
        }

        private void OnFrameChanged(object o, EventArgs e)
        {

            //Force a call to the Paint event handler.
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            //Begin the animation.
            AniImage();

            //Get the next frame ready for rendering.
            ImageAnimator.UpdateFrames();

            //Draw the next frame in the animation.
            e.Graphics.DrawImage(this.animatedImage, new Point(0, 0));
        }

        public void ImgFromFile(string imageName)
        {
            try
            {
                animatedImage = new Bitmap($"..\\..\\{imageName}.gif");
                ImageName = imageName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
