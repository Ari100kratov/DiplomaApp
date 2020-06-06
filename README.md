# Информационная система управления проектами

> Проект реализован в рамках дипломной работы по специальности "Программирование в компьютерных системах" и является совокупностью знаний платформы .Net Framework на тот момент. также впервые использовал систему управления версиями GIT.

![Форма управления сотрудниками](https://github.com/Ari100kratov/DiplomaApp/blob/master/Файлы/Сотрудники.PNG)

## Технологии/Фреймворки

> ### Backend
Проект разработан на платформе _.Net Framework_ с использованием языка программирования __C#__. Используемая база данных - __MS SQL Server__ и для взаимодействия с ней разработана прослойка, схожая по функциональности с EF (пример кода указан ниже). __Использование:__ необходима сущность сопоставимая с таблицей и отдельная модель репозитория, в которой по необходимости расширяются CRUD-операции. Да, получился велосипед, но простой и быстрый.
Для общения клиента и сервера используется платформа __WCF (Windows Communication Foundation)__, которая запускается как отдельный консольный проект.

> ### Frontend
Для разработки UI выбрана платформа __WPF (Windows Presentation Foundation)__, использующая расширяемый язык разметки для приложений __XAML__. Для более удобного и привлекательного интерфейса задействованы __дополнительные компоненты DevExpress__.

## Пример кода - реализация взаимодействия с базой данных

```C#

using ModelParametersLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelParametersLibrary.Attributes;

namespace GenericRepositoryLibrary
{
    public class BaseRepository<T> where T : IKeyedModel, new()
    {
        private string TableName { get; }
        private List<T> ListEntities = new List<T>();
        public string ConnectionString => DataManager.Connection;

        public BaseRepository()
        {
            this.TableName = typeof(T).Name;
            this.FillList();
        }

        public virtual List<T> GetList()
        {
            return this.ListEntities;
        }

        private void FillList()
        {
            var da = new SqlDataAdapter($"SELECT * FROM [{this.TableName}]", new SqlConnection(this.ConnectionString));
            var dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var item = new T();
                var properties = typeof(T).GetProperties();

                foreach (var prop in properties)
                {
                    if (dt.Columns.Contains(prop.Name))
                    {
                        var fieldName = prop.Name;
                        var fieldValue = dr[fieldName] == DBNull.Value ? null : dr[fieldName];

                        prop.SetValue(item, fieldValue);
                    }
                }

                this.ListEntities.Add(item);
            }
        }

        public virtual int Add(T item)
        {
            var query = $"INSERT INTO [{TableName}](";
            var valuesQuery = $" VALUES (";
            var fieldLst = new List<string>();
            var valueLst = new List<object>();
            var cmd = new SqlCommand();

            var type = item.GetType();
            var properties = type.GetProperties();

            foreach (var prop in properties)
            {
                if (!System.Attribute.IsDefined(prop, typeof(PrimaryKey))
                     && System.Attribute.IsDefined(prop, typeof(FieldDb)))
                {
                    var value = prop.GetValue(item);

                    if (value == null)
                    {
                        continue;
                    }

                    fieldLst.Add(prop.Name);
                    valueLst.Add(value);

                    query += $"{prop.Name}, ";
                    valuesQuery += $"@{prop.Name}, ";
                }
            }

            query = query.Remove(query.Length - 2, 1) + ")";
            valuesQuery = valuesQuery.Remove(valuesQuery.Length - 2, 1) + ")";

            var fullQuery = query + valuesQuery;
            cmd.CommandText = $"{fullQuery} ;SELECT SCOPE_IDENTITY();";

            for (var i = 0; i < fieldLst.Count; i++)
            {
                cmd.Parameters.AddWithValue($"@{fieldLst[i]}", valueLst[i]);
            }

            int lastId = Convert.ToInt32(this.SaveChanges(cmd));
            item.Id = lastId;
            this.ListEntities.Add(item);
            return lastId;
        }


        public virtual void Delete(int id)
        {
            var cmd = new SqlCommand($"DELETE FROM {this.TableName} WHERE Id = @Id");
            cmd.Parameters.AddWithValue("@Id", id);

            this.SaveChanges(cmd);
            var item = this.ListEntities.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                this.ListEntities.Remove(item);
            }
        }

        public virtual void Delete(T item)
        {
            var cmd = new SqlCommand($"DELETE FROM [{this.TableName}] WHERE Id = @Id");
            cmd.Parameters.AddWithValue("@Id", item.Id);

            this.SaveChanges(cmd);
            var searchItem = this.ListEntities.FirstOrDefault(x => x.Id == item.Id);

            if (searchItem != null)
            {
                this.ListEntities.Remove(searchItem);
            }
        }

        public virtual void Update(T item)
        {
            var query = $"UPDATE [{TableName}] SET ";
            var fieldLst = new List<string>();
            var valueLst = new List<object>();
            var cmd = new SqlCommand();

            var type = item.GetType();
            var properties = type.GetProperties();

            foreach (var prop in properties)
            {
                if (!System.Attribute.IsDefined(prop, typeof(PrimaryKey))
                     && System.Attribute.IsDefined(prop, typeof(FieldDb)))
                {
                    var value = prop.GetValue(item) ?? DBNull.Value;

                    fieldLst.Add(prop.Name);
                    valueLst.Add(value);

                    query += $"{prop.Name} = @{prop.Name}, ";
                }
            }

            query = query.Remove(query.Length - 2, 1);

            cmd.CommandText = $"{query} WHERE Id = @Id;";

            for (var i = 0; i < fieldLst.Count; i++)
            {
                cmd.Parameters.AddWithValue($"@{fieldLst[i]}", valueLst[i]);
            }
            cmd.Parameters.AddWithValue("@Id", item.Id);

            this.SaveChanges(cmd);

            var searchItem = this.ListEntities.FirstOrDefault(x => x.Id == item.Id);
            var index = this.ListEntities.IndexOf(searchItem);
            if (index == -1)
            {
                return;
            }
            this.ListEntities[index] = item;
        }
        

        private object SaveChanges(SqlCommand cmd)
        {
            using (var con = new SqlConnection(this.ConnectionString))
            {
                cmd.Connection = con;
                con.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}

```
