using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using УчетСИЗ.Models;

namespace УчетСИЗ.Interfaces
{
    public interface IThisUserLogin
    {
        void GetThisUser(string login, string password, Window window);

        void ClearDat(ThisUser user);
    }
}
