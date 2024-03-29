// ------------------------------------------------------------------------------
// <auto-generated>
//    Generated by avrogen, version 1.7.7.5
//    Changes to this file may cause incorrect behavior and will be lost if code
//    is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Test
{
	using global::Avro;
	using global::Avro.Specific;
	
	public partial class infoData : ISpecificRecord
	{
		public static Schema _SCHEMA = Schema.Parse(@"{""type"":""record"",""name"":""infoData"",""namespace"":""Test"",""fields"":[{""name"":""id"",""type"":""string""},{""name"":""correlationId"",""type"":""string""},{""name"":""domain"",""type"":""string""},{""name"":""action"",""type"":""string""},{""name"":""timestamp"",""type"":""int""}]}");
		private string _id;
		private string _correlationId;
		private string _domain;
		private string _action;
		private int _timestamp;
		public virtual Schema Schema
		{
			get
			{
				return infoData._SCHEMA;
			}
		}
		public string id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}
		public string correlationId
		{
			get
			{
				return this._correlationId;
			}
			set
			{
				this._correlationId = value;
			}
		}
		public string domain
		{
			get
			{
				return this._domain;
			}
			set
			{
				this._domain = value;
			}
		}
		public string action
		{
			get
			{
				return this._action;
			}
			set
			{
				this._action = value;
			}
		}
		public int timestamp
		{
			get
			{
				return this._timestamp;
			}
			set
			{
				this._timestamp = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.id;
			case 1: return this.correlationId;
			case 2: return this.domain;
			case 3: return this.action;
			case 4: return this.timestamp;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.id = (System.String)fieldValue; break;
			case 1: this.correlationId = (System.String)fieldValue; break;
			case 2: this.domain = (System.String)fieldValue; break;
			case 3: this.action = (System.String)fieldValue; break;
			case 4: this.timestamp = (System.Int32)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}
