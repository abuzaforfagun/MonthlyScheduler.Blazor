# MonthlyScheduler.Blazor

## Prerequisites
* Visual Studio 2019 or later
* Dot Net Core 3.1 or later

## Creating Application
* Open visual studio and select Create New Project.
![Creat Blazor App 0](https://user-images.githubusercontent.com/24603959/79050322-0ff00100-7c4b-11ea-8750-371e68f3d77e.JPG)

* Search for Blazor App, select Blazor App Template and click on Create button.
![Creat Blazor App 1](https://user-images.githubusercontent.com/24603959/79050359-5b0a1400-7c4b-11ea-9aed-c049f47c33a1.JPG)

* Add your project name, select the location and click on Create button.
![Creat Blazor App 2](https://user-images.githubusercontent.com/24603959/79050390-812fb400-7c4b-11ea-9203-6982de0db44a.JPG)

* Select .NET Core 3.1, select Blazor Server App or later and click on Create button.
![Creat Blazor App 3](https://user-images.githubusercontent.com/24603959/79050413-a6bcbd80-7c4b-11ea-962b-c64145674cf6.JPG)
 
## Add domain project reference
To make the application decoupled and improve the reusability, need to create a domain project and implement the business implemanation their.
* Right click on the solution explorer, navigate Add and select New Project.
![Add class library 0](https://user-images.githubusercontent.com/24603959/79051289-36189f80-7c51-11ea-8713-9e7f4a050a4d.JPG)

* Select Class Library template and click on Next.
![Add class library 1](https://user-images.githubusercontent.com/24603959/79051831-38c8c400-7c54-11ea-84ac-1a627c2c6e4c.JPG)

* Enter the library name and click on Create
* Right click on dependencies of MonthlyBillScheduler.Server project and select Add Reference.
![Add reference](https://user-images.githubusercontent.com/24603959/79051910-ab39a400-7c54-11ea-9121-d305aeffa542.JPG)

* Check the domain project and click on Ok button.
![Add reference 2](https://user-images.githubusercontent.com/24603959/79051919-b987c000-7c54-11ea-8ce7-c51970bbdcf2.JPG)
