using BindableProps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppReadOnlyProperty
{
    public partial class AxPage : ContentPage
    {
        // Manual read-only bindable property definition
        //public static readonly BindablePropertyKey SizePropertyKey = BindableProperty.CreateReadOnly(nameof(Size), typeof(SizeF), typeof(AxPage), SizeF.Zero, BindingMode.OneWayToSource);
        //public static readonly BindableProperty SizeProperty = SizePropertyKey.BindableProperty;
        //public SizeF Size
        //{
        //    get => (SizeF)GetValue(SizeProperty);
        //    private set => SetValue(SizePropertyKey, value);
        //}

        // Generated read-only property definition (with proper binding mode as default)
        [BindableReadOnlyProp]
        SizeF _size;

        /// <summary>
        /// Current page is landscape
        /// </summary>
        [BindableReadOnlyProp]
        bool _isLandscape = false;

        protected override void OnSizeAllocated(double width, double height)
        {
            Size = new SizeF(Convert.ToSingle(width), Convert.ToSingle(height));
            IsLandscape = width > height;
            base.OnSizeAllocated(width, height);
        }
    }
}
