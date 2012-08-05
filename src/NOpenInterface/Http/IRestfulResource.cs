// Copyright 2012, Ben Aston (ben@bj.ma).
// 
// This file is part of NOpenInterface.
// 
// NOpenInterface is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// NOpenInterface is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with NOpenInterface. If not, see <http://www.gnu.org/licenses/>.

namespace NOpenInterface.Http
{
	/// <summary>
	/// 	NOTE: URI/controller naming convention is the plural of the noun describing the resource (e.g. 'Purchases'/'PurchasesController'.)
	/// </summary>
	public interface IRestfulResource<TResource, TActionResultBase>
	{
		/// <summary>
		/// 	The GET method means retrieve whatever information (in the form of an entity) is identified by the Request-URI.
		/// </summary>
		TActionResultBase Get();

		TActionResultBase Get(string resourceId);

		/// <summary>
		/// 	The PUT method requests that the enclosed entity be stored under the supplied Request-URI. If the Request-URI refers to an already existing resource, the enclosed entity SHOULD be considered as a modified version of the one residing on the origin server.
		/// </summary>
		TActionResultBase Put(dynamic dto);

		/// <summary>
		/// 	The POST method is used to request that the origin server accept the entity enclosed in the request as a new subordinate of the resource identified by the Request-URI in the Request-Line.
		/// </summary>
		TActionResultBase Post(dynamic dto);

		/// <summary>
		/// 	The HEAD method is identical to GET except that the server MUST NOT return a message-body in the response.
		/// </summary>
		TActionResultBase Head();

		TActionResultBase Head(dynamic dto);

		TActionResultBase Head(string resourceId);

		/// <summary>
		/// 	The DELETE method requests that the origin server delete the resource identified by the Request-URI.
		/// </summary>
		/// <returns> </returns>
		TActionResultBase Delete(string resourceId);
	}
}