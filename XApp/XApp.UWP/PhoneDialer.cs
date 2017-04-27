using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.ApplicationModel.Calls;
using Xamarin.Forms;
using XApp.UWP;

[assembly: Dependency(typeof(PhoneDialer))]
namespace XApp.UWP
{
    public class PhoneDialer : IDialer
    {
        bool dialled = false;

        public bool Dial(string number)
        {
            DialNumber(number);
            return dialled;
        }

        async void DialNumber(string number)
        {
            //var phoneLine = await GetDefaultPhoneLineAsync();
            //if (phoneLine != null)
            //{
            //    phoneLine.Dial(number, number);
            //    dialled = true;
            //}
            //else
            //{
            //    var dialog = new MessageDialog("No line found to place the call");
            //    await dialog.ShowAsync();
            //    dialled = false;
            //}
        }

        //async Task<PhoneLine> GetDefaultPhoneLineAsync()
        //{
        //    var phoneCallStore = await PhoneCallManager.RequestStoreAsync();
        //    var lineId = await phoneCallStore.GetDefaultLineAsync();
        //    return await PhoneLine.FromIdAsync(lineId);
        //}

    }
}
