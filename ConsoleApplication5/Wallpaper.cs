using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

class Wallpaper
{
    Wallpaper() { }

    static void Main(string[] args)
    {
        Thread t = new Thread(new ThreadStart(newThread));
        t.Start();

        Console.Read();
    }

    private static void newThread()
    {
        String path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "//animate.gif";

        if (!File.Exists(path))
        {
            Console.WriteLine("File does not exist at path " + path);
            Console.Read();
            return;
        }

        Image img = Image.FromFile(path);
        if (img == null)
        {
            Console.WriteLine("Image does not exist.");
            Console.Read();
            return;
        }

        Form f = new Form
        {
            Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height),
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None,
        };

        PictureBox pb = new PictureBox
        {
            Name = "pictureBox",
            Size = f.Size,
            Location = new System.Drawing.Point(0, 0),
            Image = img,
            SizeMode = PictureBoxSizeMode.CenterImage,
            BackColor = Color.Black,
        };

        f.Controls.Add(pb);
        Win32.setOwnership(f);
        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.Run(f);
    }
}
