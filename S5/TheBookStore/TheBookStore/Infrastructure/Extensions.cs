using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBookStore.DataTransferObjects;
using TheBookStore.Models;

namespace TheBookStore.Infrastructure
{
    public static class Extensions
    {
        public static string AsString(this IEnumerable<BookAuthorsDto> authors)
        {
            var list = String.Empty;

            for (int i = 0; i < authors.Count(); i++)
            {
                list += authors.ElementAt(i).FullName;

                if (i < authors.Count() - 1)
                {
                    list += " and ";
                }
            }

            return list;
        }

        public static string Flatten(this BookDto book)
        {
            var flatBook = new
            {
                Id = book.Id,
                Title = book.Title.Escaped(),
                Authors = book.Authors.AsString().Escaped()
            };

            return string.Format("{0},{1},{2}", flatBook.Id, flatBook.Title, flatBook.Authors);

        }


        static char[] _specialChars = new char[] { ',', '\n', '\r', '"' };
        private static string Escaped(this object o)
        {
            if (o == null)
            {
                return "";
            }
            string field = o.ToString();
            if (field.IndexOfAny(_specialChars) != -1)
            {
                return String.Format("\"{0}\"", field.Replace("\"", "\"\""));
            }
            else return field;
        }

    }
}