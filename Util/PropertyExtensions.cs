using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Util
{
    public static class PropertyExtensions
    {
        public static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static T GetPropValue<T>(this Object obj, String name)
        {
            Object retval = GetPropValue(obj, name);
            if (retval == null) { return default(T); }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }

        public static void SetPropValue(this Object obj, String name, Object value)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return; }

                Type t = Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType;

                if (t.Equals(typeof(DateTime)) && value != null && value.ToString().Contains("}"))
                    value = value.ToString().Replace("{", "").Replace("}", "");

                object safeValue = (value == null) ? null : Convert.ChangeType(value, t);

                info.SetValue(obj, safeValue, null);
            }
        }

        public static void SetPropValue(this Object obj, String name, Object value, List<string> listErrorParse)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return; }



                Type t = Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType;

                if (t.Equals(typeof(DateTime)) && value != null && value.ToString().Contains("}"))
                    value = value.ToString().Replace("{", "").Replace("}", "");

                var retornoTryParse = false;

                if (t == typeof(double))
                {
                    if (value != "")
                    {
                        var saida = 0.0;
                        retornoTryParse = double.TryParse(value.ToString(), out saida);
                    }
                    else
                    {
                        value = null;
                    }
                }
                else if (t == typeof(int))
                {
                    if (value != "")
                    {
                        var saida = 0;
                        retornoTryParse = int.TryParse(value.ToString(), out saida);
                    }
                    else
                    {
                        value = null;
                    }
                }
                else if (t == typeof(DateTime))
                {
                    if (value != "")
                    {
                        var saida = new DateTime();
                        retornoTryParse = DateTime.TryParse(value.ToString(), out saida);
                    }
                    else
                    {
                        value = null;
                    }
                }
                else
                {
                    retornoTryParse = true;
                }

                object safeValue = null;

                if (value != null)
                {
                    if (retornoTryParse)
                        safeValue = Convert.ChangeType(value, t);
                    else
                        listErrorParse.Add($"Erro na conversão da propiedade {part}");

                    info.SetValue(obj, safeValue, null);
                }
            }
        }

        public static List<T> ClasseApartirObjetoAnonimo<T>(object[] lista, Type type)
        {
            List<T> listaResult = new List<T>();

            foreach (var objeto in lista as object[])
            {
                listaResult.Add(ClasseApartirObjetoAnonimo<T>(objeto, type));
            }

            return listaResult;
        }

        public static T ClasseApartirObjetoAnonimo<T>(object objetoAnonimo, Type type)
        {
            var fields = type.GetProperties();

            var objetoResultado = Activator.CreateInstance(type);

            var properties = objetoAnonimo.GetType().GetProperties();

            foreach (var field in fields)
            {
                try
                {
                    if (properties.Any(x => x.Name == field.Name))
                    {
                        var valorObjeto = properties.First(x => x.Name == field.Name).GetValue(objetoAnonimo);

                        PropertyExtensions.SetPropValue(objetoResultado, field.Name, valorObjeto);
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException($"Erro ao preencher valor no objeto resultante. {e.Message}");
                }
            }

            return (T)objetoResultado;
        }
        /// <summary>
        /// Filtra as propriedades do objeto, retirando campos que tenham NotMapped ou Virtual
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetFilteredProperties(this Type type)
        {
            //Tira as propriedades com o atributo notMapped ou virtual
            return type.GetProperties().Where(pi => pi.GetCustomAttributes(typeof(NotMappedAttribute), true).Length == 0 && !pi.GetMethod.IsVirtual).ToArray();
        }

        /// <summary>
        /// Retorna o display name da propriedade do objeto (faz a tratativa se é um displayattribute ou um displaynameattribute)
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Object obj, string propertyName)
        {
            var type = obj.GetType();
            var member = type.GetMember(propertyName);

            DisplayAttribute displayAttribute = (DisplayAttribute)member[0].GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();
            if (displayAttribute != null)
            {
                return displayAttribute.Name;
            }
            DisplayNameAttribute displayname = (DisplayNameAttribute)member[0].GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault();

            if (displayname != null)
            {
                return displayname.DisplayName;
            }

            return propertyName;
        }
    }
}


