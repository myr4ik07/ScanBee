using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanBee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Settings : ContentPage
    {
        Parameters Parameters = new Parameters();
        MainPage MPContext;
        public Page_Settings(MainPage MP)
        {
            
            InitializeComponent();
            this.BindingContext = Parameters;
            Button btn_Ok = new Button
            {
                Text = "Ok",
                HorizontalOptions = LayoutOptions.Fill,
            };

            btn_Ok.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PopAsync();
            };
            this.MainStack.Children.Add(btn_Ok);


            Parameters.Context_MainStack = MainStack;
            foreach (KeyValuePair<string, Object> e in Parameters)
            {
                object v = "";
                if (App.Current.Properties.TryGetValue(e.Key, out v))
                {
                    Parameters[e.Key] = v;
                }
            }
            this.MainStack.Resources["sw_IsTorch_Enabled"] = Parameters.ext_ScanHardWare == 1;
            picker_ScanHardware.SelectedIndex = Parameters.ext_ScanHardWare;
            MPContext = MP;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            foreach (KeyValuePair<String, Object> e in Parameters)
            {
                object v = "";
                if (App.Current.Properties.TryGetValue(e.Key, out v))
                {
                    App.Current.Properties[e.Key] = e.Value;
                }
                else
                {
                    App.Current.Properties.Add(e.Key, e.Value);
                }
            }
        }
        protected override void OnAppearing()
        {
            AppGlobals.refCurrentPageContext = this;
        }
        private void picker_ScanHardware_SelectedIndexChanged(object sender, EventArgs e)
        {
            Parameters["ext_ScanHardWare"] = picker_ScanHardware.SelectedIndex;
        }
    }

    public class rendering_SettingsPageMain_TableView : TableView
    {

    }
    public class rendering_SettingsPageMain_SwitchCell : SwitchCell
    {

    }

    public class rendering_SettingsPageMain_EntryCell : EntryCell
    {

    }
    
    public class Parameters : INotifyPropertyChanged, IEnumerable, IEnumerator
    {
        //====== ext_bk_ScanEngine_
        private string int_Address;
        private string int_Login;
        private string int_Password;
        private string int_Timeout;
        private string int_DelayBetweenAnalyzingFrames;
        private string int_InitialDelayBeforeAnalyzingFrames;
        private string int_DelayBetweenContinuousScans;
        private bool int_Autofocus;
        private string int_AutofocusDelay;
        private bool int_PureBarcode;
        private bool int_UseNativeScanning;
        private bool int_TryHarder;
        private int int_ScanHardWare;
        private string int_IntentExtra;
        private string int_IntentFilter;
        private bool int_Torch;
        private string int_SupervisorPassword;

        //====== ext_bk_format_
        private bool int_bk_format_All_1D;
        private bool int_bk_format_AZTEC;
        private bool int_bk_format_CODABAR;
        private bool int_bk_format_EAN_8;
        private bool int_bk_format_EAN_13;
        private bool int_bk_format_CODE_128;
        private bool int_bk_format_CODE_39;
        private bool int_bk_format_CODE_93;
        private bool int_bk_format_DATA_MATRIX;
        private bool int_bk_format_IMB;
        private bool int_bk_format_ITF;
        private bool int_bk_format_MAXICODE;
        private bool int_bk_format_MSI;
        private bool int_bk_format_PDF_417;
        private bool int_bk_format_PLESSEY;
        private bool int_bk_format_QR_CODE;
        private bool int_bk_format_RSS_14;
        private bool int_bk_format_RSS_EXPANDED;
        private bool int_bk_format_UPC_A;
        private bool int_bk_format_UPC_E;
        private bool int_bk_format_UPC_EAN_EXTENSION;

        //====== ext_TabSel_Other_
        private bool int_TabSel_Other_ShowCharacteristic;
        private bool int_TabSel_Other_ShowSerial;
        private bool int_TabSel_Other_ShowValues;
        private bool int_TabSel_Other_ShowDocValue0;
        private bool int_TabSel_Other_ShowDocValue1;
        private bool int_TabSel_Other_ShowDocValue2;
        private string int_TabSel_Other_DeviceID;

        //====== ext_GoodListView_
        private bool int_GoodListView_GoodName_IsVivsible;
        private bool int_GoodListView_UnitName_IsVivsible;
        private bool int_GoodListView_GoodDescription_IsVivsible;
        private bool int_GoodListView_GoodSerial_IsVivsible;
        private bool int_GoodListView_GoodQuality_IsVivsible;
        private bool int_GoodListView_GoodAmount_IsVivsible;
        private bool int_GoodListView_GoodAmountAquired_IsVivsible;
        private bool int_GoodListView_Value0_IsVivsible;
        private bool int_GoodListView_Value1_IsVivsible;
        private bool int_GoodListView_Value2_IsVivsible;

        private string int_GoodListView_GoodName_Width;
        private string int_GoodListView_UnitName_Width;
        private string int_GoodListView_GoodDescription_Width;
        private string int_GoodListView_GoodSerial_Width;
        private string int_GoodListView_GoodQuality_Width;
        private string int_GoodListView_GoodAmount_Width;
        private string int_GoodListView_GoodAmountAquired_Width;
        private string int_GoodListView_Value0_Width;
        private string int_GoodListView_Value1_Width;
        private string int_GoodListView_Value2_Width;

        int index = -1;

        public Parameters()
        {
            int_Address = "http://127.0.0.1/DatabaseName/hs/ServiceName";
            int_Login = "";
            int_Password = "";
            int_Timeout = "10";
            int_DelayBetweenAnalyzingFrames = "150";
            int_InitialDelayBeforeAnalyzingFrames = "300";
            int_DelayBetweenContinuousScans = "1000";
            int_Autofocus = true;
            int_AutofocusDelay = "2";
            int_PureBarcode = false;
            int_UseNativeScanning = false;
            int_TryHarder = true;
            int_ScanHardWare = 1;
            int_IntentExtra = "codestr";
            int_IntentFilter = "scan.rcv.enter";
            int_Torch = true;
            int_SupervisorPassword = "";

            int_bk_format_All_1D = true;
            int_bk_format_AZTEC = false;
            int_bk_format_CODABAR = false;
            int_bk_format_EAN_8 = false;
            int_bk_format_EAN_13 = false;
            int_bk_format_CODE_128 = false;
            int_bk_format_CODE_39 = false;
            int_bk_format_CODE_93 = false;
            int_bk_format_DATA_MATRIX = false;
            int_bk_format_IMB = false;
            int_bk_format_ITF = false;
            int_bk_format_MAXICODE = false;
            int_bk_format_MSI = false;
            int_bk_format_PDF_417 = false;
            int_bk_format_PLESSEY = false;
            int_bk_format_QR_CODE = false;
            int_bk_format_RSS_14 = false;
            int_bk_format_RSS_EXPANDED = false;
            int_bk_format_UPC_A = false;
            int_bk_format_UPC_E = false;
            int_bk_format_UPC_EAN_EXTENSION = false;

            int_TabSel_Other_ShowCharacteristic = false;
            int_TabSel_Other_ShowSerial = false;
            int_TabSel_Other_ShowValues = false;
            int_TabSel_Other_ShowDocValue0 = false;
            int_TabSel_Other_ShowDocValue1 = false;
            int_TabSel_Other_ShowDocValue2 = false;
            int_TabSel_Other_DeviceID = "";

            //====== int_GoodListView_
            int_GoodListView_GoodName_IsVivsible = true;
            int_GoodListView_UnitName_IsVivsible = true;
            int_GoodListView_GoodDescription_IsVivsible = false;
            int_GoodListView_GoodSerial_IsVivsible = false;
            int_GoodListView_GoodQuality_IsVivsible = true;
            int_GoodListView_GoodAmount_IsVivsible = true;
            int_GoodListView_GoodAmountAquired_IsVivsible = true;
            int_GoodListView_Value0_IsVivsible = false;
            int_GoodListView_Value1_IsVivsible = false;
            int_GoodListView_Value2_IsVivsible = false;

            int_GoodListView_GoodName_Width = "*";
            int_GoodListView_UnitName_Width = "*";
            int_GoodListView_GoodDescription_Width = "*";
            int_GoodListView_GoodSerial_Width = "*";
            int_GoodListView_GoodQuality_Width = "*";
            int_GoodListView_GoodAmount_Width = "*";
            int_GoodListView_GoodAmountAquired_Width = "*";
            int_GoodListView_Value0_Width = "*";
            int_GoodListView_Value1_Width = "*";
            int_GoodListView_Value2_Width = "*";
        }
        public StackLayout Context_MainStack;
        public string ext_Address
        {
            get { return int_Address; }
            set
            {
                if (int_Address != value)
                {
                    int_Address = value;
                    OnPropertyChanged("ext_Address");
                }
            }
        }
        public string ext_Login
        {
            get { return int_Login; }
            set
            {
                if (int_Login != value)
                {
                    int_Login = value;
                    OnPropertyChanged("ext_Login");
                }
            }
        }
        public string ext_Password
        {
            get { return int_Password; }
            set
            {
                if (int_Password != value)
                {
                    int_Password = value;
                    OnPropertyChanged("ext_Password");
                }
            }
        }
        public string ext_Timeout
        {
            get { return int_Timeout; }
            set
            {
                if (int_Timeout != value)
                {
                    int_Timeout = value;
                    OnPropertyChanged("ext_Timeout");
                }
            }
        }
        public string ext_DelayBetweenAnalyzingFrames
        {
            get { return int_DelayBetweenAnalyzingFrames; }
            set
            {
                if (int_DelayBetweenAnalyzingFrames != value)
                {
                    int_DelayBetweenAnalyzingFrames = value;
                    OnPropertyChanged("ext_DelayBetweenAnalyzingFrames");
                }
            }
        }
        public string ext_InitialDelayBeforeAnalyzingFrames
        {
            get { return int_InitialDelayBeforeAnalyzingFrames; }
            set
            {
                if (int_InitialDelayBeforeAnalyzingFrames != value)
                {
                    int_InitialDelayBeforeAnalyzingFrames = value;
                    OnPropertyChanged("ext_InitialDelayBeforeAnalyzingFrames");
                }
            }
        }
        public string ext_DelayBetweenContinuousScans
        {
            get { return int_DelayBetweenContinuousScans; }
            set
            {
                if (int_DelayBetweenContinuousScans != value)
                {
                    int_DelayBetweenContinuousScans = value;
                    OnPropertyChanged("ext_DelayBetweenContinuousScans");
                }
            }
        }
        public bool ext_Autofocus
        {
            get { return int_Autofocus; }
            set
            {
                if (int_Autofocus != value)
                {
                    int_Autofocus = value;
                    OnPropertyChanged("ext_Autofocus");
                }
            }
        }
        public string ext_AutofocusDelay
        {
            get { return int_AutofocusDelay; }
            set
            {
                if (int_AutofocusDelay != value)
                {
                    int_AutofocusDelay = value;
                    OnPropertyChanged("ext_AutofocusDelay");
                }
            }
        }
        public bool ext_UseNativeScanning
        {
            get { return int_UseNativeScanning; }
            set
            {
                if (int_UseNativeScanning != value)
                {
                    int_UseNativeScanning = value;
                    OnPropertyChanged("ext_UseNativeScanning");
                }
            }
        }
        public bool ext_PureBarcode
        {
            get { return int_PureBarcode; }
            set
            {
                if (int_PureBarcode != value)
                {
                    int_PureBarcode = value;
                    OnPropertyChanged("ext_PureBarcode");
                }
            }
        }
        public bool ext_TryHarder
        {
            get { return int_TryHarder; }
            set
            {
                if (int_TryHarder != value)
                {
                    int_TryHarder = value;
                    OnPropertyChanged("ext_TryHarder");
                }
            }
        }
        public int ext_ScanHardWare
        {
            get { return int_ScanHardWare; }
            set
            {
                if (int_ScanHardWare != value)
                {
                    int_ScanHardWare = value;
                    OnPropertyChanged("ext_ScanHardWare");
                    Context_MainStack.Resources["sw_IsTorch_Enabled"] = int_ScanHardWare == 1;
                }
            }
        }
        public bool ext_Torch
        {
            get { return int_Torch; }
            set
            {
                if (int_Torch != value)
                {
                    int_Torch = value;
                    OnPropertyChanged("ext_Torch");
                }
            }
        }

        public string ext_SupervisorPassword
        {
            get { return int_SupervisorPassword; }
            set
            {
                if (int_SupervisorPassword != value)
                {
                    int_SupervisorPassword = value;
                    OnPropertyChanged("ext_SupervisorPassword");
                }
            }
        }
        public bool ext_bk_format_All_1D
        {
            get { return int_bk_format_All_1D; }
            set
            {
                if (int_bk_format_All_1D != value)
                {
                    int_bk_format_All_1D = value;
                    OnPropertyChanged("ext_bk_format_All_1D");
                }
            }
        }
        public bool ext_bk_format_AZTEC
        {
            get { return int_bk_format_AZTEC; }
            set
            {
                if (int_bk_format_AZTEC != value)
                {
                    int_bk_format_AZTEC = value;
                    OnPropertyChanged("ext_bk_format_AZTEC");
                }
            }
        }
        public bool ext_bk_format_CODABAR
        {
            get { return int_bk_format_CODABAR; }
            set
            {
                if (int_bk_format_CODABAR != value)
                {
                    int_bk_format_CODABAR = value;
                    OnPropertyChanged("ext_bk_format_CODABAR");
                }
            }
        }
        public bool ext_bk_format_EAN_8
        {
            get { return int_bk_format_EAN_8; }
            set
            {
                if (int_bk_format_EAN_8 != value)
                {
                    int_bk_format_EAN_8 = value;
                    OnPropertyChanged("ext_bk_format_EAN_8");
                }
            }
        }
        public bool ext_bk_format_EAN_13
        {
            get { return int_bk_format_EAN_13; }
            set
            {
                if (int_bk_format_EAN_13 != value)
                {
                    int_bk_format_EAN_13 = value;
                    OnPropertyChanged("ext_bk_format_EAN_13");
                }
            }
        }
        public bool ext_bk_format_CODE_128
        {
            get { return int_bk_format_CODE_128; }
            set
            {
                if (int_bk_format_CODE_128 != value)
                {
                    int_bk_format_CODE_128 = value;
                    OnPropertyChanged("ext_bk_format_CODE_128");
                }
            }
        }
        public bool ext_bk_format_CODE_39
        {
            get { return int_bk_format_CODE_39; }
            set
            {
                if (int_bk_format_CODE_39 != value)
                {
                    int_bk_format_CODE_39 = value;
                    OnPropertyChanged("ext_bk_format_CODE_39");
                }
            }
        }
        public bool ext_bk_format_CODE_93
        {
            get { return int_bk_format_CODE_93; }
            set
            {
                if (int_bk_format_CODE_93 != value)
                {
                    int_bk_format_CODE_93 = value;
                    OnPropertyChanged("ext_bk_format_CODE_93");
                }
            }
        }
        public bool ext_bk_format_DATA_MATRIX
        {
            get { return int_bk_format_DATA_MATRIX; }
            set
            {
                if (int_bk_format_DATA_MATRIX != value)
                {
                    int_bk_format_DATA_MATRIX = value;
                    OnPropertyChanged("ext_bk_format_DATA_MATRIX");
                }
            }
        }
        public bool ext_bk_format_IMB
        {
            get { return int_bk_format_IMB; }
            set
            {
                if (int_bk_format_IMB != value)
                {
                    int_bk_format_IMB = value;
                    OnPropertyChanged("ext_bk_format_IMB");
                }
            }
        }
        public bool ext_bk_format_ITF
        {
            get { return int_bk_format_ITF; }
            set
            {
                if (int_bk_format_ITF != value)
                {
                    int_bk_format_ITF = value;
                    OnPropertyChanged("ext_bk_format_ITF");
                }
            }
        }
        public bool ext_bk_format_MAXICODE
        {
            get { return int_bk_format_MAXICODE; }
            set
            {
                if (int_bk_format_MAXICODE != value)
                {
                    int_bk_format_MAXICODE = value;
                    OnPropertyChanged("ext_bk_format_MAXICODE");
                }
            }
        }
        public bool ext_bk_format_MSI
        {
            get { return int_bk_format_MSI; }
            set
            {
                if (int_bk_format_MSI != value)
                {
                    int_bk_format_MSI = value;
                    OnPropertyChanged("ext_bk_format_MSI");
                }
            }
        }
        public bool ext_bk_format_PDF_417
        {
            get { return int_bk_format_PDF_417; }
            set
            {
                if (int_bk_format_PDF_417 != value)
                {
                    int_bk_format_PDF_417 = value;
                    OnPropertyChanged("ext_bk_format_PDF_417");
                }
            }
        }
        public bool ext_bk_format_PLESSEY
        {
            get { return int_bk_format_PLESSEY; }
            set
            {
                if (int_bk_format_PLESSEY != value)
                {
                    int_bk_format_PLESSEY = value;
                    OnPropertyChanged("ext_bk_format_PLESSEY");
                }
            }
        }
        public bool ext_bk_format_QR_CODE
        {
            get { return int_bk_format_QR_CODE; }
            set
            {
                if (int_bk_format_QR_CODE != value)
                {
                    int_bk_format_QR_CODE = value;
                    OnPropertyChanged("ext_bk_format_QR_CODE");
                }
            }
        }
        public bool ext_bk_format_RSS_14
        {
            get { return int_bk_format_RSS_14; }
            set
            {
                if (int_bk_format_RSS_14 != value)
                {
                    int_bk_format_RSS_14 = value;
                    OnPropertyChanged("ext_bk_format_RSS_14");
                }
            }
        }
        public bool ext_bk_format_RSS_EXPANDED
        {
            get { return int_bk_format_RSS_EXPANDED; }
            set
            {
                if (int_bk_format_RSS_EXPANDED != value)
                {
                    int_bk_format_RSS_EXPANDED = value;
                    OnPropertyChanged("ext_bk_format_RSS_EXPANDED");
                }
            }
        }
        public bool ext_bk_format_UPC_A
        {
            get { return int_bk_format_UPC_A; }
            set
            {
                if (int_bk_format_UPC_A != value)
                {
                    int_bk_format_UPC_A = value;
                    OnPropertyChanged("ext_bk_format_UPC_A");
                }
            }
        }
        public bool ext_bk_format_UPC_E
        {
            get { return int_bk_format_UPC_E; }
            set
            {
                if (int_bk_format_UPC_E != value)
                {
                    int_bk_format_UPC_E = value;
                    OnPropertyChanged("ext_bk_format_UPC_E");
                }
            }
        }
        public bool ext_bk_format_UPC_EAN_EXTENSION
        {
            get { return int_bk_format_UPC_EAN_EXTENSION; }
            set
            {
                if (int_bk_format_UPC_EAN_EXTENSION != value)
                {
                    int_bk_format_UPC_EAN_EXTENSION = value;
                    OnPropertyChanged("ext_bk_format_UPC_EAN_EXTENSION");
                }
            }
        }
        
        public string ext_IntentExtra
        {
            get { return int_IntentExtra; }
            set
            {
                if (int_IntentExtra != value)
                {
                    int_IntentExtra = value;
                    OnPropertyChanged("ext_IntentExtra");
                }
            }
        }
        public string ext_IntentFilter
        {
            get { return int_IntentFilter; }
            set
            {
                if (int_IntentFilter != value)
                {
                    int_IntentFilter = value;
                    OnPropertyChanged("ext_IntentFilter");
                }
            }
        }

        public bool ext_TabSel_Other_ShowCharacteristic
        {
            get { return int_TabSel_Other_ShowCharacteristic; }
            set
            {
                if (int_TabSel_Other_ShowCharacteristic != value)
                {
                    int_TabSel_Other_ShowCharacteristic = value;
                    OnPropertyChanged("ext_TabSel_Other_ShowCharacteristic");
                }
            }
        }
        public bool ext_TabSel_Other_ShowSerial
        {
            get { return int_TabSel_Other_ShowSerial; }
            set
            {
                if (int_TabSel_Other_ShowSerial != value)
                {
                    int_TabSel_Other_ShowSerial = value;
                    OnPropertyChanged("ext_TabSel_Other_ShowSerial");
                }
            }
        }
        public bool ext_TabSel_Other_ShowValues
        {
            get { return int_TabSel_Other_ShowValues; }
            set
            {
                if (int_TabSel_Other_ShowValues != value)
                {
                    int_TabSel_Other_ShowValues = value;
                    OnPropertyChanged("ext_TabSel_Other_ShowValues");
                }
            }
        }
        public bool ext_TabSel_Other_ShowDocValue0
        {
            get { return int_TabSel_Other_ShowDocValue0; }
            set
            {
                if (int_TabSel_Other_ShowDocValue0 != value)
                {
                    int_TabSel_Other_ShowDocValue0 = value;
                    OnPropertyChanged("ext_TabSel_Other_ShowDocValue0");
                }
            }
        }
        public bool ext_TabSel_Other_ShowDocValue1
        {
            get { return int_TabSel_Other_ShowDocValue1; }
            set
            {
                if (int_TabSel_Other_ShowDocValue1 != value)
                {
                    int_TabSel_Other_ShowDocValue1 = value;
                    OnPropertyChanged("ext_TabSel_Other_ShowDocValue1");
                }
            }
        }
        public bool ext_TabSel_Other_ShowDocValue2
        {
            get { return int_TabSel_Other_ShowDocValue2; }
            set
            {
                if (int_TabSel_Other_ShowDocValue2 != value)
                {
                    int_TabSel_Other_ShowDocValue2 = value;
                    OnPropertyChanged("ext_TabSel_Other_ShowDocValue2");
                }
            }
        }
        public string ext_TabSel_Other_DeviceID
        {
            get { return int_TabSel_Other_DeviceID; }
            set
            {
                if (int_TabSel_Other_DeviceID != value)
                {
                    int_TabSel_Other_DeviceID = value;
                    OnPropertyChanged("ext_TabSel_Other_DeviceID");
                }
            }
        }
        
        //====== int_GoodListView_
        public bool ext_GoodListView_GoodName_IsVivsible
        {
            get { return int_GoodListView_GoodName_IsVivsible; }
            set
            {
                if (int_GoodListView_GoodName_IsVivsible != value)
                {
                    int_GoodListView_GoodName_IsVivsible = value;
                    OnPropertyChanged("ext_GoodListView_GoodName_IsVivsible");
                }
            }
        }
        public bool ext_GoodListView_UnitName_IsVivsible
        {
            get { return int_GoodListView_UnitName_IsVivsible; }
            set
            {
                if (int_GoodListView_UnitName_IsVivsible != value)
                {
                    int_GoodListView_UnitName_IsVivsible = value;
                    OnPropertyChanged("ext_GoodListView_UnitName_IsVivsible");
                }
            }
        }
        public bool ext_GoodListView_GoodDescription_IsVivsible
        {
            get { return int_GoodListView_GoodDescription_IsVivsible; }
            set
            {
                if (int_GoodListView_GoodDescription_IsVivsible != value)
                {
                    int_GoodListView_GoodDescription_IsVivsible = value;
                    OnPropertyChanged("ext_GoodListView_GoodDescription_IsVivsible");
                }
            }
        }
        public bool ext_GoodListView_GoodSerial_IsVivsible
        {
            get { return int_GoodListView_GoodSerial_IsVivsible; }
            set
            {
                if (int_GoodListView_GoodSerial_IsVivsible != value)
                {
                    int_GoodListView_GoodSerial_IsVivsible = value;
                    OnPropertyChanged("ext_GoodListView_GoodSerial_IsVivsible");
                }
            }
        }
        public bool ext_GoodListView_GoodQuality_IsVivsible
        {
            get { return int_GoodListView_GoodQuality_IsVivsible; }
            set
            {
                if (int_GoodListView_GoodQuality_IsVivsible != value)
                {
                    int_GoodListView_GoodQuality_IsVivsible = value;
                    OnPropertyChanged("ext_GoodListView_GoodQuality_IsVivsible");
                }
            }
        }
        public bool ext_GoodListView_GoodAmount_IsVivsible
        {
            get { return int_GoodListView_GoodAmount_IsVivsible; }
            set
            {
                if (int_GoodListView_GoodAmount_IsVivsible != value)
                {
                    int_GoodListView_GoodAmount_IsVivsible = value;
                    OnPropertyChanged("ext_GoodListView_GoodAmount_IsVivsible");
                }
            }
        }
        public bool ext_GoodListView_GoodAmountAquired_IsVivsible
        {
            get { return int_GoodListView_GoodAmountAquired_IsVivsible; }
            set
            {
                if (int_GoodListView_GoodAmountAquired_IsVivsible != value)
                {
                    int_GoodListView_GoodAmountAquired_IsVivsible = value;
                    OnPropertyChanged("ext_GoodListView_GoodAmountAquired_IsVivsible");
                }
            }
        }
        public bool ext_GoodListView_Value0_IsVivsible
        {
            get { return int_GoodListView_Value0_IsVivsible; }
            set
            {
                if (int_GoodListView_Value0_IsVivsible != value)
                {
                    int_GoodListView_Value0_IsVivsible = value;
                    OnPropertyChanged("ext_GoodListView_Value0_IsVivsible");
                }
            }
        }
        public bool ext_GoodListView_Value1_IsVivsible
        {
            get { return int_GoodListView_Value1_IsVivsible; }
            set
            {
                if (int_GoodListView_Value1_IsVivsible != value)
                {
                    int_GoodListView_Value1_IsVivsible = value;
                    OnPropertyChanged("ext_GoodListView_Value1_IsVivsible");
                }
            }
        }
        public bool ext_GoodListView_Value2_IsVivsible
        {
            get { return int_GoodListView_Value2_IsVivsible; }
            set
            {
                if (int_GoodListView_Value2_IsVivsible != value)
                {
                    int_GoodListView_Value2_IsVivsible = value;
                    OnPropertyChanged("ext_GoodListView_Value2_IsVivsible");
                }
            }
        }
        public string ext_GoodListView_GoodName_Width
        {
            get { return int_GoodListView_GoodName_Width; }
            set
            {
                if (int_GoodListView_GoodName_Width != value)
                {
                    int_GoodListView_GoodName_Width = value;
                    OnPropertyChanged("ext_GoodListView_GoodName_Width");
                }
            }
        }
        public string ext_GoodListView_UnitName_Width
        {
            get { return int_GoodListView_UnitName_Width; }
            set
            {
                if (int_GoodListView_UnitName_Width != value)
                {
                    int_GoodListView_UnitName_Width = value;
                    OnPropertyChanged("ext_GoodListView_UnitName_Width");
                }
            }
        }
        public string ext_GoodListView_GoodDescription_Width
        {
            get { return int_GoodListView_GoodDescription_Width; }
            set
            {
                if (int_GoodListView_GoodDescription_Width != value)
                {
                    int_GoodListView_GoodDescription_Width = value;
                    OnPropertyChanged("ext_GoodListView_GoodDescription_Width");
                }
            }
        }
        public string ext_GoodListView_GoodSerial_Width
        {
            get { return int_GoodListView_GoodSerial_Width; }
            set
            {
                if (int_GoodListView_GoodSerial_Width != value)
                {
                    int_GoodListView_GoodSerial_Width = value;
                    OnPropertyChanged("ext_GoodListView_GoodSerial_Width");
                }
            }
        }
        public string ext_GoodListView_GoodQuality_Width
        {
            get { return int_GoodListView_GoodQuality_Width; }
            set
            {
                if (int_GoodListView_GoodQuality_Width != value)
                {
                    int_GoodListView_GoodQuality_Width = value;
                    OnPropertyChanged("ext_GoodListView_GoodQuality_Width");
                }
            }
        }
        public string ext_GoodListView_GoodAmount_Width
        {
            get { return int_GoodListView_GoodAmount_Width; }
            set
            {
                if (int_GoodListView_GoodAmount_Width != value)
                {
                    int_GoodListView_GoodAmount_Width = value;
                    OnPropertyChanged("ext_GoodListView_GoodAmount_Width");
                }
            }
        }
        public string ext_GoodListView_GoodAmountAquired_Width
        {
            get { return int_GoodListView_GoodAmountAquired_Width; }
            set
            {
                if (int_GoodListView_GoodAmountAquired_Width != value)
                {
                    int_GoodListView_GoodAmountAquired_Width = value;
                    OnPropertyChanged("ext_GoodListView_GoodAmountAquired_Width");
                }
            }
        }
        public string ext_GoodListView_Value0_Width
        {
            get { return int_GoodListView_Value0_Width; }
            set
            {
                if (int_GoodListView_Value0_Width != value)
                {
                    int_GoodListView_Value0_Width = value;
                    OnPropertyChanged("ext_GoodListView_Value0_Width");
                }
            }
        }
        public string ext_GoodListView_Value1_Width
        {
            get { return int_GoodListView_Value1_Width; }
            set
            {
                if (int_GoodListView_Value1_Width != value)
                {
                    int_GoodListView_Value1_Width = value;
                    OnPropertyChanged("ext_GoodListView_Value1_Width");
                }
            }
        }
        public string ext_GoodListView_Value2_Width
        {
            get { return int_GoodListView_Value2_Width; }
            set
            {
                if (int_GoodListView_Value2_Width != value)
                {
                    int_GoodListView_Value2_Width = value;
                    OnPropertyChanged("ext_GoodListView_Value2_Width");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        public void Reset() { index = -1; }
        public bool MoveNext()
        {
            if (index == 64)
            {
                index = -1;
                return false;
            }
            index++;
            return true;

        }
        public object Current
        {
            get
            {
                switch (index)
                {
                    case 0: return new KeyValuePair<string, Object>("ext_Address", ext_Address);
                    case 1: return new KeyValuePair<string, Object>("ext_Login", ext_Login);
                    case 2: return new KeyValuePair<string, Object>("ext_Password", ext_Password);
                    case 3: return new KeyValuePair<string, Object>("ext_Timeout", ext_Timeout);
                    case 4: return new KeyValuePair<string, Object>("ext_DelayBetweenAnalyzingFrames", ext_DelayBetweenAnalyzingFrames);
                    case 5: return new KeyValuePair<string, Object>("ext_InitialDelayBeforeAnalyzingFrames", ext_InitialDelayBeforeAnalyzingFrames);
                    case 6: return new KeyValuePair<string, Object>("ext_DelayBetweenContinuousScans", ext_DelayBetweenContinuousScans);
                    case 7: return new KeyValuePair<string, Object>("ext_Autofocus", ext_Autofocus);
                    case 8: return new KeyValuePair<string, Object>("ext_AutofocusDelay", ext_AutofocusDelay);
                    case 9: return new KeyValuePair<string, Object>("ext_UseNativeScanning", ext_UseNativeScanning);
                    case 10: return new KeyValuePair<string, Object>("ext_PureBarcode", ext_PureBarcode);
                    case 11: return new KeyValuePair<string, Object>("ext_TryHarder", ext_TryHarder);
                    case 12: return new KeyValuePair<string, Object>("ext_ScanHardWare", ext_ScanHardWare);

                    case 13: return new KeyValuePair<string, Object>("ext_bk_format_All_1D", ext_bk_format_All_1D);
                    case 14: return new KeyValuePair<string, Object>("ext_bk_format_AZTEC", ext_bk_format_AZTEC);
                    case 15: return new KeyValuePair<string, Object>("ext_bk_format_CODABAR", ext_bk_format_CODABAR);
                    case 16: return new KeyValuePair<string, Object>("ext_bk_format_EAN_8", ext_bk_format_EAN_8);
                    case 17: return new KeyValuePair<string, Object>("ext_bk_format_EAN_13", ext_bk_format_EAN_13);
                    case 18: return new KeyValuePair<string, Object>("ext_bk_format_CODE_128", ext_bk_format_CODE_128);
                    case 19: return new KeyValuePair<string, Object>("ext_bk_format_CODE_39", ext_bk_format_CODE_39);
                    case 20: return new KeyValuePair<string, Object>("ext_bk_format_CODE_93", ext_bk_format_CODE_93);
                    case 21: return new KeyValuePair<string, Object>("ext_bk_format_DATA_MATRIX", ext_bk_format_DATA_MATRIX);
                    case 22: return new KeyValuePair<string, Object>("ext_bk_format_IMB", ext_bk_format_IMB);
                    case 23: return new KeyValuePair<string, Object>("ext_bk_format_ITF", ext_bk_format_ITF);
                    case 24: return new KeyValuePair<string, Object>("ext_bk_format_MAXICODE", ext_bk_format_MAXICODE);
                    case 25: return new KeyValuePair<string, Object>("ext_bk_format_MSI", ext_bk_format_MSI);
                    case 26: return new KeyValuePair<string, Object>("ext_bk_format_PDF_417", ext_bk_format_PDF_417);
                    case 27: return new KeyValuePair<string, Object>("ext_bk_format_PLESSEY", ext_bk_format_PLESSEY);
                    case 28: return new KeyValuePair<string, Object>("ext_bk_format_QR_CODE", ext_bk_format_QR_CODE);
                    case 29: return new KeyValuePair<string, Object>("ext_bk_format_RSS_14", ext_bk_format_RSS_14);
                    case 30: return new KeyValuePair<string, Object>("ext_bk_format_RSS_EXPANDED", ext_bk_format_RSS_EXPANDED);
                    case 31: return new KeyValuePair<string, Object>("ext_bk_format_UPC_A", ext_bk_format_UPC_A);
                    case 32: return new KeyValuePair<string, Object>("ext_bk_format_UPC_E", ext_bk_format_UPC_E);
                    case 33: return new KeyValuePair<string, Object>("ext_bk_format_UPC_EAN_EXTENSION", ext_bk_format_UPC_EAN_EXTENSION);
                    case 34: return new KeyValuePair<string, Object>("ext_Torch", ext_Torch);
                    case 35: return new KeyValuePair<string, Object>("ext_IntentExtra", ext_IntentExtra);
                    case 36: return new KeyValuePair<string, Object>("ext_IntentFilter", ext_IntentFilter);
                    case 37: return new KeyValuePair<string, Object>("ext_SupervisorPassword", ext_SupervisorPassword);

                    case 38: return new KeyValuePair<string, Object>("ext_TabSel_Other_ShowCharacteristic", ext_TabSel_Other_ShowCharacteristic);
                    case 39: return new KeyValuePair<string, Object>("ext_TabSel_Other_ShowSerial", ext_TabSel_Other_ShowSerial);
                    case 40: return new KeyValuePair<string, Object>("ext_TabSel_Other_ShowValues", ext_TabSel_Other_ShowValues);
                    case 41: return new KeyValuePair<string, Object>("ext_TabSel_Other_ShowDocValu0", ext_TabSel_Other_ShowDocValue0);
                    case 42: return new KeyValuePair<string, Object>("ext_TabSel_Other_ShowDocValue1", ext_TabSel_Other_ShowDocValue1);
                    case 43: return new KeyValuePair<string, Object>("ext_TabSel_Other_ShowDocValue2", ext_TabSel_Other_ShowDocValue2);
                    case 44: return new KeyValuePair<string, Object>("ext_TabSel_Other_DeviceID", ext_TabSel_Other_DeviceID);

                    //====== int_GoodListView_
                    case 45: return new KeyValuePair<string, Object>("ext_GoodListView_GoodName_IsVivsible", ext_GoodListView_GoodName_IsVivsible);
                    case 46: return new KeyValuePair<string, Object>("ext_GoodListView_UnitName_IsVivsible", ext_GoodListView_UnitName_IsVivsible);
                    case 47: return new KeyValuePair<string, Object>("ext_GoodListView_GoodDescription_IsVivsible", ext_GoodListView_GoodDescription_IsVivsible);
                    case 48: return new KeyValuePair<string, Object>("ext_GoodListView_GoodSerial_IsVivsible", ext_GoodListView_GoodSerial_IsVivsible);
                    case 49: return new KeyValuePair<string, Object>("ext_GoodListView_GoodQuality_IsVivsible", ext_GoodListView_GoodQuality_IsVivsible);
                    case 50: return new KeyValuePair<string, Object>("ext_GoodListView_GoodAmount_IsVivsible", ext_GoodListView_GoodAmount_IsVivsible);
                    case 51: return new KeyValuePair<string, Object>("ext_GoodListView_GoodAmountAquired_IsVivsible", ext_GoodListView_GoodAmountAquired_IsVivsible);
                    case 52: return new KeyValuePair<string, Object>("ext_GoodListView_Value0_IsVivsible", ext_GoodListView_Value0_IsVivsible);
                    case 53: return new KeyValuePair<string, Object>("ext_GoodListView_Value1_IsVivsible", ext_GoodListView_Value1_IsVivsible);
                    case 54: return new KeyValuePair<string, Object>("ext_GoodListView_Value2_IsVivsible", ext_GoodListView_Value2_IsVivsible);

                    case 55: return new KeyValuePair<string, Object>("ext_GoodListView_GoodName_Width", ext_GoodListView_GoodName_Width);
                    case 56: return new KeyValuePair<string, Object>("ext_GoodListView_UnitName_Width", ext_GoodListView_UnitName_Width);
                    case 57: return new KeyValuePair<string, Object>("ext_GoodListView_GoodDescription_Width", ext_GoodListView_GoodDescription_Width);
                    case 58: return new KeyValuePair<string, Object>("ext_GoodListView_GoodSerial_Width", ext_GoodListView_GoodSerial_Width);
                    case 59: return new KeyValuePair<string, Object>("ext_GoodListView_GoodQuality_Width", ext_GoodListView_GoodQuality_Width);
                    case 60: return new KeyValuePair<string, Object>("ext_GoodListView_GoodAmount_Width", ext_GoodListView_GoodAmount_Width);
                    case 61: return new KeyValuePair<string, Object>("ext_GoodListView_GoodAmountAquired_Width", ext_GoodListView_GoodAmountAquired_Width);
                    case 62: return new KeyValuePair<string, Object>("ext_GoodListView_Value0_Width", ext_GoodListView_Value0_Width);
                    case 63: return new KeyValuePair<string, Object>("ext_GoodListView_Value1_Width", ext_GoodListView_Value1_Width);
                    case 64: return new KeyValuePair<string, Object>("ext_GoodListView_Value2_Width", ext_GoodListView_Value2_Width);
                    default: return null;
                }
            }
        }
        public object this[string ind]
        {
            get
            {
                return GetByIndex(ind);
            }
            set
            {
                SetByIndex(ind, value);
            }
        }
        protected void SetByIndex(string ind, object value)
        {
            switch (ind)
            {
                case "ext_Address":
                    ext_Address = value.ToString();
                    break;
                case "ext_Login":

                    ext_Login = value.ToString();
                    break;
                case "ext_Password":

                    ext_Password = value.ToString();
                    break;
                case "ext_Timeout":

                    ext_Timeout = value.ToString();
                    break;
                case "ext_DelayBetweenAnalyzingFrames":

                    ext_DelayBetweenAnalyzingFrames = value.ToString();
                    break;
                case "ext_InitialDelayBeforeAnalyzingFrames":

                    ext_InitialDelayBeforeAnalyzingFrames = value.ToString();
                    break;
                case "ext_DelayBetweenContinuousScans":

                    ext_DelayBetweenContinuousScans = value.ToString();
                    break;
                case "ext_Autofocus":

                    ext_Autofocus = (bool)value;
                    break;
                case "ext_AutofocusDelay":

                    ext_AutofocusDelay = value.ToString();
                    break;
                case "ext_UseNativeScanning":

                    ext_UseNativeScanning = (bool)value;
                    break;
                case "ext_PureBarcode":

                    ext_PureBarcode = (bool)value;
                    break;
                case "ext_TryHarder":

                    ext_TryHarder = (bool)value;
                    break;
                case "ext_ScanHardWare":

                    ext_ScanHardWare = (int)value;
                    break;
                case "ext_Torch":

                    ext_Torch = (bool)value;
                    break;

                //===== ext_bk_format_
                case "ext_bk_format_All_1D":

                    ext_bk_format_All_1D = (bool)value;
                    break;
                case "ext_bk_format_AZTEC":

                    ext_bk_format_AZTEC = (bool)value;
                    break;
                case "ext_bk_format_CODABAR":

                    ext_bk_format_CODABAR = (bool)value;
                    break;
                case "ext_bk_format_EAN_8":

                    ext_bk_format_EAN_8 = (bool)value;
                    break;
                case "ext_bk_format_EAN_13":

                    ext_bk_format_EAN_13 = (bool)value;
                    break;
                case "ext_bk_format_CODE_128":

                    ext_bk_format_CODE_128 = (bool)value;
                    break;
                case "ext_bk_format_CODE_39":

                    ext_bk_format_CODE_39 = (bool)value;
                    break;
                case "ext_bk_format_CODE_93":

                    ext_bk_format_CODE_93 = (bool)value;
                    break;
                case "ext_bk_format_DATA_MATRIX":

                    ext_bk_format_DATA_MATRIX = (bool)value;
                    break;
                case "ext_bk_format_IMB":

                    ext_bk_format_IMB = (bool)value;
                    break;
                case "ext_bk_format_ITF":

                    ext_bk_format_ITF = (bool)value;
                    break;
                case "ext_bk_format_MAXICODE":

                    ext_bk_format_MAXICODE = (bool)value;
                    break;
                case "ext_bk_format_MSI":

                    ext_bk_format_MSI = (bool)value;
                    break;
                case "ext_bk_format_PDF_417":

                    ext_bk_format_PDF_417 = (bool)value;
                    break;
                case "ext_bk_format_PLESSEY":

                    ext_bk_format_PLESSEY = (bool)value;
                    break;
                case "ext_bk_format_QR_CODE":

                    ext_bk_format_QR_CODE = (bool)value;
                    break;
                case "ext_bk_format_RSS_14":

                    ext_bk_format_RSS_14 = (bool)value;
                    break;
                case "ext_bk_format_RSS_EXPANDED":

                    ext_bk_format_RSS_EXPANDED = (bool)value;
                    break;
                case "ext_bk_format_UPC_A":

                    ext_bk_format_UPC_A = (bool)value;
                    break;
                case "ext_bk_format_UPC_E":

                    ext_bk_format_UPC_E = (bool)value;
                    break;
                case "ext_bk_format_UPC_EAN_EXTENSION":

                    ext_bk_format_UPC_EAN_EXTENSION = (bool)value;
                    break;

                case "ext_IntentExtra":

                    ext_IntentExtra = (string)value;
                    break;
                case "ext_IntentFilter":

                    ext_IntentFilter = (string)value;
                    break;
                case "ext_SupervisorPassword":

                    ext_SupervisorPassword = (string)value;
                    break;

                //===== ext_TabSel_Other_

                case "ext_TabSel_Other_ShowCharacteristic":

                    ext_TabSel_Other_ShowCharacteristic = (bool)value;
                    break;

                case "ext_TabSel_Other_ShowSerial":

                    ext_TabSel_Other_ShowSerial = (bool)value;
                    break;

                case "ext_TabSel_Other_ShowValues":

                    ext_TabSel_Other_ShowValues = (bool)value;
                    break;
                case "ext_TabSel_Other_ShowDocValue0":

                    ext_TabSel_Other_ShowDocValue0 = (bool)value;
                    break;
                case "ext_TabSel_Other_ShowDocValue1":

                    ext_TabSel_Other_ShowDocValue1 = (bool)value;
                    break;
                case "ext_TabSel_Other_ShowDocValue2":

                    ext_TabSel_Other_ShowDocValue2 = (bool)value;
                    break;
                case "ext_TabSel_Other_DeviceID":

                    ext_TabSel_Other_DeviceID = (string)value;
                    break;

                //====== int_GoodListView_
                case "ext_GoodListView_GoodName_IsVivsible":

                    ext_GoodListView_GoodName_IsVivsible = (bool)value;
                    break;

                case "ext_GoodListView_UnitName_IsVivsible":

                    ext_GoodListView_UnitName_IsVivsible = (bool)value;
                    break;

                case "ext_GoodListView_GoodDescription_IsVivsible":

                    ext_GoodListView_GoodDescription_IsVivsible = (bool)value;
                    break;
                case "ext_GoodListView_GoodSerial_IsVivsible":

                    ext_GoodListView_GoodSerial_IsVivsible = (bool)value;
                    break;
                case "ext_GoodListView_GoodQuality_IsVivsible":

                    ext_GoodListView_GoodQuality_IsVivsible = (bool)value;
                    break;
                case "ext_GoodListView_GoodAmount_IsVivsible":

                    ext_GoodListView_GoodAmount_IsVivsible = (bool)value;
                    break;
                case "ext_GoodListView_GoodAmountAquired_IsVivsible":

                    ext_GoodListView_GoodAmountAquired_IsVivsible = (bool)value;
                    break;
                case "ext_GoodListView_Value0_IsVivsible":

                    ext_GoodListView_Value0_IsVivsible = (bool)value;
                    break;
                case "ext_GoodListView_Value1_IsVivsible":

                    ext_GoodListView_Value1_IsVivsible = (bool)value;
                    break;
                case "ext_GoodListView_Value2_IsVivsible":

                    ext_GoodListView_Value2_IsVivsible = (bool)value;
                    break;

                case "ext_GoodListView_GoodName_Width":

                    ext_GoodListView_GoodName_Width = (string)value;
                    break;
                case "ext_GoodListView_UnitName_Width":

                    ext_GoodListView_UnitName_Width = (string)value;
                    break;
                case "ext_GoodListView_GoodDescription_Width":

                    ext_GoodListView_GoodDescription_Width = (string)value;
                    break;
                case "ext_GoodListView_GoodSerial_Width":

                    ext_GoodListView_GoodSerial_Width = (string)value;
                    break;
                case "ext_GoodListView_GoodQuality_Width":

                    ext_GoodListView_GoodQuality_Width = (string)value;
                    break;
                case "ext_GoodListView_GoodAmount_Width":

                    ext_GoodListView_GoodAmount_Width = (string)value;
                    break;
                case "ext_GoodListView_GoodAmountAquired_Width":

                    ext_GoodListView_GoodAmountAquired_Width = (string)value;
                    break;
                case "ext_GoodListView_Value0_Width":

                    ext_GoodListView_Value0_Width = (string)value;
                    break;
                case "ext_GoodListView_Value1_Width":

                    ext_GoodListView_Value1_Width = (string)value;
                    break;
                case "ext_GoodListView_Value2_Width":

                    ext_GoodListView_Value2_Width = (string)value;
                    break;

                default:

                    break;
            }
            return;
        }
        protected object GetByIndex(string ind)
        {
            switch (ind)
            {
                case "ext_Address":
                    return ext_Address;

                case "ext_Login":

                    return ext_Login;

                case "ext_Password":

                    return ext_Password;

                case "ext_Timeout":

                    return ext_Timeout;

                case "ext_DelayBetweenAnalyzingFrames":

                    return ext_DelayBetweenAnalyzingFrames;

                case "ext_InitialDelayBeforeAnalyzingFrames":

                    return ext_InitialDelayBeforeAnalyzingFrames;

                case "ext_DelayBetweenContinuousScans":

                    return ext_DelayBetweenContinuousScans;

                case "ext_Autofocus":

                    return ext_Autofocus;

                case "ext_AutofocusDelay":

                    return ext_AutofocusDelay;

                case "ext_UseNativeScanning":

                    return ext_UseNativeScanning;
                case "ext_PureBarcode":

                    return ext_PureBarcode;
                case "ext_TryHarder":

                    return ext_TryHarder;
                case "ext_ScanHardWare":

                    return ext_ScanHardWare;
                case "ext_Torch":

                    return ext_Torch;

                //===== ext_bk_format_
                case "ext_bk_format_All_1D":

                    return ext_bk_format_All_1D;

                case "ext_bk_format_AZTEC":

                    return ext_bk_format_AZTEC;

                case "ext_bk_format_CODABAR":

                    return ext_bk_format_CODABAR;

                case "ext_bk_format_EAN_8":

                    return ext_bk_format_EAN_8;

                case "ext_bk_format_EAN_13":

                    return ext_bk_format_EAN_13;

                case "ext_bk_format_CODE_128":

                    return ext_bk_format_CODE_128;

                case "ext_bk_format_CODE_39":

                    return ext_bk_format_CODE_39;

                case "ext_bk_format_CODE_93":

                    return ext_bk_format_CODE_93;

                case "ext_bk_format_DATA_MATRIX":

                    return ext_bk_format_DATA_MATRIX;

                case "ext_bk_format_IMB":

                    return ext_bk_format_IMB;

                case "ext_bk_format_ITF":

                    return ext_bk_format_ITF;

                case "ext_bk_format_MAXICODE":

                    return ext_bk_format_MAXICODE;

                case "ext_bk_format_MSI":

                    return ext_bk_format_MSI;

                case "ext_bk_format_PDF_417":

                    return ext_bk_format_PDF_417;

                case "ext_bk_format_PLESSEY":

                    return ext_bk_format_PLESSEY;

                case "ext_bk_format_QR_CODE":

                    return ext_bk_format_QR_CODE;

                case "ext_bk_format_RSS_14":

                    return ext_bk_format_RSS_14;

                case "ext_bk_format_RSS_EXPANDED":

                    return ext_bk_format_RSS_EXPANDED;

                case "ext_bk_format_UPC_A":

                    return ext_bk_format_UPC_A;

                case "ext_bk_format_UPC_E":

                    return ext_bk_format_UPC_E;

                case "ext_bk_format_UPC_EAN_EXTENSION":

                    return ext_bk_format_UPC_EAN_EXTENSION;

                case "ext_IntentExtra":

                    return ext_IntentExtra;

                case "ext_IntentFilter":

                    return ext_IntentFilter;
                case "ext_SupervisorPassword":

                    return ext_SupervisorPassword;
                
                    //===== ext_TabSel_Other_

                case "ext_TabSel_Other_ShowCharacteristic":

                    return ext_TabSel_Other_ShowCharacteristic;
                    
                case "ext_TabSel_Other_ShowSerial":

                    return ext_TabSel_Other_ShowSerial;
                    
                case "ext_TabSel_Other_ShowValues":

                    return ext_TabSel_Other_ShowValues;

                case "ext_TabSel_Other_ShowDocValue0":

                    return ext_TabSel_Other_ShowDocValue0;

                case "ext_TabSel_Other_ShowDocValue1":

                    return ext_TabSel_Other_ShowDocValue1;

                case "ext_TabSel_Other_ShowDocValue2":

                    return ext_TabSel_Other_ShowDocValue2;
                case "ext_TabSel_Other_DeviceID":

                    return ext_TabSel_Other_DeviceID;

                //====== int_GoodListView_
                case "ext_GoodListView_GoodName_IsVivsible":

                    return ext_GoodListView_GoodName_IsVivsible;
                case "ext_GoodListView_UnitName_IsVivsible":

                    return ext_GoodListView_UnitName_IsVivsible;
                case "ext_GoodListView_GoodDescription_IsVivsible":

                    return ext_GoodListView_GoodDescription_IsVivsible;
                case "ext_GoodListView_GoodSerial_IsVivsible":

                    return ext_GoodListView_GoodSerial_IsVivsible;
                case "ext_GoodListView_GoodQuality_IsVivsible":

                    return ext_GoodListView_GoodQuality_IsVivsible;
                case "ext_GoodListView_GoodAmount_IsVivsible":

                    return ext_GoodListView_GoodAmount_IsVivsible;
                case "ext_GoodListView_GoodAmountAquired_IsVivsible":

                    return ext_GoodListView_GoodAmountAquired_IsVivsible;
                case "ext_GoodListView_Value0_IsVivsible":

                    return ext_GoodListView_Value0_IsVivsible;
                case "ext_GoodListView_Value1_IsVivsible":

                    return ext_GoodListView_Value1_IsVivsible;
                case "ext_GoodListView_Value2_IsVivsible":

                    return ext_GoodListView_Value2_IsVivsible;
                case "ext_GoodListView_GoodName_Width":

                    return ext_GoodListView_GoodName_Width;
                case "ext_GoodListView_UnitName_Width":

                    return ext_GoodListView_UnitName_Width;
                case "ext_GoodListView_GoodDescription_Width":

                    return ext_GoodListView_GoodDescription_Width;
                case "ext_GoodListView_GoodSerial_Width":

                    return ext_GoodListView_GoodSerial_Width;
                case "ext_GoodListView_GoodQuality_Width":

                    return ext_GoodListView_GoodQuality_Width;
                case "ext_GoodListView_GoodAmount_Width":

                    return ext_GoodListView_GoodAmount_Width;
                case "ext_GoodListView_GoodAmountAquired_Width":

                    return ext_GoodListView_GoodAmountAquired_Width;
                case "ext_GoodListView_Value0_Width":

                    return ext_GoodListView_Value0_Width;
                case "ext_GoodListView_Value1_Width":

                    return ext_GoodListView_Value1_Width;
                case "ext_GoodListView_Value2_Width":

                    return ext_GoodListView_Value2_Width;

                default:

                    return null;
            }
        }
    }

}
