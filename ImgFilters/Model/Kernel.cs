using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgFilters.Model
{
    
    public class Kernel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private float leftTop;
        public Kernel()
        {

        }
        public float LeftTop
        {
            get { return leftTop; }
            set
            {
                if(value >=0.1)
                leftTop = value;
                OnPropertyChanged("LeftTop");

            }
        }


        private float midTop;

        public float MidTop
        {
            get { return midTop; }
            set
            {
                midTop = value;
                OnPropertyChanged("MidTop");
            }
        }

        private float rightTop;

        public float RightTop
        {
            get { return rightTop; }
            set
            {
                rightTop = value;
                OnPropertyChanged("RightTop");
            }
        }

        private float leftMid;

        public float LeftMid
        {
            get { return leftMid; }
            set
            {
                leftMid = value;
                OnPropertyChanged("LeftMid");
            }
        }

        private float mid;

        public float Mid
        {
            get { return mid; }
            set
            {
                mid = value;
                OnPropertyChanged("Mid");
            }
        }

        private float rightMid;

        public float RightMid
        {
            get { return rightMid; }
            set
            {
                rightMid = value;
                OnPropertyChanged("RightMid");
            }
        }

        private float leftBot;

        public float LeftBot
        {
            get { return leftBot; }
            set
            {
                leftBot = value;
                OnPropertyChanged("LeftBot");
            }
        }

        private float midBot;

        public float MidBot
        {
            get { return midBot; }
            set
            {
                midBot = value;
                OnPropertyChanged("MidBot");
            }
        }

        private float rightBot;

        public float RightBot
        {
            get { return rightBot; }
            set
            {
                rightBot = value;
                OnPropertyChanged("RightBot");
            }
        }

        public float KernelSum
        {
            get { return LeftTop + LeftMid + LeftBot + RightTop + RightMid + RightBot + MidTop + Mid + MidBot; }

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
