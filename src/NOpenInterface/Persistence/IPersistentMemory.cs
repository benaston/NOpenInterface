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

namespace NOpenInterface.Persistence
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	/// <summary>
	/// 	NOTE: BA; possibly expose as IPersistenceStrategy <TRoot>and IRetrievalStrategy
	/// 	                                                  	<TRoot>, these can be IOC'd up with
	/// 	                                                  		the relevant cache/local/remote db calls built in.
	/// 	                                                  		e.g. profile information might be persistent locally,
	/// 	                                                  		whilst domain object persistence might be sent
	/// 	                                                  		Responsible for defining the interface for types that provide
	/// 	                                                  		access to functionality to persist and retrieve objects to/from
	/// 	                                                  		long-term storage.
	/// </summary>
	public interface IPersistentMemory //rename to repository?
	{
		string Save<T>(T @object) where T : IAggregateRoot, ISerializable; //is ISerializable needed here?

		T Retrieve<T>(string id) where T : IAggregateRoot;

		IEnumerable<T> Retrieve<T>(string[] id) where T : IAggregateRoot;
	}
}