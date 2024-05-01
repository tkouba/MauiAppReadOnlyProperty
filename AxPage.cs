using BindableProps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppReadOnlyProperty
{
    public partial class AxPage : ContentPage
    {
        public static readonly BindablePropertyKey SizePropertyKey = BindableProperty.CreateReadOnly(nameof(Size), typeof(SizeF), typeof(AxPage), SizeF.Zero);
        public static readonly BindableProperty SizeProperty = SizePropertyKey.BindableProperty;

        public SizeF Size
        {
            get => (SizeF)GetValue(SizeProperty);
            private set => SetValue(SizePropertyKey, value);
        }

        [BindableProp]
        bool _isLandscape = false; // <-- this property should also be read-only

        protected override void OnSizeAllocated(double width, double height)
        {
            Size = new SizeF(Convert.ToSingle(width), Convert.ToSingle(height));
            IsLandscape = width > height;
            base.OnSizeAllocated(width, height);
        }
    }
}
