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
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            About abtFrm = new About();
            abtFrm.ShowDialog();
        }

        private void pasteBtn_Click(object sender, EventArgs e)
        {

        }

        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(urlTextBox.Text))
            {
                // Do Nothing
            }
            else
            {
                var youTube = YouTube.Default;
                try
                {
                    var video = youTube.GetVideo(urlTextBox.Text.ToString());
                    string title = video.Title; //Get title
                    ytitle.Text = "";
                    ytitle.Text = title;

                    VideoInfo info = video.Info; //(Title, Author, LengthSeconds)
                    string fileExtension = video.FileExtension;
                    string fullName = video.FullName; // same thing as title + fileExtension
                    int resolution = video.Resolution;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Invalid URI");
                }
            }
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
        }
    }
}