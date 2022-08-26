using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCWebApplicationNew.Data;
using MVCWebApplicationNew.Models;
namespace MVCWebApplicationNew.Controllers;

public static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints(this IEndpointRouteBuilder routes)
    {
        //https://localhost:7284/api/Employee
        routes.MapGet("/api/Employee", async (MVCWebApplicationNewContext db) =>
        {
            return await db.Employee.ToListAsync();
        })
        .WithName("GetAllEmployees");

        //https://localhost:7284/api/Employee/get?EmpId=3
        routes.MapGet("/api/Employee/get", async (int EmpId, MVCWebApplicationNewContext db) =>
        {
            return await db.Employee.FindAsync(EmpId)
                is Employee model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetEmployeeById");

        //https://localhost:7284/api/Employee?EmpId=4
        //    {
        //        "EmpId": 1,
        //"Name":"ww",
        //"Department":"IT"
        //}
        routes.MapPut("/api/Employee", async ([FromQuery] int EmpId, [FromBody] Employee employee, MVCWebApplicationNewContext db) =>
        {
            var foundModel = await db.Employee.FindAsync(EmpId);

            if (foundModel is null)
            {
                return Results.NotFound("No records");
            }
            var data = await db.Employee.FirstOrDefaultAsync(x => x.EmpId == EmpId);
            if (data != null)
            {
                data.Name = employee.Name;
                data.Department = employee.Department;
            }

            await db.SaveChangesAsync();

            return Results.Ok("Modified");
        })
        .WithName("UpdateEmployee");

        //https://localhost:7284/api/Employee
        //    {
        //        "EmpId": 1,
        //"Name":"ww",
        //"Department":"IT"
        //}

        routes.MapPost("/api/Employee/", async (Employee employee, MVCWebApplicationNewContext db) =>
        {
            db.Employee.Add(employee);
            await db.SaveChangesAsync();
            return Results.Created($"/Employees/{employee.EmpId}", employee);
        })
        .WithName("CreateEmployee");

        //https://localhost:7284/api/Employee?EmpId=2
        routes.MapDelete("/api/Employee", async (int EmpId, MVCWebApplicationNewContext db) =>
        {
            if (await db.Employee.FindAsync(EmpId) is Employee employee)
            {
                db.Employee.Remove(employee);
                await db.SaveChangesAsync();
                return Results.Ok(employee);
            }

            return Results.NotFound();
        })
        .WithName("DeleteEmployee");
    }
}
