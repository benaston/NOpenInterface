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

	public delegate string[] CollectionPersistenceStrategyDelegate<in T>(IEnumerable<T> itemsToPersist) where T : IAggregateRoot, ISerializable;
}