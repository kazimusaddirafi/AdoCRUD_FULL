create database adopractice1

use adopractice1

create table Departments(
Id int primary key identity(1,1),
Name varchar(50)
)

create table Employees(
	Id int primary key identity(1,1),
	Name varchar(50),
	Pin varchar(50) unique,
	IsActive BIT,
	DeptId int not null,
	Foreign Key (DeptId) References Departments(Id)
)

---Create Department

Go
Create Procedure spCreateDepartment(@Name varchar(50))
as
Begin
	Insert into Departments (Name)
	Values(@Name)
End

Exec spCreateDepartment @Name="HR"


---Get Department

Go
Create Procedure spGetDepartments
as
Begin
	Select * From Departments
End

Exec spGetDepartments

----Create employee

Go
Create Procedure spCreateEmployee(@Name varchar(50),@Pin varchar(50),@IsActive BIT, @DeptId int)
as
Begin
	Insert into Employees(Name,Pin,IsActive,DeptId)
	Values(@Name,@Pin,@IsActive,@DeptId)
End

Exec spCreateEmployee @Name="Test1", @Pin="25870", @IsActive=true, @DeptId=2

---Get all employee

Go
Create Procedure spGetAllEmployee
as
Begin
	Select e.Id, e.Name,e.Pin,e.IsActive, d.Name as DepartmentName
	From Employees e
	Inner Join Departments d on d.Id=e.DeptId
End

Exec spGetAllEmployee


---Update---

Go
Create Procedure spUpdateEmployee(@Id int,@Name varchar(50),@Pin varchar(50),@IsActive BIT, @DeptId int)
as
Begin
	Update Employees set Name=@Name,Pin=@Pin,IsActive=@IsActive,DeptId=@DeptId
	where Id=@Id
End

Exec spUpdateEmployee @Id=2, @Name="Newww11", @Pin="25879", @IsActive=true, @DeptId=2


---Delete

Go
Create Procedure spDeleteEmployee(@Id int)
as
Begin
	Delete Employees
	Where Id=@Id
End

Exec spDeleteEmployee @Id=4



---Employee Details

Go
Create Procedure spEmployeeDetails(@Id int)
as
Begin
	Select e.Id, e.Name,e.Pin,e.IsActive, d.Name as DepartmentName, d.Id as DeptId
	From Employees e
	Inner Join Departments d on d.Id=e.DeptId
	Where e.Id=@Id
End

Exec spEmployeeDetails @Id=1


----Dashboard
GO
CREATE PROCEDURE spEmployeeCountByDepartment
AS
BEGIN
    SELECT d.Name AS DepartmentName, COUNT(e.Id) AS EmployeeCount
    FROM Departments d
    LEFT JOIN Employees e ON d.Id = e.DeptId
    GROUP BY d.Name;
END;

Exec spEmployeeCountByDepartment
