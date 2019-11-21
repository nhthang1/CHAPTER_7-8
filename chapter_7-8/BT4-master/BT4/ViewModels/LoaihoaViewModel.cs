using System;
using System.Collections.Generic;
using System.Text;
using BT4.Models;
using BT4.Repository;
using BT4.Interface;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace BT4.ViewModels
{
    public class LoaihoaViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));

            }
        }

        private Loaihoa lh;
        public ILoaihoaRepository loaihoaRepository;
        public ICommand AddLoaiHoa { get; private set; }
        public ICommand UpdateLoaiHoa { get; private set; }
        public ICommand DeleteLoaiHoa { get; private set; }

        private void Insert()
        {
            loaihoaRepository.Insert(lh);
            LoadLoaihoa();
        }

        private void Update()
        {
            loaihoaRepository.Update(lh);
            LoadLoaihoa();
        }

        private void Delete()
        {
            loaihoaRepository.Delete(lh);
            LoadLoaihoa();
        }

        public Loaihoa Loaihoa
        {
            get { return lh; }
            set
            {
                lh = value;
                RaisePropertyChanged("Loaihoa");
                ((Command)UpdateLoaiHoa).ChangeCanExecute();
            }
        }

        private bool CanExe()
        {
            if (Loaihoa == null || Loaihoa.Maloai == 0) return false;
            return true;
        }

        public int Maloai
        {
            get { return lh.Maloai; }
            set
            {
                lh.Maloai = value;
                RaisePropertyChanged("Maloai");
            }
        }

        public string Tenloai
        {
            get { return lh.Tenloai; }
            set
            {
                lh.Tenloai = value;
                RaisePropertyChanged("Tenloai");
            }
        }

        ObservableCollection<Loaihoa> loaihoaList;

        public ObservableCollection<Loaihoa> LoaihoaList
        {
            get { return loaihoaList; }
            set
            {
                loaihoaList = value;
                RaisePropertyChanged("LoaihoaList");
            }
        }


        void LoadLoaihoa()
        {
            LoaihoaList = loaihoaRepository.GetLoaihoas();
        }

        public LoaihoaViewModel()
        {
            loaihoaRepository = new LoaihoaRepository();
            LoadLoaihoa();
            AddLoaiHoa = new Command(Insert);
            UpdateLoaiHoa = new Command(Update, CanExe);
            DeleteLoaiHoa = new Command(Delete, CanExe);
            lh = new Loaihoa();
        }
    }
}
