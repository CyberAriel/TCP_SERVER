using ASPNET_MVC_ChartsDemo.Models;

using DisplayDataExample.Code;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace ASPNET_MVC_ChartsDemo.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			var student = new Student()
			{
				Name = "Sandeep Singh Shekhawat",
				Age = 24,
				City = "Jaipur"
			};
			ViewData["Student"] = student;
			return View();
		}

		public ContentResult CSV()
		{
			List<DataPoint> dataPoints = new List<DataPoint>();

			dataPoints.Add(new DataPoint(new DateTime(2016, 01, 01), new double[] { 656.289978, 657.719971, 547.179993, 587.000000 }));
			dataPoints.Add(new DataPoint(new DateTime(2016, 02, 01), new double[] { 578.150024, 581.799988, 474.000000, 552.520020 }));
			dataPoints.Add(new DataPoint(new DateTime(2016, 03, 01), new double[] { 556.289978, 603.239990, 538.580017, 593.640015 }));
			dataPoints.Add(new DataPoint(new DateTime(2016, 04, 01), new double[] { 590.489990, 669.979980, 585.250000, 659.590027 }));
			dataPoints.Add(new DataPoint(new DateTime(2016, 05, 01), new double[] { 663.919983, 724.229980, 656.000000, 722.789978 }));
			dataPoints.Add(new DataPoint(new DateTime(2016, 06, 01), new double[] { 720.900024, 731.500000, 682.119995, 715.619995 }));
			dataPoints.Add(new DataPoint(new DateTime(2016, 07, 01), new double[] { 717.320007, 766.000000, 716.539978, 758.809998 }));
			dataPoints.Add(new DataPoint(new DateTime(2016, 08, 01), new double[] { 759.869995, 774.979980, 750.349976, 769.159973 }));
			dataPoints.Add(new DataPoint(new DateTime(2016, 09, 01), new double[] { 770.900024, 839.950012, 756.000000, 837.309998 }));
			dataPoints.Add(new DataPoint(new DateTime(2016, 10, 01), new double[] { 836.000000, 847.210022, 774.609985, 789.820007 }));
			dataPoints.Add(new DataPoint(new DateTime(2016, 11, 01), new double[] { 799.000000, 800.840027, 710.099976, 750.570007 }));
			dataPoints.Add(new DataPoint(new DateTime(2016, 12, 01), new double[] { 752.409973, 782.460022, 736.700012, 768.659973 }));

			string csv = "";

			foreach (DataPoint DataPoint in dataPoints)
			{
				csv += DataPoint.X.ToString("yyyy-MM-dd");
				foreach (double Y in DataPoint.Y)
					csv += "," + Y.ToString();
				csv += "\n";
			}

			return Content(csv);
		}
	}
}