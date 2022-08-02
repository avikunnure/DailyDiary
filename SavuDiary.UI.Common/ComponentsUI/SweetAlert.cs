using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.UI.Common.ComponentsUI
{
   public interface ISweetAlert
    {
        Task ShowALert(string Title, string Message, AlertType alertType);
        Task<bool> ShowConfirmBox(string Title, string Desciptions);
    }
    public enum AlertType {
        success,
        error,
        info,
    }
    public class SweetAlert:ISweetAlert
    {
       
        private IJSRuntime _jsRuntime { get; set; }
        public SweetAlert(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ShowALert(string Title, string Message, AlertType alertType)
        {
             await _jsRuntime.InvokeVoidAsync("ShowAlert",new object[]{ Title, Message,alertType.ToString()});
        }
        public async Task<bool> ShowConfirmBox(string Title,string Desciptions)
        {
            var result = await _jsRuntime.InvokeAsync<bool>("ShowConfirm", new object[] { Title, Desciptions });
            return result;
        }

    }
}
