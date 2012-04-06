using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Shared
{
	class EventArgs<EventType, ValueType> : EventArgs<ValueType>
	{
		private EventType _event;

		public EventArgs(EventType eEvent, ValueType eValue) : base(eValue)
		{
			this._event = eEvent;
		}

		public EventType Event
		{
			get
			{
				return _event;
			}
		}

	}

	class EventArgs<ValueType> : EventArgs
	{
		private ValueType _value;

		public EventArgs(ValueType value)
		{
			_value = value;
		}

		public ValueType Value
		{
			get
			{
				return _value;
			}
		}

	}

}
