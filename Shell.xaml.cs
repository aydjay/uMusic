using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using uMusic.Annotations;
using uMusic.lib;

namespace uMusic
{
    /// <summary>
    ///     Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window, INotifyPropertyChanged
    {
        private string _tune;
        private IEnumerable<string> _pics;
        private ImageSource _previewImage;

        public ImageSource PreviewImage
        {
            get { return _previewImage; }
            set
            {
                _previewImage = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<string> Pics
        {
            get
            {
                return _pics;
            }
            set
            {
                if(Equals(value, _pics))
                {
                    return;
                }
                _pics = value;
                ShowFirstImageAsPreview();
                OnPropertyChanged();
            }
        }

        private void ShowFirstImageAsPreview()
        {
            if (Pics.Any())
            {
                var yourImage = new BitmapImage(new Uri(Pics.First(), UriKind.Absolute));
                yourImage.Freeze(); // -> to prevent error: "Must create DependencySource on same Thread as the DependencyObject"
                PreviewImage = yourImage;
            }
            else
            {
                PreviewImage = null;
            }
        }


        /// <summary>
        ///     MP3 that will be added to the video
        /// </summary>
        public string Tune
        {
            get
            {
                return _tune;
            }
            set
            {
                if(value == _tune)
                {
                    return;
                }
                _tune = value;
                OnPropertyChanged();
            }
        }

        private void BtnTuneBrowse_Click(object sender, EventArgs e)
        {
            var files = Helper.OpenFiles("MP3 Files|*.mp3", false);

            if(files.Any())
            {
                Tune = files.First();
            }
        }

        private void BtnPicBrowse_OnClick(object sender, RoutedEventArgs e)
        {
            var files = Helper.OpenFiles("JPG Files|*.jpg");

            if(files.Any())
            {
                Pics = files;
            }
        }

        ///// <summary>
        ///// Handler for the Clear Click, will clear out the listbox and the member variable
        ///// </summary>
        ///// <param name="sender">Object Sender</param>
        ///// <param name="e">Event Arguments</param>
        //private void btnClear_Click(object sender, EventArgs e)
        //{
        //    if (bgwRenderer.IsBusy)
        //    {
        //        bgwRenderer.CancelAsync();
        //    }
        //    helper.ClearPicFilesPaths(lstbPicLoc, pics);
        //}

        ///// <summary>
        ///// Handler for the Preview click
        ///// </summary>
        ///// <param name="sender">Object Sender</param>
        ///// <param name="e">Envent Arguments</param>
        //public void btnPreview_Click(object sender, EventArgs e)
        //{
        //    btnPreview.Enabled = false;
        //    btnPreview.Text = "Wait...";
        //    if (bgwRenderer.IsBusy)
        //    {
        //        bgwRenderer.CancelAsync();
        //        if (bgwRenderer.CancellationPending)
        //        {
        //            System.Threading.Thread.Sleep(1000);
        //            bgwRenderer.RunWorkerAsync();
        //        }
        //        else
        //        {
        //            bgwRenderer.RunWorkerAsync();
        //        }
        //    }
        //    else
        //    {
        //        bgwRenderer.RunWorkerAsync();
        //    }
        //}

        //private void btnCreateVid_Click(object sender, EventArgs e)
        //{
        //    if (lstbPicLoc.Items.Count == 0 | txtbTuneLoc.Equals(String.Empty))
        //    {
        //        MessageBox.Show("You must choose and Picture and a Song", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    else
        //    {
        //        if (lstbPicLoc.Items.Count == 1)
        //        {
        //            helper.PrepareGUI4Encoding(btnCreateVid, ref encodeSaveName);
        //            bgwEncoder.RunWorkerAsync();
        //        }
        //        else
        //        {
        //            helper.PrepareGUI4Encoding(btnCreateVid, ref encodeSaveName);
        //            bgwSlideShowEncoder.RunWorkerAsync();
        //        }
        //    }
        //}

        //Todo: 
        //private void btnUpload_Click(object sender, EventArgs e)
        //{
        //    cmbUploadChoice.Show(Cursor.Position);
        //}

        //Todo: put this into the help/about maybe
        //private void lnklDonate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    Process.Start(
        //        "https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=deathman102%40gmail%2ecom&lc=GB&item_name=uMusic&currency_code=GBP&bn=PP%2dDonationsBF%3abtn_donate_SM%2egif%3aNonHosted");
        //}

        #region Context Menu Entries
        //private void youTubeToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var up = new Upload();
        //    if(up.ShowDialog() == DialogResult.OK)
        //    {
        //    }
        //}

        //private void rapidshareToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var rapidForm = new RapidShare_Upload();
        //    if(rapidForm.ShowDialog() == DialogResult.OK)
        //    {
        //    }
        //}
        #endregion

        #region Threading
        //private void bgwEncoder_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    helper.CreateVideo(encodeSaveName, pics[0].ToString(), tube);
        //}

        //private void bgwEncoder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    btnCreateVid.Text = "Create Video";
        //    btnCreateVid.Enabled = true;
        //    MessageBox.Show("Finished encoding!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        //private void bgwSlideShowEncoder_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    helper.CreateSlideShow(encodeSaveName, pics, txtbTuneLoc.Text);
        //}

        //private void bgwSlideShowEncoder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    btnCreateVid.Text = "Create Video";
        //    btnCreateVid.Enabled = true;
        //    MessageBox.Show("Finished encoding!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        //private void bgwRenderer_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    helper.RenderListOfImages(picbPreview, pics);
        //}

        //private void bgwRenderer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    btnPreview.Text = "Preview";
        //    btnPreview.Enabled = true;
        //    helper.RenderImage(picbPreview, lstbPicLoc.Items[0].ToString());
        //}
        #endregion

        //#region DragDrops
        //private void txtbTuneLoc_DragEnter(object sender, DragEventArgs e)
        //{
        //    helper.TestForFileDropped(e);
        //}

        //private void txtbTuneLoc_DragDrop(object sender, DragEventArgs e)
        //{
        //    tube = "";
        //    tube = helper.GetFilenameFromDroppedFile(e);
        //    txtbTuneLoc.Text = tube;
        //}

        //private void lstbPicLoc_DragEnter(object sender, DragEventArgs e)
        //{
        //    helper.TestForFileDropped(e);
        //}
        //#endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void MiAboutClick_OnClick(object sender, RoutedEventArgs e)
        {
            //Todo: Create a nice about message
            MessageBox.Show("This is the about message");
        }
    }
}