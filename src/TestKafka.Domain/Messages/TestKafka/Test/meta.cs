// ------------------------------------------------------------------------------
// <auto-generated>
//    Generated by avrogen, version 1.7.7.5
//    Changes to this file may cause incorrect behavior and will be lost if code
//    is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Test
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using global::Avro;
	using global::Avro.Specific;
	
	public partial class meta : ISpecificRecord
	{
		public static Schema _SCHEMA = Schema.Parse(@"{""type"":""record"",""name"":""meta"",""namespace"":""Test"",""fields"":[{""name"":""infoData"",""type"":{""type"":""record"",""name"":""infoData"",""namespace"":""Test"",""fields"":[{""name"":""id"",""type"":""string""},{""name"":""correlationId"",""type"":""string""},{""name"":""domain"",""type"":""string""},{""name"":""action"",""type"":""string""},{""name"":""timestamp"",""type"":""int""}]}}]}");
		private Test.infoData _infoData;
		public virtual Schema Schema
		{
			get
			{
				return meta._SCHEMA;
			}
		}
		public Test.infoData infoData
		{
			get
			{
				return this._infoData;
			}
			set
			{
				this._infoData = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.infoData;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.infoData = (Test.infoData)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}