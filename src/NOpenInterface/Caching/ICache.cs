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

namespace NOpenInterface.Caching
{
	using System;

	public interface ICache<in TCachingPolicy> where TCachingPolicy : class
	{
		bool Add(string key, object value, TCachingPolicy cachingPolicy = null, Action<dynamic> onEviction = null);

		T Get<T>(string key) where T : class;

		Object this[string key] { get; }

		void Remove(string key);
	}
}