//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version:1.2.30703.27
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace WinFSCRM {
    using System;
    using MSAvalon.Windows.Controls;
    using MSAvalon.Windows.Documents;
    using MSAvalon.Windows.Shapes;
    using MSAvalon.Windows.Media;
    using MSAvalon.Windows.Navigation;
    using MSAvalon.Windows.Data;
    using MSAvalon.Windows;
    using MSAvalon.Windows.Controls.Primitives;
    using MSAvalon.Windows.Media.Animation;
    
    
    /// <summary>
    /// ClientInformation
    /// </summary>
    public partial class ClientInformation : MSAvalon.Windows.Controls.FlowPanel {
        
        protected internal MSAvalon.Windows.Controls.TextBox displayName;
        
        protected internal MSAvalon.Windows.Controls.TextBox givenName;
        
        protected internal MSAvalon.Windows.Controls.TextBox surname;
        
        protected internal MSAvalon.Windows.Controls.TextBox imAddress;
        
        protected internal MSAvalon.Windows.Controls.TextBox provider;
        
        protected internal MSAvalon.Windows.Controls.TextBox addressLine;
        
        protected internal MSAvalon.Windows.Controls.TextBox city;
        
        protected internal MSAvalon.Windows.Controls.TextBox postalCode;
        
        protected internal MSAvalon.Windows.Controls.TextBox country;
        
        protected internal MSAvalon.Windows.Controls.TextBox email;
        
        protected internal MSAvalon.Windows.Controls.TextBox areaCode;
        
        protected internal MSAvalon.Windows.Controls.TextBox number;
        
        /// <summary>
        /// ClientInformation ctor Parent overload
        /// </summary>
        public ClientInformation(MSAvalon.Threading.UIContext context) : 
                base(context) {
            this._InitializeThis();
        }
        
        /// <summary>
        /// ClientInformation ctor
        /// </summary>
        public ClientInformation() {
            this._InitializeThis();
        }
        
        private WinFSCRM.MyApp Application {
            get {
                return ((WinFSCRM.MyApp)(MSAvalon.Windows.Application.Current));
            }
        }
        
        private void _InitializeThis() {
            MSAvalon.Windows.Controls.FlowPanel _FlowPanel_1_ = this;
            ((MSAvalon.Windows.Serialization.ILoaded)(_FlowPanel_1_)).DeferLoad();
            _FlowPanel_1_.Width = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            _FlowPanel_1_.Height = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            MSAvalon.Windows.Documents.Table _Table_2_ = new MSAvalon.Windows.Documents.Table();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Table_2_)).DeferLoad();
            _Table_2_.Width = new MSAvalon.Windows.Length(100, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_FlowPanel_1_)).AddChild(_Table_2_);
            MSAvalon.Windows.Documents.Column _Column_3_ = new MSAvalon.Windows.Documents.Column();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Column_3_)).DeferLoad();
            _Column_3_.Width = new MSAvalon.Windows.Length(25, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Table_2_)).AddChild(_Column_3_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_Column_3_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Column _Column_4_ = new MSAvalon.Windows.Documents.Column();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Column_4_)).DeferLoad();
            _Column_4_.Width = new MSAvalon.Windows.Length(25, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Table_2_)).AddChild(_Column_4_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_Column_4_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Column _Column_5_ = new MSAvalon.Windows.Documents.Column();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Column_5_)).DeferLoad();
            _Column_5_.Width = new MSAvalon.Windows.Length(25, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Table_2_)).AddChild(_Column_5_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_Column_5_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Column _Column_6_ = new MSAvalon.Windows.Documents.Column();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Column_6_)).DeferLoad();
            _Column_6_.Width = new MSAvalon.Windows.Length(25, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Table_2_)).AddChild(_Column_6_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_Column_6_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Body _Body_7_ = new MSAvalon.Windows.Documents.Body();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Body_7_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Table_2_)).AddChild(_Body_7_);
            MSAvalon.Windows.Documents.Row _Row_8_ = new MSAvalon.Windows.Documents.Row();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_8_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Body_7_)).AddChild(_Row_8_);
            MSAvalon.Windows.Documents.Cell _Cell_9_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_9_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_8_)).AddChild(_Cell_9_);
            MSAvalon.Windows.Controls.Text _Text_10_ = new MSAvalon.Windows.Controls.Text();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_10_)).DeferLoad();
            _Text_10_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Text_10_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_9_)).AddChild(_Text_10_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Text_10_)).AddText("Display Name");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_10_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_9_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_11_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_11_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_8_)).AddChild(_Cell_11_);
            MSAvalon.Windows.Controls.TextBox _TextBox_12_ = new MSAvalon.Windows.Controls.TextBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_12_)).DeferLoad();
            this.displayName = _TextBox_12_;
            _TextBox_12_.ID = "displayName";
            _TextBox_12_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _TextBox_12_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _TextBox_12_.Width = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_11_)).AddChild(_TextBox_12_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_12_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_11_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_8_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Row _Row_13_ = new MSAvalon.Windows.Documents.Row();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_13_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Body_7_)).AddChild(_Row_13_);
            MSAvalon.Windows.Documents.Cell _Cell_14_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_14_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_13_)).AddChild(_Cell_14_);
            MSAvalon.Windows.Controls.Text _Text_15_ = new MSAvalon.Windows.Controls.Text();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_15_)).DeferLoad();
            _Text_15_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Text_15_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_14_)).AddChild(_Text_15_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Text_15_)).AddText("Given Name");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_15_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_14_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_16_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_16_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_13_)).AddChild(_Cell_16_);
            MSAvalon.Windows.Controls.TextBox _TextBox_17_ = new MSAvalon.Windows.Controls.TextBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_17_)).DeferLoad();
            this.givenName = _TextBox_17_;
            _TextBox_17_.ID = "givenName";
            _TextBox_17_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _TextBox_17_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _TextBox_17_.Width = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_16_)).AddChild(_TextBox_17_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_17_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_16_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_18_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_18_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_13_)).AddChild(_Cell_18_);
            MSAvalon.Windows.Controls.Text _Text_19_ = new MSAvalon.Windows.Controls.Text();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_19_)).DeferLoad();
            _Text_19_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Text_19_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_18_)).AddChild(_Text_19_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Text_19_)).AddText("Surname");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_19_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_18_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_20_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_20_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_13_)).AddChild(_Cell_20_);
            MSAvalon.Windows.Controls.TextBox _TextBox_21_ = new MSAvalon.Windows.Controls.TextBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_21_)).DeferLoad();
            this.surname = _TextBox_21_;
            _TextBox_21_.ID = "surname";
            _TextBox_21_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _TextBox_21_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _TextBox_21_.Width = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_20_)).AddChild(_TextBox_21_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_21_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_20_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_13_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Row _Row_22_ = new MSAvalon.Windows.Documents.Row();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_22_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Body_7_)).AddChild(_Row_22_);
            MSAvalon.Windows.Documents.Cell _Cell_23_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_23_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_22_)).AddChild(_Cell_23_);
            MSAvalon.Windows.Controls.Text _Text_24_ = new MSAvalon.Windows.Controls.Text();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_24_)).DeferLoad();
            _Text_24_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Text_24_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_23_)).AddChild(_Text_24_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Text_24_)).AddText("IM Address");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_24_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_23_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_25_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_25_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_22_)).AddChild(_Cell_25_);
            MSAvalon.Windows.Controls.TextBox _TextBox_26_ = new MSAvalon.Windows.Controls.TextBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_26_)).DeferLoad();
            this.imAddress = _TextBox_26_;
            _TextBox_26_.ID = "imAddress";
            _TextBox_26_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _TextBox_26_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _TextBox_26_.Width = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_25_)).AddChild(_TextBox_26_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_26_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_25_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_27_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_27_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_22_)).AddChild(_Cell_27_);
            MSAvalon.Windows.Controls.Text _Text_28_ = new MSAvalon.Windows.Controls.Text();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_28_)).DeferLoad();
            _Text_28_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Text_28_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_27_)).AddChild(_Text_28_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Text_28_)).AddText("IM Provider");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_28_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_27_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_29_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_29_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_22_)).AddChild(_Cell_29_);
            MSAvalon.Windows.Controls.TextBox _TextBox_30_ = new MSAvalon.Windows.Controls.TextBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_30_)).DeferLoad();
            this.provider = _TextBox_30_;
            _TextBox_30_.ID = "provider";
            _TextBox_30_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _TextBox_30_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _TextBox_30_.Width = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_29_)).AddChild(_TextBox_30_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_30_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_29_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_22_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Row _Row_31_ = new MSAvalon.Windows.Documents.Row();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_31_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Body_7_)).AddChild(_Row_31_);
            MSAvalon.Windows.Documents.Cell _Cell_32_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_32_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_31_)).AddChild(_Cell_32_);
            MSAvalon.Windows.Controls.Text _Text_33_ = new MSAvalon.Windows.Controls.Text();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_33_)).DeferLoad();
            _Text_33_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Text_33_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_32_)).AddChild(_Text_33_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Text_33_)).AddText("Address");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_33_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_32_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_34_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_34_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_31_)).AddChild(_Cell_34_);
            MSAvalon.Windows.Controls.TextBox _TextBox_35_ = new MSAvalon.Windows.Controls.TextBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_35_)).DeferLoad();
            this.addressLine = _TextBox_35_;
            _TextBox_35_.ID = "addressLine";
            _TextBox_35_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _TextBox_35_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _TextBox_35_.Width = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_34_)).AddChild(_TextBox_35_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_35_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_34_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_36_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_36_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_31_)).AddChild(_Cell_36_);
            MSAvalon.Windows.Controls.Text _Text_37_ = new MSAvalon.Windows.Controls.Text();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_37_)).DeferLoad();
            _Text_37_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Text_37_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_36_)).AddChild(_Text_37_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Text_37_)).AddText("City");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_37_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_36_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_38_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_38_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_31_)).AddChild(_Cell_38_);
            MSAvalon.Windows.Controls.TextBox _TextBox_39_ = new MSAvalon.Windows.Controls.TextBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_39_)).DeferLoad();
            this.city = _TextBox_39_;
            _TextBox_39_.ID = "city";
            _TextBox_39_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _TextBox_39_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _TextBox_39_.Width = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_38_)).AddChild(_TextBox_39_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_39_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_38_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_31_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Row _Row_40_ = new MSAvalon.Windows.Documents.Row();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_40_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Body_7_)).AddChild(_Row_40_);
            MSAvalon.Windows.Documents.Cell _Cell_41_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_41_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_40_)).AddChild(_Cell_41_);
            MSAvalon.Windows.Controls.Text _Text_42_ = new MSAvalon.Windows.Controls.Text();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_42_)).DeferLoad();
            _Text_42_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Text_42_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_41_)).AddChild(_Text_42_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Text_42_)).AddText("Postal Code");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_42_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_41_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_43_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_43_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_40_)).AddChild(_Cell_43_);
            MSAvalon.Windows.Controls.TextBox _TextBox_44_ = new MSAvalon.Windows.Controls.TextBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_44_)).DeferLoad();
            this.postalCode = _TextBox_44_;
            _TextBox_44_.ID = "postalCode";
            _TextBox_44_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _TextBox_44_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _TextBox_44_.Width = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_43_)).AddChild(_TextBox_44_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_44_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_43_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_45_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_45_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_40_)).AddChild(_Cell_45_);
            MSAvalon.Windows.Controls.Text _Text_46_ = new MSAvalon.Windows.Controls.Text();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_46_)).DeferLoad();
            _Text_46_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Text_46_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_45_)).AddChild(_Text_46_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Text_46_)).AddText("Country");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_46_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_45_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_47_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_47_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_40_)).AddChild(_Cell_47_);
            MSAvalon.Windows.Controls.TextBox _TextBox_48_ = new MSAvalon.Windows.Controls.TextBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_48_)).DeferLoad();
            this.country = _TextBox_48_;
            _TextBox_48_.ID = "country";
            _TextBox_48_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _TextBox_48_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _TextBox_48_.Width = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_47_)).AddChild(_TextBox_48_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_48_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_47_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_40_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Row _Row_49_ = new MSAvalon.Windows.Documents.Row();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_49_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Body_7_)).AddChild(_Row_49_);
            MSAvalon.Windows.Documents.Cell _Cell_50_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_50_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_49_)).AddChild(_Cell_50_);
            MSAvalon.Windows.Controls.Text _Text_51_ = new MSAvalon.Windows.Controls.Text();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_51_)).DeferLoad();
            _Text_51_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Text_51_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_50_)).AddChild(_Text_51_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Text_51_)).AddText("Email");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_51_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_50_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_52_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_52_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_49_)).AddChild(_Cell_52_);
            MSAvalon.Windows.Controls.TextBox _TextBox_53_ = new MSAvalon.Windows.Controls.TextBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_53_)).DeferLoad();
            this.email = _TextBox_53_;
            _TextBox_53_.ID = "email";
            _TextBox_53_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _TextBox_53_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _TextBox_53_.Width = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_52_)).AddChild(_TextBox_53_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_53_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_52_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_49_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Row _Row_54_ = new MSAvalon.Windows.Documents.Row();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_54_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Body_7_)).AddChild(_Row_54_);
            MSAvalon.Windows.Documents.Cell _Cell_55_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_55_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_54_)).AddChild(_Cell_55_);
            MSAvalon.Windows.Controls.Text _Text_56_ = new MSAvalon.Windows.Controls.Text();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_56_)).DeferLoad();
            _Text_56_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Text_56_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_55_)).AddChild(_Text_56_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Text_56_)).AddText("Area Code");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_56_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_55_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_57_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_57_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_54_)).AddChild(_Cell_57_);
            MSAvalon.Windows.Controls.TextBox _TextBox_58_ = new MSAvalon.Windows.Controls.TextBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_58_)).DeferLoad();
            this.areaCode = _TextBox_58_;
            _TextBox_58_.ID = "areaCode";
            _TextBox_58_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _TextBox_58_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _TextBox_58_.Width = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_57_)).AddChild(_TextBox_58_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_58_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_57_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_59_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_59_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_54_)).AddChild(_Cell_59_);
            MSAvalon.Windows.Controls.Text _Text_60_ = new MSAvalon.Windows.Controls.Text();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_60_)).DeferLoad();
            _Text_60_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _Text_60_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_59_)).AddChild(_Text_60_);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Text_60_)).AddText("Number");
            ((MSAvalon.Windows.Serialization.ILoaded)(_Text_60_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_59_)).EndDeferLoad();
            MSAvalon.Windows.Documents.Cell _Cell_61_ = new MSAvalon.Windows.Documents.Cell();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_61_)).DeferLoad();
            ((MSAvalon.Windows.Serialization.IAddChild)(_Row_54_)).AddChild(_Cell_61_);
            MSAvalon.Windows.Controls.TextBox _TextBox_62_ = new MSAvalon.Windows.Controls.TextBox();
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_62_)).DeferLoad();
            this.number = _TextBox_62_;
            _TextBox_62_.ID = "number";
            _TextBox_62_.FontSize = new MSAvalon.Windows.FontSize(16, MSAvalon.Windows.FontSizeType.Pixel);
            _TextBox_62_.FontWeight = MSAvalon.Windows.FontWeight.Bold;
            _TextBox_62_.Width = new MSAvalon.Windows.Length(30, MSAvalon.Windows.UnitType.Percent);
            ((MSAvalon.Windows.Serialization.IAddChild)(_Cell_61_)).AddChild(_TextBox_62_);
            ((MSAvalon.Windows.Serialization.ILoaded)(_TextBox_62_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Cell_61_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Row_54_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Body_7_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_Table_2_)).EndDeferLoad();
            ((MSAvalon.Windows.Serialization.ILoaded)(_FlowPanel_1_)).EndDeferLoad();
        }
    }
}