# BrewCRAFT / project

> Warehouse management project application BrewCRAFT is a simple demonstration of database based application that lets store and update data in database with the help of stored procedures.

## About the project
The main intetnion was to have some fun with creating UI in XAML and understanding the logic of WPF and buttons, events.
<br> We have increased our teamowork skill as well as learned WPF logic and how to work with data using WPF and SqlServer.

## Setup
The application requires a database to store the data. Follow the below steps to setup database.

1.       Run the script 'MagazynBazaSkrypt.sql' to create and populate database (MS SQL SERVER is required)

2.       Set the connection string

   i.        Open po_project.sln (Visual Studio is required)

   ii.       Open Helper.cs and change "DESKTOP-FOQ5J3H" to your SqlServer Name in 
   <br> `@"Data Source=DESKTOP-FOQ5J3H;Initial Catalog=Magazyn;Integrated Security=True"`

   iii.      Go to server explorer and connect app with Magazyn.dbo
   
## Technologies Used
- .NET WPF
- Microsoft.Data.SqlClient
- C#
- T-SQL
- XAML

## Screenshots

#### Login screen
![loginscreen](https://user-images.githubusercontent.com/98351892/172948320-36952274-a262-4f85-b238-12220f500b9b.PNG)

#### Main window
![mainscreen](https://user-images.githubusercontent.com/98351892/172947815-46b151d7-e2f2-45c4-83a0-14478db08c01.PNG)

#### Content window
![pagescreen](https://user-images.githubusercontent.com/98351892/172948330-179617a5-be16-4d25-afb6-a451f74c1f2f.PNG)

## Created by
* [@Saugustyn](https://github.com/Saugustyn)
* [@fiicooxx](https://github.com/fiicooxx)
