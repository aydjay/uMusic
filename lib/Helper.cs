using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace uMusic.lib
{
	public static class Helper
	{
	    /// <summary>
	    /// Will return a collection of files of the selected file type
	    /// </summary>
	    /// <param name="fileTypes">In the format "JPG|*.jpg</param>
	    /// <param name="multiselect">If you want it to select multiple files</param>
	    /// <returns>A List of Filenames</returns>
	    public static IEnumerable<string> OpenFiles(string fileTypes, bool multiselect = true)
		{
			using (OpenFileDialog fd = new OpenFileDialog())
			{
				fd.Filter = fileTypes;
				fd.Multiselect = multiselect;
				fd.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();

				if (fd.ShowDialog() == DialogResult.OK)
				{
					return fd.FileNames;
				}

			    return new List<string>();
			}
		}

		/// <summary>
		/// Get a filename and type to save into.
		/// </summary>
		/// <param name="fileTypes">In the format "JPG|*.jpg</param>
		/// <returns>A filename to save into</returns>
		public static string GetSaveName(string fileTypes)
		{
			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = fileTypes;
				sfd.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					return sfd.FileName;
				}

                return null;
			}
		}
		/// <summary>
		/// Creates a video from a picture and an mp3
		/// </summary>
		/// <param name="videoToCreate">File name that the outputted file will have</param>
		/// <param name="imageLoc">Location of the image to use to make the video</param>
		/// <param name="tuneLoc">Location of the song to use to make the video</param>
		public static void CreateVideo(string videoToCreate, string imageLoc, string tuneLoc)
		{
			if (videoToCreate.Equals(""))
			{
				MessageBox.Show("Video file name not selected, unable to continue");
			}
			else
			{
                //Todo refactor to use FFMpeg
				/*using (ITimeline timeline = new DefaultTimeline())
				{
					IGroup group = timeline.AddVideoGroup(32, 640, 480);
					ITrack videoTrack = group.AddTrack();

					IClip clip = videoTrack.AddImage(imageLoc, 0, DetermineSongLength(tuneLoc));

					// add some audio
					ITrack audioTrack = timeline.AddAudioGroup().AddTrack();
					IClip audio = audioTrack.AddAudio(tuneLoc, 0, videoTrack.Duration);

					// create an audio envelope effect, this will:
					// fade the audio from 0% to 100% in 1 second.
					// play at full volume until 1 second before the end of the track
					// fade back out to 0% volume
					audioTrack.AddEffect(0, audio.Duration, StandardEffects.CreateAudioEnvelope(1.0, 1.0, 1.0, audio.Duration));

					// render our slideshow out to a windows media file
					using (WindowsMediaRenderer renderer = new WindowsMediaRenderer(timeline, videoToCreate, WindowsMediaProfiles.HighQualityVideo))
					//using (AviFileRenderer renderer= new AviFileRenderer(timeline,videoToCreate))
					{
						renderer.Render();
					}
				}*/
			}
		}
		/// <summary>
		/// Will create a slideshow video from a collection of images.
		/// </summary>
		/// /// <param name="videoToCreate">File name that the outputted file will have</param>
		/// <param name="picsLoc">Location of the images to used to make the slideshow</param>
		/// <param name="tuneLoc">Location of the song to use to make the video</param>
		internal static void CreateSlideShow(string videoToCreate, List<string> picsLoc, string tuneLoc)
		{
			if (videoToCreate.Equals(""))
			{
				MessageBox.Show("Video file name not selected, unable to continue");
			}
			else
            {
                //todo refactor this to use ffmpeg
            //    using (ITimeline timeline = new DefaultTimeline())
            //    {
            //        IGroup group = timeline.AddVideoGroup(32, 640, 480);
            //        ITrack videoTrack = group.AddTrack();

            //        double numOfPics = (double) picsLoc.Count;
            //        double lenOfTrack = DetermineSongLength(tuneLoc);
            //        double forEachPic = lenOfTrack / numOfPics;
					
            //        double place = 0;
            //        for (int i = 0; i < numOfPics; i++)
            //        {
            //            IClip clip = videoTrack.AddImage(picsLoc[i],0,place, place + forEachPic);
            //            place += forEachPic;
            //        }
            //        // add some audio
            //        ITrack audioTrack = timeline.AddAudioGroup().AddTrack();
            //        IClip audio = audioTrack.AddAudio(tuneLoc, 0, videoTrack.Duration);

            //        // create an audio envelope effect, this will:
            //        // fade the audio from 0% to 100% in 1 second.
            //        // play at full volume until 1 second before the end of the track
            //        // fade back out to 0% volume
            //        audioTrack.AddEffect(0, audio.Duration, StandardEffects.CreateAudioEnvelope(1.0, 1.0, 1.0, audio.Duration));

            //        // render our slideshow out to a windows media file
            //        using (WindowsMediaRenderer renderer = new WindowsMediaRenderer(timeline, videoToCreate, WindowsMediaProfiles.HighQualityVideo))
            //        {
            //            renderer.Render();
            //        }
            //    }
			}
		}
		/// <summary>
		/// Processes the params and attempts to upload selected video to youtube.
		/// </summary>
		/// <param name="userName">YouTube Username</param>
		/// <param name="pwd">YouTube Password</param>
		/// <param name="videoToUpload">Video to upload to YouTube</param>
		/// <param name="title">Title for the video to have on YouTube</param>
		/// <param name="description">Description field for YouTube</param>
		/// <param name="tags">Tags for YouTube, enter them seperated with comma's</param>
		/// <returns></returns>
		public static string YoutubeUploadVideo(string userName, string pwd, string videoToUpload, string title, string description, string tags)
		{
			string error = "";
            //todo refactor this to use the new youtbe upload
            //YouTube tube = new YouTube();
            //MessageBox.Show("Authenticating!", "Upload", MessageBoxButtons.OK);
            //if (tube.Authorize(userName, pwd))
            //{
            //    MessageBox.Show("Attempting Upload!", "Upload", MessageBoxButtons.OK);
            //    tube.Upload(title, "Made using uMusic!" + Environment.NewLine + description, YouTube.Catagory.Music, tags, videoToUpload, out error);
            //    if (MessageBox.Show("Upload Successfully completed." + Environment.NewLine + Environment.NewLine + "Do you want to open \"My Videos\" on YouTube?", "Prompt", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        System.Diagnostics.Process.Start("www.youtube.com/my_videos");
            //    }
            //}
			return error;
		}

		/// <summary>
		/// Find the length of an MP3 song by reading the header tags of the file.
		/// </summary>
		/// <param name="songToCheck">MP3 song which will be assesed for it's length</param>
		/// <returns>The length of time that the song plays for</returns>
		private static double DetermineSongLength(string songToCheck)
		{
			MP3Header mp3 = new MP3Header();
			mp3.ReadMP3Information(songToCheck);
			return double.Parse(mp3.intLength.ToString());
		}

		/// <summary>
		/// Determin wether or not a file is being dropped
		/// </summary>
		/// <param name="e">Pass in the DragEventsArgs to ascertain for a file being dropped</param>
		public static void TestForFileDropped(DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
			{
				e.Effect = DragDropEffects.All;
			}
		}
		/// <summary>
		/// Get the filename from the file that was dropped, works for one file
		/// </summary>
		/// <param name="e">Pass in the DragEventsArgs to ascertain for a file being dropped</param>
		/// <returns></returns>
		public static string GetFilenameFromDroppedFile(DragEventArgs e)
		{
			string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			return FileList[0];
		}
		/// <summary>
		/// Place all of the items in the ListBox into a List<string>
		/// </summary>
		/// <param name="m_Pics"></param>
		/// <param name="lstbPicLoc"></param>
		internal static void ReadItemsIntoList(List<string> m_Pics, ListBox lstbPicLoc)
		{
			foreach (string item in m_Pics)
			{
				lstbPicLoc.Items.Add(item);
			}
		}
	}
}
