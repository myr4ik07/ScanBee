using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScanBee
{
    public class Status
    {
        public bool MajorStatus;
        public object MinorStatus;
        public string Description;
    }

    public class CommonProcs
    {
        public string GetProperty(string Name)
        {
            object p = "";
            App.Current.Properties.TryGetValue(Name, out p);
            return p.ToString();
        }
        public void DefaultSettingsToPtopertyes()
        {
            foreach (KeyValuePair<string, object> kv in new Parameters())
            {
                object v = "";
                if (!(App.Current.Properties.TryGetValue(kv.Key, out v)))
                {
                    App.Current.Properties.Add(kv.Key, kv.Value);
                }
            }
        }
        
    }

    public class ScanSupport
    {
        public ContentPage refCurrentPageContext;
        public ScanSupport()
        {
            
        }
        public async void BarcodeScanned(string Barcode)
        {
            refCurrentPageContext = (ContentPage)AppGlobals.refCurrentPageContext;
            if (refCurrentPageContext.GetType() == typeof(Page_GoodsList))       //Наборка товаров
            {
                bool catched = false;
                foreach (Good g in ((Page_GoodsList)refCurrentPageContext).lv_Goods)
                {
                    
                    foreach (string BC in g.Barcode)
                    {
                        if (Barcode == BC)
                        {
                            catched = true;
                            break;
                        }
                    }
                    if (catched)
                    {
                        await refCurrentPageContext.Navigation.PushAsync(new Page_EnterValue(g, refCurrentPageContext, null, "EnterAmount"));
                        break;
                    };
                }
                if (!catched)
                {
                    await refCurrentPageContext.DisplayAlert("штрихкод не найден!","","OK");
                }
            }
            if (refCurrentPageContext.GetType() == typeof(Page_GoodRedacting))       //Добавление ШК
            {

                string[] NewString = new string[((Page_GoodRedacting)refCurrentPageContext).GoodItem.Barcode.Length+1];

                int counter = 0;
                foreach (string BC in ((Page_GoodRedacting)refCurrentPageContext).GoodItem.Barcode)
                {
                    NewString[counter] = BC;
                    counter++;
                };
                NewString[NewString.Length - 1] = Barcode;
                ((Page_GoodRedacting)refCurrentPageContext).GoodItem.Barcode = NewString;

                ((Page_GoodRedacting)refCurrentPageContext).os_barcodes.Clear();
                foreach (string BC in ((Page_GoodRedacting)refCurrentPageContext).GoodItem.Barcode)
                {
                    ((Page_GoodRedacting)refCurrentPageContext).os_barcodes.Add(new BarcodeItem { Barcode = BC});
                }
                ((Page_GoodRedacting)refCurrentPageContext).DisplayAlert("Штрихкод добавлен","","OK");
            }

            if (refCurrentPageContext.GetType() == typeof(Page_EnterValue))          //Поиск товара по ШК
            {
                await ((Page_EnterValue)refCurrentPageContext).Navigation.PopAsync();        //ждем, пока в стеке верхняя не будет страница Page_GoodRedacting, потом дергаем сервер
                Exchange EE = new Exchange((Page_GoodRedacting)AppGlobals.refCurrentPageContext);
                await EE.GetGoodByBarcode(Barcode);
            }
        }
    }
}
