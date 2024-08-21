using EmployeeAdminPortal3.Data;
using EmployeeAdminPortal3.Models.Dto;
using EmployeeAdminPortal3.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal3.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerInfoController : ControllerBase
	{
		private readonly CustomerAppDbContext dbContext;

		public CustomerInfoController(CustomerAppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		// GetAllCustromerInfo Operations 
		[HttpGet]
		public IActionResult GetAllCustomerInfo()
		{
			var allCustormerInfo = dbContext.CustomerInfos.ToList();
			return Ok(allCustormerInfo);
		}

		//This is to get CustomerInfoById
		[HttpGet]
		[Route("{id:guid}")]
		public IActionResult GetCustomerInfoById(Guid id)
		{
			var customerById = dbContext.CustomerInfos.Find(id);

			//checking if customer is null or not
			if (customerById == null)
			{
				return NotFound("Sorry!Customer doesn't exit.");
			}

			return Ok(customerById);

		}

		// Post/Create operation/endpoints
		[HttpPost]
		public IActionResult AddCustomerInfo(AddCustomerInfoDto addCustomerInfoDto)
		{
			var addCustomerEntity = new CustomerInfo()
			{
				firstName = addCustomerInfoDto.customerFirstName,
				lastName = addCustomerInfoDto.customerLastName,
				Email = addCustomerInfoDto.customerEmail,
				Address = addCustomerInfoDto.customerAddress,
				Phone = addCustomerInfoDto.customerPhone,
			};

			dbContext.CustomerInfos.Add(addCustomerEntity);
			dbContext.SaveChanges();

			return Ok(addCustomerEntity);

		}

		//Creating Update operation
		[HttpPut]
		[Route("{id:guid}")]
		public IActionResult UpdateCustomerInfo(Guid id,UpdateCustomerInfoDto updateCustomerInfoDto)
		{
			var customerInfoToUpdate = dbContext.CustomerInfos.Find(id);

			//Checking if the customer is null or not
			if(customerInfoToUpdate == null)
			{
				return NotFound("Customer to update Not Found");
			}

			customerInfoToUpdate.firstName = updateCustomerInfoDto.customerFirstName;
			customerInfoToUpdate.lastName = updateCustomerInfoDto.customerLastName;
			customerInfoToUpdate.Email = updateCustomerInfoDto.customerEmail;
			customerInfoToUpdate.Address = updateCustomerInfoDto.customerAddress;
			customerInfoToUpdate.Phone = updateCustomerInfoDto.customerPhone;

			dbContext.SaveChanges();
			return Ok(customerInfoToUpdate);
			
		}

		//Creating Delete operation
		[HttpDelete]
		[Route("{id:guid}")]
		public IActionResult DeleteCustomerInfo(Guid id)
		{
			var customerInfoToDelete = dbContext.CustomerInfos.Find(id);

			//checking if customer is null or not
			if (customerInfoToDelete == null)
			{
				return NotFound("Cusmoter you want to DELETE not found.");
			}
			dbContext.CustomerInfos.Remove(customerInfoToDelete);
			dbContext.SaveChanges();

			return Ok("Customer is successfully Delete.");
		}
	}
}
