﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PerformanceAPI.Models;

namespace PerformanceAPI.Gateway
{
	public class GateWayClass
	{
		readonly string connectionString = "Data Source=it380federated.database.windows.net;Initial Catalog = Federated; User ID = orangeteam; Password=orange380!;Connect Timeout = 30; Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		//This will call the stored procedure for the PredictionsSummaryReport model
		public IEnumerable<PredictionSummaryReportModel> GetDataForPredictionSummaryReportModel()
		{
			// makes a list to store each record from the database whihc are loaded into the model
			List<PredictionSummaryReportModel> predictionSummaryReportModelList = new List<PredictionSummaryReportModel>();

			//makes the connection
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				//makes the command for the stored procedure
				//and sets its type
				// IMPORTANT! the string neeeds to match the name of the stored procedure exactly
				SqlCommand cmd = new SqlCommand("GetDataForProjectionsReportModel", con)
				{
					CommandType = CommandType.StoredProcedure
				};
				//opens the connection
				con.Open();
				//executes the stored procedure
				SqlDataReader dr = cmd.ExecuteReader();
				//creates the model objexts for each row and adds them to the list
				while (dr.Read())
				{
					//instantiates a new model
					PredictionSummaryReportModel psrModel = new PredictionSummaryReportModel();
					//IMPORTANT! the text after DR needs to match the column name in the data base exactly
					psrModel.EmployeeID = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString());
					psrModel.FirstName = dr["E_FIRST_NAME"].ToString();
					psrModel.MiddleName = dr["E_MIDDLE_INTIAL"].ToString();
					psrModel.LastName = dr["E_LAST_NAME"].ToString();
					psrModel.ProjectedPR = dr["PR_PROJECTION"].ToString();
					psrModel.CurrentPosition = dr["POSITION_NAME"].ToString();
					psrModel.ProjectedPosition = dr["PROJECTED_POSITION"].ToString();
					psrModel.CurrentSalary = Convert.ToDouble(dr["PAY_AMOUNT"].ToString());
					psrModel.SalaryIncrease = Convert.ToDouble(dr["SALARY_INCREASE_PROJECTION"].ToString());
					psrModel.Supervisor = Convert.ToInt32(dr["SUPERVISOR_ID"].ToString());
					psrModel.DateOfProjection = dr["DATE_OF_PROJECTION"].ToString();

					//adds the model with the records data in it to the list
					predictionSummaryReportModelList.Add(psrModel);
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
			//returns the list of models
			return predictionSummaryReportModelList;
		}

		public IEnumerable<EmployeeModel> GetDataForEmployeeNameDropDown()
		{
			// makes a list to store each record from the database which are loaded into the model
			List<EmployeeModel> employeeModelList = new List<EmployeeModel>();

			//makes the connection
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				//makes the command for the stored procedure
				//and sets its type
				// IMPORTANT! the string neeeds to match the name of the stored procedure exactly
				SqlCommand cmd = new SqlCommand("GetEmployeeLastAndFirst", con)
				{
					CommandType = CommandType.StoredProcedure
				};
				//opens the connection
				con.Open();
				//executes the stored procedure
				SqlDataReader dr = cmd.ExecuteReader();
				//creates the model objexts for each row and adds them to the list
				while (dr.Read())
				{
					//instantiates a new model
					EmployeeModel employeeDetailModel = new EmployeeModel();
					//IMPORTANT! the text after DR needs to match the column name in the data base exactly
					employeeDetailModel.EmployeeLastName = dr["E_LAST_NAME"].ToString();
					employeeDetailModel.EmployeeFirstName = dr["E_FIRST_NAME"].ToString();

					//adds the model with the records data in it to the list
					employeeModelList.Add(employeeDetailModel);
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
			//returns the list of models
			return employeeModelList;
			;
		}

		//next method for a stored procedure goes here

	}
}
