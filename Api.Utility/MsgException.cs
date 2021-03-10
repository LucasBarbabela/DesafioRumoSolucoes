using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Api.Utility
{
    public enum MsgException
    {
        [Description("O número de busca não pode ser negativo!")]
        NegativeNumber = 1,
        [Description("O valor buscado não existe!")]
        SaleNotFound = 2,
        [Description("O objeto passado está com algum valor nulo!")]
        ObjectAtributeNull = 3,
        [Description("O Id de carro passado é inválido")]
        CarIdNotFound = 4
    }

    public static class MSGD
    {
        public static string GetDescription(System.Enum value)
        {
            var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            var descriptionAttribute =
                enumMember == null
                    ? default(DescriptionAttribute)
                    : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return
                descriptionAttribute == null
                    ? value.ToString()
                    : descriptionAttribute.Description;
        }
    }
}
