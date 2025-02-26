USE [TaskNBS_DB]
GO
/****** Object:  Table [dbo].[EmployeeDetails]    Script Date: 2/12/2022 5:40:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDetails](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [varchar](30) NULL,
	[EmployeeSalary] [varchar](30) NULL,
	[EmployeeDOJ] [varchar](30) NULL,
	[EmployeeGender] [varchar](30) NULL,
	[EmployeeProfile] [varchar](max) NULL,
	[IsActive] [bit] NULL,
	[AddedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[proc_DataOperations]    Script Date: 2/12/2022 5:40:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- proc_DataOperations 'InsertEmployeeRecord','Mahima','10000','2022/02/12','1','Photo.jpg'

--=============================================================================================================================
CREATE PROC [dbo].[proc_DataOperations]
(
@ProcId VARCHAR(50),
@EmployeeId INT = 0,
@EmployeeName VARCHAR(30) = NULL,
@EmployeeSalary VARCHAR(30) = NULL,
@EmployeeDOJ VARCHAR(30) = NULL,
@EmployeeGender VARCHAR(30) = NULL,
@EmployeeProfile VARCHAR(MAX) = NULL

)
AS
BEGIN

	IF(@ProcId = 'InsertEmployeeRecord')
	BEGIN

		INSERT INTO [dbo].[EmployeeDetails] VALUES
		(
			LTRIM(RTRIM(@EmployeeName)), 
			LTRIM(RTRIM(@EmployeeSalary)), 
			LTRIM(RTRIM(@EmployeeDOJ)), 
			LTRIM(RTRIM(@EmployeeGender)), 
			LTRIM(RTRIM(@EmployeeProfile)), 
			LTRIM(RTRIM(1)), 
			LTRIM(RTRIM(GETDATE()))
		)

		SELECT '0' AS IsExist

	END

	IF(@ProcId = 'BindEmployeeRecord')
	BEGIN

		SELECT EmployeeId, EmployeeName, EmployeeSalary, CONVERT(VARCHAR(10), CAST(EmployeeDOJ AS DATETIME), 103) AS EmployeeDOJ, 
			   EmployeeGender, EmployeeProfile, IsActive, CONVERT(VARCHAR(10), AddedDate, 103) AS AddedDate 
	    FROM [dbo].[EmployeeDetails] WHERE IsActive = 1

	END

	IF(@ProcId = 'BindSingleEmployeeRecord')
	BEGIN

		SELECT EmployeeId, EmployeeName, EmployeeSalary, EmployeeDOJ ,--CONVERT(VARCHAR(10), CAST(EmployeeDOJ AS DATETIME), 103) AS EmployeeDOJ, 
			   EmployeeGender, EmployeeProfile, IsActive, CONVERT(VARCHAR(10), AddedDate, 103) AS AddedDate 
	    FROM [dbo].[EmployeeDetails] WHERE EmployeeId = LTRIM(RTRIM(@EmployeeId))

	END

	IF(@ProcId = 'UpdateEmployeeRecord')
	BEGIN

		UPDATE [dbo].[EmployeeDetails] 
		SET 
			EmployeeName = LTRIM(RTRIM(@EmployeeName)),
			EmployeeSalary = LTRIM(RTRIM(@EmployeeSalary)), 
			EmployeeDOJ = LTRIM(RTRIM(@EmployeeDOJ)),
			EmployeeGender = LTRIM(RTRIM(@EmployeeGender)),
			EmployeeProfile = CASE 
									WHEN @EmployeeProfile <> NULL THEN LTRIM(RTRIM(@EmployeeProfile)) 
									WHEN @EmployeeProfile <> '' THEN LTRIM(RTRIM(@EmployeeProfile)) 
									ELSE ( SELECT EmployeeProfile FROM [dbo].[EmployeeDetails] WHERE EmployeeId = LTRIM(RTRIM(@EmployeeId))) 
							  END 
		WHERE EmployeeId = LTRIM(RTRIM(@EmployeeId))

		SELECT '0' AS IsExist

	END

	IF(@ProcId = 'DeleteData')
	BEGIN

		UPDATE [dbo].[EmployeeDetails] SET IsActive = 0 WHERE EmployeeId = LTRIM(RTRIM(@EmployeeId))

	END
END
GO
