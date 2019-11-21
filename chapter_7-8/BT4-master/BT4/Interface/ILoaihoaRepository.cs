using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using BT4.Models;

namespace BT4.Interface
{
    public interface ILoaihoaRepository
    {
        ObservableCollection<Loaihoa> GetLoaihoas();
        Loaihoa GetLoaihoaById(int Maloai);
        bool Insert(Loaihoa lh);
        bool Update(Loaihoa lh);
        bool Delete(Loaihoa lh);
    }
}
