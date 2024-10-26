using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SpecializedProps.Model;

namespace SpecializedProps
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Подключение к БД.
        public static SpecializedPropsEntities context = new SpecializedPropsEntities();

        // Вошедший пользователь.
        public static User currentUser;
    }
}
