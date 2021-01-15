using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Services
{
    public interface IDialogService
    {
        void ShowLoading(string text);
        void HideLoading();
    }
}
