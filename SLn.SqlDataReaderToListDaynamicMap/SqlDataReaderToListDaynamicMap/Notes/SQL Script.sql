

USE [DevTemp]
GO

/****** Object:  Table [dbo].[PersonalInfo]    Script Date: 11/7/2017 1:08:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PersonalInfo](
	[PersonalInfoID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](100) NULL,
	[LastName] [nchar](100) NULL,
	[DateOfBirth] [datetime] NULL,
	[City] [nchar](50) NULL,
	[Country] [nchar](100) NULL,
	[MobileNo] [nchar](50) NULL,
	[NID] [nchar](100) NULL,
	[Email] [nchar](100) NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_PersonalInfo] PRIMARY KEY CLUSTERED 
(
	[PersonalInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




--Data Preparations
---Normal**********************************************
----truncate
truncate table Customers

---SQL loop insert
DECLARE @ID int;
SET @ID=0;
WHILE @ID < 100000
BEGIN
	insert into Customers values('Name 01','email01@gmail.com',1240,'Country','City')
	SET @ID = @ID + 1;
END



---Dynamic**********************************************
----truncate
truncate table Customers

---SQL loop insert
DECLARE @ID bigint;
DECLARE @Name varchar(250);
DECLARE @Email varchar(250);
DECLARE @ZipCode bigint;
DECLARE @Country varchar(250);
DECLARE @City varchar(250);

SET @ID=0;
SET @Name= CONVERT(varchar(250), @ID)  + ' Customer Name'
SET @Email= CONVERT(varchar(250), @ID)  + '@gmail.com'
SET @ZipCode= ABS(CAST(CAST(NEWID() AS VARBINARY) AS INT));
SET @Country= 'Country ' + CONVERT(varchar(250), @ID)
SET @City= 'City ' + CONVERT(varchar(250), @ID)

WHILE @ID < 100000
BEGIN
	insert into Customers values(@Name, @Email ,@ZipCode,@Country,@City)
	SET @ID = @ID + 1;
	SET @Name= CONVERT(varchar(10), @ID)  + ' Customer Name'
	SET @Email= CONVERT(varchar(10), @ID)  + '@gmail.com'
	SET @ZipCode=ABS(CAST(CAST(NEWID() AS VARBINARY) AS INT))
	SET @Country= 'Country ' + CONVERT(varchar(250), @ID)
	SET @City= 'City ' + CONVERT(varchar(250), @ID)
END























