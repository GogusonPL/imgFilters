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
        public AddValueCommand AddValueCommand { get; set; }
        public SubValueCommand SubValueCommand { get; set; }
        public ResetValueCommand ResetValueCommand { get; set; }

        // Bradley filter params
        private float redParameter;

        public float RedParameter
        {
            get { return redParameter; }
            set {

                if (value >= 0.1f && value <= 1)
                {
                    redParameter = value;
                    OnPropertyChanged("RedParameter");
                }
                else
                {
                    redParameter = RedParameter_Default;
                    OnPropertyChanged("RedParameter");
                }

            }
        }

        public float RedParameter_Default
        {
            get { return 0.3f; }
           
        }
        private float greenParameter;

        public float GreenParameter
        {
            get { return greenParameter; }
            set {
                if (value >= 0.1f && value <= 1)
                {
                    greenParameter = value;
                    OnPropertyChanged("GreenParameter");
                }
                else
                {
                    greenParameter = GreenParameter_Default;
                    OnPropertyChanged("GreenParameter");
                }
            }
        }

        public float GreenParameter_Default
        {
            get { return 0.6f; }

        }
        private float blueParameter;

        public float BlueParameter
        {
            get { return blueParameter; }
            set
            {
                if (value >= 0.1f && value <= 1)
                {
                    greenParameter = value;
                    OnPropertyChanged("BlueParameter");
                }
                else
                {
                    blueParameter = BlueParameter_Default;
                    OnPropertyChanged("BlueParameter");
                }
            }
        }

        public float BlueParameter_Default
        {
            get { return 0.11f; }

        }
        private int precisionParameter;

        public int PrecisionParameter
        {
            get { return precisionParameter; }
            set
            {
                if (value >= 1 && value <= 8)
                {
                    precisionParameter = value;
                    OnPropertyChanged("PrecisionParameter");
                }
                else
                {
                    precisionParameter = PrecisionParameter_Default;
                    OnPropertyChanged("PrecisionParameter");
                }
            }
        }

        public int PrecisionParameter_Default
        {
            get { return 6; }

        }
        private float adjustmentParameter;

        public float AdjustmentParameter
        {
            get { return adjustmentParameter; }
            set
            {
                if (value >= 0.1f && value <= 1)
                {
                    adjustmentParameter = value;
                    OnPropertyChanged("AdjustmentParameter");
                }
                else
                {
                    adjustmentParameter = AdjustmentParameter_Default;
                    OnPropertyChanged("AdjustmentParameter");
                }
            }
        }

        public float AdjustmentParameter_Default
        {
            get { return 0.15f; }

        }

        public ImgFiltersVM()
        {
            InitializeCommands();
            InitializeDefaultParams();

        }

        private void InitializeDefaultParams()
        {
            RedParameter = RedParameter_Default;
            GreenParameter = GreenParameter_Default;
            BlueParameter = BlueParameter_Default;
            PrecisionParameter = PrecisionParameter_Default;
            AdjustmentParameter = AdjustmentParameter_Default;
        }

        private void InitializeCommands()
        {
            AfterPhotoCommand = new AfterPhotoCommand(this);
            BradleyCommand = new BradleyCommand(this);
            GaussCommand = new GaussCommand(this);
            OriginalPhotoCommand = new OriginalPhotoCommand(this);
            SelectPhotoCommand = new SelectPhotoCommand(this);
            AddValueCommand = new AddValueCommand(this);
            SubValueCommand = new SubValueCommand(this);
            ResetValueCommand = new ResetValueCommand(this);

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