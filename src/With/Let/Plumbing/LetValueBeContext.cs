﻿using System;
using System.Linq.Expressions;
using System.Linq;

namespace With.Let.Plumbing
{
	/// <summary>
	/// Sets the value of a property or a field and then resets that value when this class is disposed.
	/// </summary>
	public class LetValueBeContext<TObj,T> : IDisposable
	{
		private readonly PropertyOrField _property;
		private readonly object _oldvalue;

		public LetValueBeContext(TObj target, Expression<Func<TObj,T>> property, T value, bool allowSetReadonly)
		{
			var member = new ExpressionWithMemberAccess ().Tap (e => e.Lambda (property)).Member;
			_property = new PropertyOrField(target,member);
			if ( !allowSetReadonly && _property.IsReadonly ())
				throw new CantSetReadonlyException ();

			_oldvalue = _property.GetMemberValue();
			_property.SetMemberValue(value);
		}

		public LetValueBeContext(Expression<Func<T>> property, T value, bool allowSetReadonly)
		{
			object target = null;
			var expression = new ExpressionWithMemberAccessMightBeFromConstant().Tap (e => e.Lambda (property));
			var member = expression.Member;
			if (expression.Members.Count () > 1) 
			{
				Object targetFrom = expression.ConstantValue;
				for (int i = 0; i < expression.Members.Count()-1; i++) {
					targetFrom = new PropertyOrField (targetFrom, expression.Members[i]).GetMemberValue();					
				}
				target = targetFrom;
			}
			_property = new PropertyOrField(target, member);
			if ( !allowSetReadonly && _property.IsReadonly ())
				throw new CantSetReadonlyException ();

			_oldvalue = _property.GetMemberValue();
			_property.SetMemberValue(value);
		}

		public void Dispose()
		{
			_property.SetMemberValue(_oldvalue);
		}
	}
}

