using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppReadOnlyProperty
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        bool SetValue<T>([NotNullIfNotNull(nameof(newValue))] ref T field, T newValue, Action? onChanged = null, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }
            field = newValue;
            OnPropertyChanged(propertyName);
            onChanged?.Invoke();
            return true;
        }

        string title = "Default title";
        public string Title { get => title; set => SetValue(ref title, value); }


        SizeF size;
        public SizeF Size
        {
            get => size;
            set => SetValue(ref size, value, OnSizeChanged);
        }
        void OnSizeChanged()
        {
            if (Size == SizeF.Zero)
            {
                Title = "Unknown size";
            }
            else if (Size.Height > Size.Width)
            {
                Title = "Portrait";
            }
            else
            {
                Title = "Landscape";
            }

        }
    }
}
