using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StankoserviceEnums
{
    public enum StatusProject
    {
        Подготовка = 0,
        Проектирование,
        Реализация,
        Тестирование,
        Внедрение,
        Сопровождение,
        Завершен,
        Отложен,
        Закрыт
    }

    public enum StatusTask
    {
        Принята = 0,
        Отклонена,
        Выполнена,
        Подтверждается
    }

    public enum TypePeriod
    {
        Краткосрочный = 0,
        Среднесрочный,
        Долгосрочный
    }

    public enum Role
    {
        Директор = 0,
        Менеджер,
        Сотрудник
    }
}
