<br/>
<p align="center">
  <a href="https://github.com/sridhar-hosurkar/Human Resource Info">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">ReadME</h3>

  <p align="center">
    Project Demonstrating Web API with unit of work and repository pattern.
C# .net Core.
Front end : ReactJs.
Backend: Postgres.
    <br/>
    <br/>
    <a href="https://github.com/sridhar-hosurkar/Human Resource Info"><strong>Explore the docs »</strong></a>
    <br/>
    <br/>
    <a href="https://github.com/sridhar-hosurkar/Human Resource Info">View Demo</a>
    .
    <a href="https://github.com/sridhar-hosurkar/Human Resource Info/issues">Report Bug</a>
    .
    <a href="https://github.com/sridhar-hosurkar/Human Resource Info/issues">Request Feature</a>
  </p>
</p>

![Downloads](https://img.shields.io/github/downloads/sridhar-hosurkar/Human Resource Info/total) ![Contributors](https://img.shields.io/github/contributors/sridhar-hosurkar/Human Resource Info?color=dark-green) ![Issues](https://img.shields.io/github/issues/sridhar-hosurkar/Human Resource Info) ![License](https://img.shields.io/github/license/sridhar-hosurkar/Human Resource Info) 
<br/>
<img src="images/home.jpg" alt="Home" width="300" height="200">
<br/>
<img src="images/Add_edit.jpg" alt="Add/Edit" width="300" height="200">
<br/>
## Table Of Contents

* [About the Project](#about-the-project)
* [Built With](#built-with)
* [Getting Started](#getting-started)
* [Roadmap](#roadmap)
* [Contributing](#contributing)
* [License](#license)
* [Authors](#authors)
* [Acknowledgements](#acknowledgements)

## About The Project

![Screen Shot](images/screenshot.png)

Project Demonstrates use of Repository pattern with Unit of work. 
The repository pattern creates the abstraction layer between database access and business logic. The generic repository pattern is used to provide common database operations for all database entities in a single class, such as CRUD operations.

The Unit of Work is a type of business transaction, and it will aggregate all Repository transactions (CRUD) into a single transaction. Only one commit will be made for all modifications. If any transaction fails to assure data integrity, it will be rolled back. 

ReactJs is used as front end to perform crud operations. which interacts with Web-API to perform operations.

Entityframe work is used to provide ORM, Postgres SQL is used as backend for persistant data storage.

## Built With

.Net Core 6.0 and above
ReactJS
Postgress
Entityframework core
Automapper

Docker set up is in progress..

## Getting Started

Download Project.
Change the connection string of Postgress as per your local instance in appsettings.js file.
Run the .Net WebAPI project.
Run ReactJs Web client.
Ready to go.
Ex: downloaded project in src folder
Open terminal 1.
src> cd WebAPI
src/WebAPI> dotnet run --project "WebAPI.csproj"

open termincal 2.
src> cd human-resource-client
src/human-resource-client> npm start


## Roadmap

See the [open issues](https://github.com/sridhar-hosurkar/Human Resource Info/issues) for a list of proposed features (and known issues).

## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.
* If you have suggestions for adding or removing projects, feel free to [open an issue](https://github.com/sridhar-hosurkar/Human Resource Info/issues/new) to discuss it, or directly create a pull request after you edit the *README.md* file with necessary changes.
* Please make sure you check your spelling and grammar.
* Create individual PR for each suggestion.
* Please also read through the [Code Of Conduct](https://github.com/sridhar-hosurkar/Human Resource Info/blob/main/CODE_OF_CONDUCT.md) before posting your first idea as well.

### Creating A Pull Request



## License

Distributed under the MIT License. See [LICENSE](https://github.com/sridhar-hosurkar/Human Resource Info/blob/main/LICENSE.md) for more information.

## Authors

* **sridhar hosurkar** - ** - [sridhar hosurkar]() - **




