﻿Alter PROCEDURE Proc_Employee_Details
	(@NAME VARCHAR (100) ,
    @DESIGNATION_ID INT ,
    @GENDER VARCHAR (1) ,
    @DEPARTMENT_ID INT ,
    @EXPERIENCE     NUMERIC (4, 2),
    @SKILLS       VARCHAR (500),
    @EMAIL_ID    VARCHAR (100),
    @CONTACT_NUMBER VARCHAR (20),
    @SUPERVISOR_ID  INT  ,
    @DATE_OF_BIRTH  DATETIME2 (7) ,
    @ADDRESS        VARCHAR (500),
    @INSERTED_BY    VARCHAR (50),
    @INSERTED_ON    DATETIME2 (7),
    @UPDATED_BY     VARCHAR (50), 
    @UPDATED_ON    DATETIME2 (7))
AS

begin
 

	insert into TT_EMPLOYEE(ID,NAME,DESIGNATION_ID,GENDER,DEPARTMENT_ID,EXPERIENCE,SKILLS,EMAIL_ID, 
	 CONTACT_NUMBER, SUPERVISOR_ID, DATE_OF_BIRTH ,ADDRESS ,  INSERTED_BY  , INSERTED_ON ,  UPDATED_BY ,
     UPDATED_ON) values(@ID,@NAME,@DESIGNATION_ID,@GENDER,@DEPARTMENT_ID,@EXPERIENCE,@SKILLS,@EMAIL_ID,
	 @CONTACT_NUMBER,@SUPERVISOR_ID,@DATE_OF_BIRTH ,@ADDRESS,@INSERTED_BY,@INSERTED_ON,@UPDATED_BY,@UPDATED_ON )



end
