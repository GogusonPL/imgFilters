using ImgFilters.ViewModel.Commands;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace ImgFilters.ViewModel
{
    public class ImgFiltersVM : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BitmapImage uploadedPhoto;

        public BitmapImage UploadedPhoto
        {
            get { return uploadedPhoto; }
            set
            {
                uploadedPhoto = value;
                OnPropertyChanged("UploadedPhoto");
            }
        }

        private BitmapImage currentPhoto;

        public BitmapImage CurrentPhoto
        {
            get { return currentPhoto; }
            set
            {
                currentPhoto = value;
                OnPropertyChanged("CurrentPhoto");
            }
        }

        private byte[] test;

        public byte[] Test
        {
            get { return test; }
            set
            {
                test = value;
                OnPropertyChanged("Test");
            }
        }

        private BitmapImage afterPhoto;

        public BitmapImage AfterPhoto
        {
            get { return afterPhoto; }
            set
            {
                afterPhoto = value;
                OnPropertyChanged("AfterPhoto");
            }
        }

        public AfterPhotoCommand AfterPhotoCommand { get; set; }
        public BradleyCommand BradleyCommand { get; set; }
        public GaussCommand GaussCommand { get; set; }
        public OriginalPhotoCommand OriginalPhotoCommand { get; set; }
        public SelectPhotoCommand SelectPhotoCommand { get; set; }

        // Bradley filter params
        public float redParameter { get; set; }
        public float greenParameter { get; set; }
        public float blueParameter { get; set; }
        public float precisionParameter { get; set; }
        public float adjustmentParameter { get; set; }

        public ImgFiltersVM()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            AfterPhotoCommand = new AfterPhotoCommand(this);
            BradleyCommand = new BradleyCommand(this);
            GaussCommand = new GaussCommand(this);
            OriginalPhotoCommand = new OriginalPhotoCommand(this);
            SelectPhotoCommand = new SelectPhotoCommand(this);
        }

        public void SelectImage()
        {
            OpenFileDialog dialog_window = new OpenFileDialog();
            dialog_window.Filter = "Image files (*.png; *.jpg;)|*.png;*.jpg;*.jpeg|All files(*.*)|*.*"; //TODO: Fix this
            if (dialog_window.ShowDialog() == true)
            {
                string filePath = dialog_window.FileName;
                UploadedPhoto = new BitmapImage(new Uri(filePath));
            }
        }

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}