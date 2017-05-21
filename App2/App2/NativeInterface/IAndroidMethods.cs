using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.NativeInterface
{
    public interface IAndroidMethods
    {
        void ShowToast(string msg);
        void ShowSnakBar(string msg);
        string GetIdentifier();
		ResponseModel RetriveLocalData();
		void SaveLocalData(ResponseModel um);
        void DeleteLocalData();
        void ShowLoader();
        void DismissLoader();
    }
}
