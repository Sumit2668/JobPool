using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.NativeInterface
{
    public interface IIosMethods
    {
        void ShowToast(string msg);
        string GetIdentifier();
        void ShowLoader();
        void DismissLoader();
		ResponseModel RetriveLocalData();
		void SaveLocalData(ResponseModel um);
        void DeleteLocalData();
    }
}
