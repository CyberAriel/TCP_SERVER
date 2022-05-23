using System;
using System.Runtime.Serialization;

namespace ASPNET_MVC_ChartsDemo.Models
{
	//DataContract for Serializing Data - required to serve in JSON format
	[DataContract]
	public class DataPoint
	{
		public DataPoint(DateTime x, double[] y)
		{
			this.X = x;
			this.Y = y;
		}

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "x")]
		public DateTime X;

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public double[] Y = null;
	}
}