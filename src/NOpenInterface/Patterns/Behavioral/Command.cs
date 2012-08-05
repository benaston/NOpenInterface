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

namespace NOpenInterface.Patterns.Behavioral
{
	using System;

	public abstract class Command<TResult> : ICommand<TResult>
	{
		private readonly dynamic _args;
		private readonly Func<TResult, TResult> _success;
		private readonly Func<TResult, TResult> _fail;

		protected Command(dynamic args = null, Func<TResult, TResult> success = null, Func<TResult, TResult> fail = null) {
			_args = args;
			_success = success;
			_fail = fail;
		}

		public abstract TResult Execute();
	}
}