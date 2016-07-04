namespace ServiceWatchedClient
{
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using ServiceWatchedClient.ServiceReference1;

    /// <summary>
    /// 服务调用类。
    /// </summary>
    public static class ServiceHelper
    {
        private static BTMISServiceClient _serviceClient;
        /// <summary>
        /// 服务调用客户端.
        /// </summary>
        public static BTMISServiceClient ServiceClient
        {
            get
            {
                if (_serviceClient == null)
                {
                    if (ServicePointManager.ServerCertificateValidationCallback == null)
                        ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CertificatePolicy.ValidateServerCertificate);
                }

                return _serviceClient ?? (_serviceClient = new BTMISServiceClient("BasicHttpBinding_IBTMISService"));
            }
        }

        private static string _serviceAddress, _serverRootUri;
        /// <summary>
        /// 服务器服务地址.
        /// </summary>
        public static string ServiceAddress
        {
            get
            {
                if (_serviceAddress != null)
                    return _serviceAddress;

                _serviceAddress = ServiceClient.Endpoint.Address.Uri.AbsoluteUri;
                return _serviceAddress;
            }
        }

        /// <summary>
        /// 服务器网站地址.
        /// </summary>
        public static string ServerRootUri
        {
            get
            {
                if (_serverRootUri != null)
                {
                    return _serverRootUri;
                }
                _serverRootUri = ServiceAddress.Replace("BTMISService.svc", string.Empty);
                return _serverRootUri;
            }
        }
    }

    
    /// <summary>
    /// Certificate Policy.
    /// </summary>
    public class CertificatePolicy
    {
        // The following method is invoked by the RemoteCertificateValidationDelegate.
        /// <summary>
        /// Validates the server certificate.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="certificate">The certificate.</param>
        /// <param name="chain">The chain.</param>
        /// <param name="sslPolicyErrors">The SSL policy errors.</param>
        /// <returns></returns>
        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
            //if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors)
            //{
            //    foreach (X509ChainStatus chainStatus in chain.ChainStatus)
            //    {
            //        if (chainStatus.Status == X509ChainStatusFlags.Revoked)
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;
            //if (sslPolicyErrors == SslPolicyErrors.None) return true;
            //Console.WriteLine("Certificate error: {0}", sslPolicyErrors);
            // Do not allow this client to communicate with unauthenticated servers.
            //return false;
        }
    }
}
