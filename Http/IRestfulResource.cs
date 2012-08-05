namespace Rbi.Infrastructure.Http
{
    /// <summary>
    /// NOTE: URI/controller naming convention is the plural of the noun describing the resource (e.g. 'Purchases'/'PurchasesController'.)
    /// </summary>
    public interface IRestfulResource
    {
        /// <summary>
        /// The GET method means retrieve whatever information (in the form of an entity) is identified by the Request-URI. 
        /// </summary>
        ActionResult Get();

        ActionResult Get(string resourceId);

        /// <summary>
        /// The PUT method requests that the enclosed entity be stored under the supplied Request-URI. If the Request-URI refers to an already existing resource, the enclosed entity SHOULD be considered as a modified version of the one residing on the origin server.
        /// </summary>
        ActionResult Put(dynamic entityModel);
        
        /// <summary>
        /// The POST method is used to request that the origin server accept the entity enclosed in the request as a new subordinate of the resource identified by the Request-URI in the Request-Line.
        /// </summary>
        ActionResult Post(dynamic entityModel);
        
        /// <summary>
        /// The HEAD method is identical to GET except that the server MUST NOT return a message-body in the response.
        /// </summary>
        ActionResult Head();

        ActionResult Head(string resourceId);

        /// <summary>
        /// The DELETE method requests that the origin server delete the resource identified by the Request-URI.
        /// </summary>
        /// <returns></returns>
        ActionResult Delete();
        
        /// <summary>
        /// This method allows the client to determine the options and/or requirements associated with a resource, or the capabilities of a server, without implying a resource action or initiating a resource retrieval.
        /// </summary>
        /// <returns>
        /// Minimally, the response should be a 200 OK and have an Allow header with a list of HTTP methods that may be used on this resource. 
        /// </returns>
        ActionResult Options();

        /// <summary>
        /// The TRACE method is used to invoke a remote, application-layer loop- back of the request message.
        /// </summary>
        ActionResult Trace();
        
        /// <summary>
        /// This specification reserves the method name CONNECT for use with a proxy that can dynamically switch to being a tunnel (e.g. SSL tunneling.)
        /// </summary>
        /// <returns></returns>
        ActionResult Connect();
    }
}