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
using YoutubeExtractor;

namespace YouTube_Video_Downloader_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IEnumerable<VideoInfo> videoInfos;

        private void getBtn_Click(object sender, EventArgs e)
        {
            string link = url.Text;
            videoInfos = DownloadUrlResolver.GetDownloadUrls(link);


            VideoInfo video = videoInfos
                .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 360);

            /*
             * If the video has a decrypted signature, decipher it
             */
            if (video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(video);
            }

            /*
             * Create the video downloader.
             * The first argument is the video to download.
             * The second argument is the path to save the video file.
             */
            var videoDownloader = new VideoDownloader(video, Path.Combine("C:\\", video.Title + video.VideoExtension));
            videoDownloader.DownloadFinished += videodownload_DownloadFinised;
 
            videoDownloader.Execute();
        }

        void videodownload_DownloadFinised(object s, EventArgs e)
        {
            MessageBox.Show("Download has been finised");
        }
    }
}