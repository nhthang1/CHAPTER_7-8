using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using BT4.Interface;
using BT4.Helpers;
using BT4.Models;

namespace BT4.Repository
{
    public class LoaihoaRepository: ILoaihoaRepository
    {
        Database db;
        public LoaihoaRepository()
        {
            db = new Database();
        }

        public Loaihoa GetLoaihoaById(int Maloai)
        {
            return db.GetLoaihoaById(Maloai);
        }

        public ObservableCollection<Loaihoa> GetLoaihoas()
        {
            return new ObservableCollection<Loaihoa>(db.GetLoaihoas());
        }

        public bool Insert(Loaihoa lh)
        {
            return db.InsertLoaihoa(lh);
        }
        public bool Update(Loaihoa lh)
        {
            return db.UpdateLoaihoa(lh);
        }

        public bool Delete(Loaihoa lh)
        {
            return db.DeleteLoaihoa(lh);
        }
    }
}
