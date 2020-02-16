# VMS
Vehicle Management System

This project is based on two parts. 

One Serer side of the project is based on dotnet core 3.1 latest version and C#. Server side has been built using Asp.net Core Web Project. 
Server side implements EF Core with In Memory SQL provider imnplementation which very similar to SQL Server backend but you don't have to install it to run this. 
There are also many other industry standards design considerations and best practices in place for these project which make this project scalable for the Production environment. 

It also contains React ClientApp folder has all the required files for running the React frontend. 

Second part is based on React create application front end. It has been integrated with Asp.net Core Web Project in a very specific way as mention in the requirement doc which enables it to be run either directly from the Visual Studio 2019 ofc F5 or from npm command prompt.


# React - Kick start sample 


Please follow the steps to start dev-server which is configured to use port 44393

1. Run npm install 

2. npm start 

3. See the results in browser at https://localhost:44393/
