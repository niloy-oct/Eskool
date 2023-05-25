using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Eskool.Helper
{
    public class Common
    {

        public static string GetSQLFormattedString(string[] arrayList)
        {
            var first = true;
            var stringBuilder = new StringBuilder();
            foreach (var item in arrayList)
            {
                if (first)
                    stringBuilder.Append($"'{item}'");
                else
                    stringBuilder.Append($",'{item}'");

                first = false;
            };


            return stringBuilder.ToString();
        }

        public static string GetSQLFormattedNumber(string[] arrayList)
        {
            var first = true;
            var stringBuilder = new StringBuilder();
            foreach (var item in arrayList)
            {
                if (first)
                    stringBuilder.Append($"'{item}'");
                else
                    stringBuilder.Append($",'{item}'");

                first = false;
            };


            return stringBuilder.ToString();
        }
    }
}