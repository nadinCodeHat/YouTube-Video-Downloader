using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;

namespace YouTube_Video_Downloader_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getBtn_Click(object sender, EventArgs e)
        {
            string uri = uriTextBox.Text.ToString();
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(uri);
            
            string title = video.Title; //Get title
            titleTextBox.Text = "";
            titleTextBox.Text = title;
            
            VideoInfo info = video.Info; //(Title, Author, LengthSeconds)
            string fileExtension = video.FileExtension;
            string fullName = video.FullName; // same thing as title + fileExtension
            int resolution = video.Resolution;
        }
    }
}