using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Services
{
    public class DialogService : IDialogService
    {
        public void ShowLoading(string text)
        {
            UserDialogs.Instance.ShowLoading("Loading");
        }

        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }
    }
}
