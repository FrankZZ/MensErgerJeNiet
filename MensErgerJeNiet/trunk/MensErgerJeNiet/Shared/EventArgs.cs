using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Shared
{
	class EventArgs<EventType, ValueType> : EventArgs<EventType>
	{
		private ValueType _value;

		public EventArgs(EventType eEvent, ValueType eValue) : base(eEvent)
		{
			_value = eValue;
		}

		public ValueType Value
		{
			get
			{
				return _value;
			}
		}

	}

	class EventArgs<EventType> : EventArgs
	{
		private EventType _event;

		public EventArgs(EventType eEvent)
		{
			_event = eEvent;
		}

		public EventType Event
		{
			get
			{
				return _event;
			}
		}

	}

}
