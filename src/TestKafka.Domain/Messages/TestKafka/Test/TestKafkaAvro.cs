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

    public partial class TestKafkaAvro : ISpecificRecord
	{
		public static Schema _SCHEMA = Schema.Parse(@"{""type"":""record"",""name"":""TestKafkaAvro"",""namespace"":""Test"",""fields"":[{""name"":""data"",""type"":{""type"":""record"",""name"":""data"",""namespace"":""Test"",""fields"":[{""name"":""publishedTime"",""type"":""string""}]}},{""name"":""meta"",""type"":{""type"":""record"",""name"":""meta"",""namespace"":""Test"",""fields"":[{""name"":""infoData"",""type"":{""type"":""record"",""name"":""infoData"",""namespace"":""Test"",""fields"":[{""name"":""id"",""type"":""string""},{""name"":""correlationId"",""type"":""string""},{""name"":""domain"",""type"":""string""},{""name"":""action"",""type"":""string""},{""name"":""timestamp"",""type"":""int""}]}}]}}]}");
		private Test.data _data;
		private Test.meta _meta;
		public virtual Schema Schema
		{
			get
			{
				return TestKafkaAvro._SCHEMA;
			}
		}
		public Test.data data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}
		public Test.meta meta
		{
			get
			{
				return this._meta;
			}
			set
			{
				this._meta = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.data;
			case 1: return this.meta;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.data = (Test.data)fieldValue; break;
			case 1: this.meta = (Test.meta)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}
