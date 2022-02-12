# CRUD
EF CORE CRUD

The migration commands need dotnet ef to be installed in your pc. If you do not have it then go to Tools ➤ NuGet Package Manager ➤ Package Manager Console and run the following command.
# PM> dotnet tool install --global dotnet-ef

Worth Mentioning – If you already had dotnet ef installed then it should be updated to the latest version. Run the following update command to do this job.
# PM> dotnet tool update --global dotnet-ef

Add Migration Command
The Add Migration command will create Migration files that store data from your entity classes.
# PM> add-migration Migration1


The migration command will create a folder named Migrations on the application root. This folder contains 3 files.

_.cs: It is the main migration file which includes migration operations named Up() and Down() methods. The Up method is responsible for creating DB objects while the Down method removes them.
_.Designer.cs: The migrations metadata file which contains some extra information.
ModelSnapshot.cs: A snapshot of your current model. This is used to determine what has changed when creating the next migration.


Update Migration Command
The Update Migration command will create the database based on the migration created by the Add migration command.
# PM> Update-Database


To update the database Client table so that it contains this new Address field. I add a new migration and name it Migration2. Next I run the update command.
# PM> dotnet ef migrations add Migration2
# PM> dotnet ef database update


Suppose some situation arises and you need to Revert the database to the previous state i.e. when the Client table does not have the Address field.
To do this, run the Update command for Migration1 (which is the previous migration).
# PM> dotnet ef database update Migration1
Now check the Client table once again and you will see the Address column is removed from it.


Remove Migration Command
With the Remove Migration command you can remove the last migration if it is not applied to the database.
You can execute either of the 2 command given below:
# PM> remove-migration

Drop Database
To drop the database use any of the following command.
# PM> Drop-Database

Generate SQL Script
You can also Generate SQL Script of the Database. To do this, execute either of the following 2 commands.
# PM> script-migration
The script command will generate a script for all the migrations by default. This generated db script can be executed to form a duplicate database if you have a requirement.

