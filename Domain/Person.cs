using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace PropertyChangedDemo.Domain
{
    internal class Person1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private string name;
        
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    internal class Person2 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static readonly PropertyChangedEventArgs NameEventArgs = new PropertyChangedEventArgs("Name");

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(NameEventArgs);
                }
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null) { PropertyChanged(this, e); }
        }
    }


    internal class Person3 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            CheckPropertyName(propertyName);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [Conditional("DEBUG")]
        private void CheckPropertyName(string propertyName)
        {
            PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(this)[propertyName];
            if (propertyDescriptor == null)
            {
                throw new InvalidOperationException(string.Format(null,
                    "The property with the propertyName '{0}' doesn't exist.", propertyName));
            }
        }
    }


    internal class Person4 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static readonly string NamePropertyName = TypeManager.GetProperty<Person4>(x => x.Name).Name;
        
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(NamePropertyName);
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
