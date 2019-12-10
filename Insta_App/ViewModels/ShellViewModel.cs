using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Threading;
using Caliburn.Micro;
using Insta_App.Views;
using Timer = System.Timers.Timer;

namespace Insta_App.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string[] _pageArray = new string[3] { "Instagram", "Telephone", "Calendar" };
        private int _counter = 0;
        Timer _progressTimer = new Timer();
        private string _searchBox;

        private int _progressBar = 0;

        public int ProgressBar
        {
            get { return _progressBar; }
            set
            {
                _progressBar = value;
                NotifyOfPropertyChange(() => ProgressBar);
            }
        }

        public int Counter
        {
            get { return _counter; }
            set
            {
                _counter = value;
            }
        }

        public string[] PageArray
        {
            get { return _pageArray; }
            set { _pageArray = value; }
        }

        public ApplicationPage CurrentPage { get; set; }

        public ShellViewModel()
        {
            LoadPages();

            _progressTimer.Interval = 10;
            _progressTimer.Elapsed += _progressTimer_Elapsed;
            StartTimer();
        }

        private void _progressTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ++_progressBar;
            if (_progressBar >= 700)
            {
                _counter++;
                if (_counter == (_pageArray.Length))
                    _counter = 0;
                LoadPages();
            }

            NotifyOfPropertyChange(() => ProgressBar);
        }

        public void StopTimer()
        {
            _progressTimer.Stop();
        }

        public void StartTimer()
        {
            _progressTimer.Start();
        }

        private void LoadPages()
        {
            StopTimer();
            
            try
            {
                if (_pageArray[_counter] == "Instagram")
                {
                    CurrentPage = ApplicationPage.Instagram;
                }
                else if (_pageArray[_counter] == "Telephone")
                {
                    CurrentPage = ApplicationPage.Telephone;
                }
                else if (_pageArray[_counter] == "Calendar")
                {
                    CurrentPage = ApplicationPage.Calendar;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Что-то пошло не так..." + e.Message, "", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }

            NotifyOfPropertyChange(() => CurrentPage);
            _progressBar = 0;
            StartTimer();
        }

        public void GoBack()
        {
            if (_counter > 0)
            {
                _counter--;
            }
            else
            {
                _counter = 0;
            }
            LoadPages();
        }

        public void GoForward()
        {
            if (_counter < (_pageArray.Length - 1))
            {
                _counter++;
                LoadPages();
            }
            else if (_counter == (_pageArray.Length - 1))
            {
                _counter = 0;
                LoadPages();
            }
        }

        public void GoToInstagramPage()
        {
            _counter = Array.IndexOf(_pageArray, "Instagram");
            LoadPages();
        }

        public void GoToTelephonePage()
        {
            _counter = Array.IndexOf(_pageArray, "Telephone");
            LoadPages();
        }

        public void GoToCalendarPage()
        {
            _counter = Array.IndexOf(_pageArray, "Calendar");
            LoadPages();
        }
    }
}
