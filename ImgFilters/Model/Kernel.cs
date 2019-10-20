﻿using System;
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
                if (value >= 0 && value <= 1)
                    leftTop = value;
                else
                    leftTop = 0;
                OnPropertyChanged("LeftTop");

            }
        }


        private float midTop;

        public float MidTop
        {
            get { return midTop; }
            set
            {
                if (value >= 0 && value <= 1)
                    midTop = value;
                else
                    midTop = 0.2f;
                OnPropertyChanged("MidTop");
            }
        }

        private float rightTop;

        public float RightTop
        {
            get { return rightTop; }
            set
            {
                if (value >= 0 && value <= 1)
                    rightTop = value;
                else
                    rightTop = 0;
                OnPropertyChanged("RightTop");
            }
        }

        private float leftMid;

        public float LeftMid
        {
            get { return leftMid; }
            set
            {
                if (value >= 0 && value <= 1)
                    leftMid = value;
                else
                    leftMid = 0.2f;
                OnPropertyChanged("LeftMid");
            }
        }

        private float mid;

        public float Mid
        {
            get { return mid; }
            set
            {
                if (value >= 0 && value <= 1)
                    mid = value;
                else
                    mid = 0.2f;
                OnPropertyChanged("Mid");
            }
        }

        private float rightMid;

        public float RightMid
        {
            get { return rightMid; }
            set
            {
                if (value >= 0 && value <= 1)
                    rightMid = value;
                else
                    rightMid = 0.2f;
                OnPropertyChanged("RightMid");
            }
        }

        private float leftBot;

        public float LeftBot
        {
            get { return leftBot; }
            set
            {
                if (value >= 0 && value <= 1)
                    leftBot = value;
                else
                    leftBot = 0;
                OnPropertyChanged("LeftBot");
            }
        }

        private float midBot;

        public float MidBot
        {
            get { return midBot; }
            set
            {
                if (value >= 0 && value <= 1)
                    midBot = value;
                else
                    midBot = 0.2f;
                OnPropertyChanged("MidBot");
            }
        }

        private float rightBot;

        public float RightBot
        {
            get { return rightBot; }
            set
            {
                if (value >= 0 && value <= 1)
                    rightBot = value;
                else
                    rightBot = 0;
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
