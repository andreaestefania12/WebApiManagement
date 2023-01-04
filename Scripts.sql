use management;


CREATE TABLE CLIENT(
  id INT NOT NULL PRIMARY KEY identity(1,1),
  firstName VARCHAR(45) NOT NULL,
  lastName VARCHAR(45) NOT NULL,
  emailAddress VARCHAR(100) NOT NULL,
  phoneNumber VARCHAR(10) NOT NULL,
  status VARCHAR(10) NOT NULL,
  registrationDate DATE
 );


 ---- PROCEDIMIENTOS

 CREATE PROCEDURE saveClient(
	@firstName varchar(45),
	@lastName VARCHAR(45),
	@emailAddress VARCHAR(100),
	@phoneNumber VARCHAR(10),
	@status VARCHAR(10),
	@registrationDate DATE
 ) as begin
	INSERT INTO CLIENT(firstName,lastName,emailAddress,phoneNumber,status,registrationDate)
	VALUES (@firstName,@lastName,@emailAddress,@phoneNumber,@status,@registrationDate)
  end


 ---- PROCEDIMIENTOS

 CREATE PROCEDURE updateClient(
	@id int,
	@firstName varchar(45),
	@lastName VARCHAR(45),
	@emailAddress VARCHAR(100),
	@phoneNumber VARCHAR(10),
	@status VARCHAR(10)
 ) as begin
	UPDATE CLIENT SET 
	firstName = @firstName,
	lastName = @lastName,
	emailAddress = @emailAddress,
	phoneNumber = @phoneNumber,
	status = @status
	WHERE id = @id
  end

 CREATE PROCEDURE getAllClients as begin
	SELECT * FROM CLIENT;
  end


   CREATE PROCEDURE getClientById(@id int)
 as begin
	SELECT * FROM CLIENT WHERE id = @id;
  end

 CREATE PROCEDURE deleteClient(@id int)
 as begin
	DELETE FROM CLIENT WHERE id = @id;
  end
