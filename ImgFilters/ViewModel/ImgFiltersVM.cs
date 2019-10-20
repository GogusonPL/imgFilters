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



        #region Properties
        private Visibility bradley;

        public Visibility Bradley
        {
            get { return bradley; }
            set
            {
                bradley = value;
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

        public BitmapSource GaussBuff { get; set; }
        private Kernel kernel;

        public Kernel Kernel
        {
            get { return kernel; }
            set
            {
                kernel = value;
                OnPropertyChanged("Kernel");
            }
        }

        private BradleyParams bradleyParams;

        public BradleyParams BradleyParams
        {
            get { return bradleyParams; }
            set
            {

                bradleyParams = value;
                OnPropertyChanged("BradleyParams");

            }
        }

        #endregion


        #region Commands  
        public AfterPhotoCommand AfterPhotoCommand { get; set; }
        public BradleyCommand BradleyCommand { get; set; }
        public GaussCommand GaussCommand { get; set; }
        public OriginalPhotoCommand OriginalPhotoCommand { get; set; }
        public SelectPhotoCommand SelectPhotoCommand { get; set; }
        public AddValueCommand AddValueCommand { get; set; }
        public SubValueCommand SubValueCommand { get; set; }
        public ResetValueCommand ResetValueCommand { get; set; }
        public ApplyBradleyCommand ApplyBradleyCommand { get; set; }
        public TestCommand TestCommand { get; set; } // delete
        public LoadKernelCommand LoadKernelCommand { get; set; }
        public SaveKernelCommand SaveKernelCommand { get; set; }
        public RepeatGaussCommand RepeatGaussCommand { get; set; }
        public ApplyGaussCommand ApplyGaussCommand { get; set; }
        public SaveBradleyParamsCommand SaveBradleyParamsCommand { get; set; }
        public LoadBradleyParamsCommand LoadBradleyParamsCommand { get; set; }
        #endregion

        #region Constructor and inits
        public ImgFiltersVM()
        {
            InitializeCommands();
            InitializeDefaultParams();

        }

        private void InitializeDefaultParams()
        {

            BradleyParams = new BradleyParams();
            Bradley = Visibility.Hidden;
            Gauss = Visibility.Visible;
            Kernel = new Model.Kernel()
            { LeftBot = 0, LeftMid = 0.2f, LeftTop = 0, Mid = 0.2f, MidBot = 0.2f, MidTop = 0.2f, RightBot = 0, RightMid = 0.2f, RightTop = 0 };
            BradleyParams.RedParameter = BradleyParams.RedParameter_Default;
            BradleyParams.GreenParameter = BradleyParams.GreenParameter_Default;
            BradleyParams.BlueParameter = BradleyParams.BlueParameter_Default;
            BradleyParams.PrecisionParameter = BradleyParams.PrecisionParameter_Default;
            BradleyParams.AdjustmentParameter = BradleyParams.AdjustmentParameter_Default;

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
            LoadKernelCommand = new LoadKernelCommand(this);
            SaveKernelCommand = new SaveKernelCommand(this);
            RepeatGaussCommand = new RepeatGaussCommand(this);
            ApplyGaussCommand = new ApplyGaussCommand(this);
            SaveBradleyParamsCommand = new SaveBradleyParamsCommand(this);
            LoadBradleyParamsCommand = new LoadBradleyParamsCommand(this);

        }
        #endregion
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