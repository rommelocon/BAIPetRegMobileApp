using BAIPetRegMobileApp.Handlers;
using System.Diagnostics;
using System.Net.Security;
using Xamarin.Android.Net;

namespace BAIPetRegMobileApp.Platforms.Android;
public class AndroidHttpMessageHandler : IPlatformHttpMessageHandler
{
    public HttpMessageHandler GetHttpMessageHandler() => new AndroidMessageHandler
    {
        ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
        {
            Debug.WriteLine($"Certificate Issuer: {certificate?.Issuer}");
            Debug.WriteLine($"SSL Policy Errors: {sslPolicyErrors}");
            return certificate?.Issuer == "CN=Microsoft Azure RSA TLS Issuing CA 07, O=Microsoft Corporation, C=US" || sslPolicyErrors == SslPolicyErrors.None;
        },
    };
}
