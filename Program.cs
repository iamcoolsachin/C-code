using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication1
{
    static class Program
    {


        static void Main(string[] args)
        {

            Weberrors myenym = Weberrors.PipelineFailure;
            Console.WriteLine("   " + myenym.GetDescription());

        }
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }

            }
            return null;

        }

    }
}


public enum Weberrors
{
    [Description("The remote service could not be contacted at the transport level.")]
    ConnectFailure,
    [Description("The connection was closed prematurely.")]
    ConnectionClosed,
    [Description("The server closed a connection made with the Keep-alive header set.")]
    KeepAliveFailure,
    [Description("The name service could not resolve the host name.")]
    NameResolutionFailure,
    [Description("The response received from the server was complete but indicated an error at the protocol level.")]
    ProtocolError,
    [Description("A complete response was not received from the remote server.")]
    ReceiveFailure,
    [Description("The request was canceled.")]
    RequestCanceled,
    [Description("An error occurred in a secure channel link.")]
    SecureChannelFailure,
    [Description("A complete request could not be sent to the remote server.")]
    SendFailure,
    [Description("The server response was not a valid HTTP response.")]
    ServerProtocolViolation,
    [Description("No error was encountered.")]
    Success,
    [Description("No response was received within the time-out set for the request.")]
    Timeout,
    [Description("A server certificate could not be validated.")]
    TrustFailure,
    [Description("A message was received that exceeded the specified limit when sending a request or receiving a response from the server.")]
    MessageLengthLimitExceeded,
    [Description("An internal asynchronous request is pending.")]
    Pending,
    [Description("This value supports the .NET Framework infrastructure and is not intended to be used directly in your code.")]
    PipelineFailure,
    [Description("The name resolver service could not resolve the proxy host name.")]
    ProxyNameResolutionFailure,
    [Description("An exception of unknown type has occurred.")]
    UnknownError,
}

