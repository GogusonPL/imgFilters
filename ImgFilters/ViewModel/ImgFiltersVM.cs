using ImgFilters.Model;
using ImgFilters.ViewModel.Commands;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ImgFilters.ViewModel
{
    public class ImgFiltersVM : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;




        private Visibility bradley;

        public Visibility Bradley
        {
            get { return bradley; }
            set { bradley = value;
                OnPropertyChanged("Bradley");
            }
        }

        private Visibility gauss;

        public Visibility Gauss
        {
            get { return gauss; }
            set
            {
                gauss = value;
                OnPropertyChanged("Gauss");
            }
        }


        private BitmapImage originalPhoto;

        public BitmapImage OriginalPhoto
        {
            get { return originalPhoto; }
            set
            {
                originalPhoto = value;
                OnPropertyChanged("OriginalPhoto");
            }
        }

        private byte[] currentPhoto;

        public byte[] CurrentPhoto
        {
            get { return currentPhoto; }
            set
            {
                currentPhoto = value;
                OnPropertyChanged("CurrentPhoto");
            }
        }


        private byte[] afterPhoto;

        public byte[] AfterPhoto
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
        public ApplyBradleyCommand ApplyBradleyCommand { get; set; }
        public TestCommand TestCommand { get; set; }

        // Bradley filter params
        private float redParameter;

        public float RedParameter
        {
            get { return redParameter; }
            set {

                if (value >= 0.1 && value <= 1)
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
                if (value >= 0.1 && value <= 1)
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
                if (value >= 0.1 && value <= 1)
                {
                    blueParameter = value;
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
                if (value >= 0.1 && value <= 1)
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

        public Kernel Kernel { get; set; }

        public ImgFiltersVM()
        {
            InitializeCommands();
            InitializeDefaultParams();
            Bradley = Visibility.Hidden;
            Gauss = Visibility.Visible;
            Kernel = new Model.Kernel()
            { LeftBot = 0.5f, LeftMid = 0.5f, LeftTop = 0.5f, Mid = 0.5f, MidBot = 0.5f, MidTop = 0.5f, RightBot = 0.5f, RightMid = 0.5f, RightTop = 0.5f };

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
            ApplyBradleyCommand = new ApplyBradleyCommand(this);
            TestCommand = new TestCommand(this);

        }

        public void SelectImage()
        {
            OpenFileDialog dialog_window = new OpenFileDialog();
            dialog_window.Filter = "Image files (*.png; *.jpg;)|*.png;*.jpg;*.jpeg|All files(*.*)|*.*"; //TODO: Fix this
            if (dialog_window.ShowDialog() == true)
            {
                string filePath = dialog_window.FileName;
                OriginalPhoto = new BitmapImage(new Uri(filePath));
                var temp = new BitmapImage(new Uri(filePath));
                CurrentPhoto = ImgManager.BitmapSourceToByteArray(temp);
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