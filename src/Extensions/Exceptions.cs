using System;
//using System.Reflection;
using ate.Extensions;

namespace ate.Extensions
{
    public static class Exceptions
    {


        public static AppException Log(this Exception Exception)
        {
            if (!Exception.IsInstanceOf(typeof(AppException)))
            {
                Console.WriteLine(Exception.FullMessage());
                System.Diagnostics.Debug.WriteLine(Exception.FullMessage());
                return new AppException("", Exception);
            }
            else
            {
                return (AppException)Exception;
            }

        }

        public static string FullMessage(this Exception Exception)
        {
            string message = "";
            if (Exception != null)
            {
                if (Exception.InnerException != null)
                {
                    message = Exception.InnerException.FullMessage() + Environment.NewLine;
                }
                message += Exception.Message + Environment.NewLine + Exception.StackTrace;
            }
            return message;
        }

        public static string InnerMessage(this Exception Exception)
        {

            if (Exception.InnerException == null)
            {
                return Exception.Message;
            }
            else
            {
                return Exception.InnerException.InnerMessage();
            }

        }

    }

    public class AppException : Exception
    {
        public AppException()
        {

        }

        public AppException(string message) : base(message)
        { }

        public AppException(string message, Exception innerException) : base(message, innerException)
        {

        }

    }

}