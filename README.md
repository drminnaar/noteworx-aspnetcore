# NoteWorx README

A basic note management web application that has been built using the latest [ASP.NET Core 2.1], [ASP.NET Core Identity], [Entity Framework Core], and [Postgresql].

## Features

* Add a note
* Edit a note
* Remove a note
* List all notes
* Find note by title or description

## High Level Design

![image](https://user-images.githubusercontent.com/33935506/45508329-d4eaca80-b794-11e8-98eb-f7ed62effdfc.png)

## Screenshots

<table>
  <tr>
    <td><img src="https://user-images.githubusercontent.com/33935506/45536028-82df8e80-b800-11e8-8273-192448601e18.png" width="250" /></td>
    <td><img src="https://user-images.githubusercontent.com/33935506/45536029-82df8e80-b800-11e8-85ef-99b987697a97.png" width="250" /></td>
    <td><img src="https://user-images.githubusercontent.com/33935506/45536030-83782500-b800-11e8-9ec6-fec999f8f4d5.png" width="250" /></td>
  </tr>
  <tr>
    <td><img src="https://user-images.githubusercontent.com/33935506/45536031-83782500-b800-11e8-9b48-d917a3b8d318.png" width="250" />
</td>
    <td><img src="https://user-images.githubusercontent.com/33935506/45536032-83782500-b800-11e8-93f0-d7b69c8f354e.png" width="250" />
</td>
    <td><img src="https://user-images.githubusercontent.com/33935506/45536033-83782500-b800-11e8-889a-2cfe79417d2e.png" width="250" />
</td>
  </tr>
  <tr>
    <td><img src="https://user-images.githubusercontent.com/33935506/45536034-8410bb80-b800-11e8-9f3e-ef540f7e9d1e.png" width="250" /></td>
    <td><img src="https://user-images.githubusercontent.com/33935506/45536036-8410bb80-b800-11e8-9361-a4289a9726b8.png" width="250" /></td>
    <td>
<img src="https://user-images.githubusercontent.com/33935506/45536038-84a95200-b800-11e8-9400-3fabe7e00b6a.png" width="250" /></td>
  </tr>
  <tr>
    <td><img src="https://user-images.githubusercontent.com/33935506/45536039-84a95200-b800-11e8-999f-2d69c97f9b32.png" width="250" /></td>
    <td></td>
    <td></td>
  </tr>
</table>

---

## Developed With

The entire application was built using [Visual Studio Code] on [Ubuntu 18.04]. The following list is a summary of the primary tools, languages and frameworks used to build the application:

* [.NET Core] - .NET Core is a free and open-source managed software framework for Linux, Windows and macOS.

* [C#] - A multi-paradigm programming language encompassing strong typing, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines.

* [ASP.NET Core] - ASP.NET Core is a free, cross-platform, and open-source web framework

* [ASP.NET Core Identity] - ASP.NET Core Identity is a membership system that adds login functionality to ASP.NET Core apps.

* [Entity Framework Core] - EF Core is an object-relational mapper (O/RM) that enables .NET developers to work with a database using .NET objects. It eliminates the need for most of the data-access code that developers usually need to write.

* [Postgresql] - Is an object-relational database management system with an emphasis on extensibility and standards compliance

* [Docker] - Used to host Postgresql database

* [Docker-Compose] - Compose is a tool for defining and running multi-container Docker applications.

* [Cake] - Cake (C# Make) is a cross-platform build automation system with a C# DSL for tasks such as compiling code, copying files and folders, running unit tests, compressing files and building NuGet packages.

* [Bootstrap 4] - Build responsive, mobile-first projects

* [Gulp] - Gulp is a toolkit for automating painful or time-consuming tasks in your development workflow, so you can stop messing around and build something.

### Notable Nuget Packages

* [OdeToCode.UseNodeModules] - ASP.NET Core middleware to serve files from the node_modules directory in the root of the project.

* [Humanizer.Core] - Humanizer meets all your .NET needs for manipulating and displaying strings, enums, dates, times, timespans, numbers and quantities.

---

## Related Projects

* [noteworx-cli-fs]

  A basic note application that uses a CLI (Command Line Interface) frontend to capture and manage notes, and a file system to store notes

* [noteworx-cli-mongodb]

  A basic note application that uses a CLI (Command Line Interface) frontend to capture and manage notes, and mongodb to store notes.

* [noteworx-cli-mongoose]

  A basic note application that uses a CLI (Command Line Interface) frontend to capture and manage notes, Mongoose ODM to manage MongoDB interaction, and mongodb to store notes.

* [noteworx-cli-couchbase]

  A basic note application that uses a CLI (Command Line Interface) frontend to capture and manage notes, and couchbase as a data store.

* [noteworx-cli-express-mongodb]

  A basic note application that uses a CLI (Command Line Interface) frontend to capture and manage notes, an express note management API built using Express, and Mongodb to store notes.

* [noteworx-expressui-mongodb]

  A basic note application that uses an Express frontend to capture and manage notes, and mongodb to store notes.

* [noteworx-react-mongodb]

  A basic note application that uses React frontend to capture and manage notes, an api written in ExpressJS, and mongodb to store notes.

---

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

The following software is required to be installed on your system:

* Dotnet Core

  Version 2.1.402 is required.

  Run the following command from the terminal to verify version of dotnet:

  ```bash
  dotnet --version
  ```

* NodeJS

  The following version of Node and Npm are required:

  * Node 8.x
  * Npm 3.x

  Type the following commands in the terminal to verify your node and npm versions

  ```bash
  node -v
  npm -v
  ```

* Docker

  Version 18.06 is required.

  Run the following command from the terminal to verify version of Docker:

  ```bash
  docker -v
  ```

### Install

Follow the following steps to get development environment running.

1. Clone 'noteworx-aspnetcore' repository from GitHub

   ```bash
   git clone https://github.com/drminnaar/noteworx-aspnetcore.git
   ```

   _or using ssh_

   ```bash
   git clone git@github.com:drminnaar/noteworx-aspnetcore.git
   ```

1. Install node modules

   ```bash
   cd noteworx-aspnetcore/src/NoteWorx.Web
   npm install
   ```

### Build

There are 2 build options:

* Build using dotnet CLI tool

  ```javascript
  cd noteworx-aspnetcore
  dotnet build
  ```

* Build using Cake build script

  ```javascript
  # linux terminal
  cd noteworx-aspnetcore
  ./build.sh
  ```

In both cases, _Gulp_ processes the _"gulpfile.js"_ file. The gulp process prepares client assets to be included in wwwroot folder.

### Run

The NoteWorx application is configured to seed it's database with test data. Therefore, to sign into the NoteWorx application, one can use any of the users that are specified in the _'/NoteWorx.Web/Infrastructure/SeedFiles/users.json'_ file. The password for all users is _'P@ssword123!'_.

#### Run NoteWorx Demo In Container Using Docker

If you would like to simply see the application running in demo mode, type the following command in the terminal at the root of the solution.

```bash
cd noteworx-aspnetcore
docker-compose -f ./docker-compose-demo.yml build
docker-compose -f ./docker-compose-demo.yml up
```

The above command will build required image based on Dockerfile, setup a postgres database in a container, and setup pgAdmin (postges db tool) in a container.

To view the demo, type the following in your browser:

```bash
# To view the NoteWorx demo application
http://localhost:8080

# To open the database admin tool (pgAdmin)
http://localhost:8081
```

When you're done running the demo, type the following command to stop and cleanup containers.

```bash
docker-compose -f ./docker-compose-demo.yml down
```

#### Run NoteWorx From Source

Before running NoteWorx from source, you need to have a running Postgres database instance. For that you can type the following command to start a Postgres container and a pgAdmin container.

```bash
cd noteworx-aspnetcore
docker-compose -f ./docker-compose-data.yml -up
```

Next, type the following to verify that the Postgres database has started in a container

```bash
# You should see a container having the name 'db-dev' by typing the following
docker container ls
```

You will need to ensure you have the correct IP Address configured in the connection-string setting of the _'appsettings.Development.json'_ file. Therefore, type the following command to determine the IP Address of postgres container (db-dev).

```bash
# use the following putput IP address in connection string
docker container inspect | grep -w IPAddress
```

Next, run the NoteWorx web applicatio

```bash
cd noteworx-aspnetcore/src/NoteWorx.Web
dotnet run
```

After the application starts, open the web browser and type the following address:

```bash
http://localhost:5000
```

When you're done running the application, type the following command to stop and cleanup containers.

```bash
docker-compose -f ./docker-compose-data.yml down
```

## Other

The online JSON data generator [www.json-generator.com](https://www.json-generator.com/) was used to generate all data used to seed the NoteWorx application.

### Templates

The following templates were used to generate data.

#### User Template

```javascript
[
  '{{repeat(10)}}',
  {
    picture: 'http://placehold.it/32x32',
    age: '{{integer(20, 40)}}',
    name: '{{firstName()}} {{surname()}}',
    gender: '{{gender()}}',
    company: '{{company().toUpperCase()}}',
    email: '{{email()}}',
    phone: '+1 {{phone()}}',
    address: '{{integer(100, 999)}} {{street()}}, {{city()}}, {{state()}}, {{integer(100, 10000)}}',
    about: '{{lorem(1, "paragraphs")}}'
  }
]
```

#### Tag Template

```javascript
[
  '{{repeat(100)}}',
  {
    value: '{{lorem(1, "words")}}'
  }
]
```

#### Note Template

```javascript
[
  '{{repeat(50)}}',
  {
    title: '{{lorem(random(3,4,5), "words")}}',
    description: '{{lorem(1, "paragraph")}}',
    createdAt: '{{date(new Date(2018, 0, 1), new Date(), "ISODateTimeTZ")}}',
    modifiedAt: function() {
      var createdDate = new Date(this.createdAt);
      var modifiedDate = new Date(createdDate);
      modifiedDate.setDate(createdDate.getDate() + Math.floor(Math.random() * Math.floor(10)));
      return modifiedDate;
    }
  }
]
```

## Versioning

I use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/drminnaar/noteworx-aspnetcore/tags).

## Authors

* **Douglas Minnaar** - *Initial work* - [drminnaar](https://github.com/drminnaar)

[Docker]: https://www.docker.com
[Docker-Compose]: https://docs.docker.com/compose/
[Bootstrap 4]: https://getbootstrap.com
[ASP.NET Core]: https://www.asp.net/
[ASP.NET Core 2.1]: https://www.asp.net/
[ASP.NET Core Identity]: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity
[.NET Core]: https://www.microsoft.com/net/download
[Entity Framework Core]: https://docs.microsoft.com/en-us/ef/core/
[C#]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/
[Postgresql]: https://www.postgresql.org/
[Cake]: https://cakebuild.net/
[Gulp]: https://gulpjs.com/
[OdeToCode.UseNodeModules]: https://github.com/OdeToCode/UseNodeModules
[Humanizer.Core]: https://github.com/Humanizr/Humanizer
[noteworx-cli-fs]: https://github.com/drminnaar/noteworx-cli-fs
[noteworx-cli-mongodb]: https://github.com/drminnaar/noteworx-cli-mongodb
[noteworx-cli-mongoose]: https://github.com/drminnaar/noteworx-cli-mongoose
[noteworx-cli-couchbase]: https://github.com/drminnaar/noteworx-cli-couchbase
[noteworx-cli-express-mongodb]: https://github.com/drminnaar/noteworx-cli-express-mongodb
[noteworx-expressui-mongodb]: https://github.com/drminnaar/noteworx-expressui-mongodb
[noteworx-react-mongodb]: https://github.com/drminnaar/noteworx-react-mongodb