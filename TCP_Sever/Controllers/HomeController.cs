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
			string data = string.Empty;
			MyTcpListener.Instance.Show(ref data);
			var student = new Student()
			{

				Name = data,
				Age = 24,
				City = "Jaipur"
			};
			ViewData["Student"] = student;
			return View();
		}

		public ContentResult CSV()
		{
			List<DataPoint> dataPoints = new List<DataPoint>();

			dataPoints.Add(new DataPoint(new DateTime(2016, 01, 01), new double[] { 656, 657, 547, 587 }));
			

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