![noteworx-aspnet-github-cover](https://user-images.githubusercontent.com/33935506/116779409-6e905300-aaca-11eb-8071-0fe013a7ac21.png)

# NoteWorx README

A basic note management web application that has been built using .NET 5 with the following frameworks:

- [ASP.NET Core]
- [ASP.NET Core Identity]
- [Entity Framework Core]
- [Postgresql].

## Features

- Add a note
- Edit a note
- Remove a note
- List all notes
- Find note by title or description

## High Level Design

![noteworx-design](https://user-images.githubusercontent.com/33935506/116776333-05094800-aabc-11eb-9e48-476513e2a300.png)

## Screenshots

![noteworx-aspnet-1](https://user-images.githubusercontent.com/33935506/116778136-4dc4ff00-aac4-11eb-9e74-625b2c690b7d.png)

![noteworx-aspnet-2](https://user-images.githubusercontent.com/33935506/116778139-4ef62c00-aac4-11eb-83e8-b929193d6a50.png)

![noteworx-aspnet-3](https://user-images.githubusercontent.com/33935506/116778140-4f8ec280-aac4-11eb-8da1-ed5992fe5133.png)

![noteworx-aspnet-4](https://user-images.githubusercontent.com/33935506/116778141-4f8ec280-aac4-11eb-8a60-46ecf2dc17aa.png)

---

## Toolchain

The entire application was built using [Visual Studio Code] on [Ubuntu 18.04]. The following list is a summary of the primary tools, languages and frameworks used to build the application:

- [.NET Core] - .NET Core is a free and open-source managed software framework for Linux, Windows and macOS.

- [C#] - A multi-paradigm programming language encompassing strong typing, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines.

- [ASP.NET Core] - ASP.NET Core is a free, cross-platform, and open-source web framework

- [ASP.NET Core Identity] - ASP.NET Core Identity is a membership system that adds login functionality to ASP.NET Core apps.

- [Entity Framework Core] - EF Core is an object-relational mapper (O/RM) that enables .NET developers to work with a database using .NET objects. It eliminates the need for most of the data-access code that developers usually need to write.

- [Postgresql] - Is an object-relational database management system with an emphasis on extensibility and standards compliance

- [Docker] - Used to host Postgresql database

- [Docker-Compose] - Compose is a tool for defining and running multi-container Docker applications.

- [Bootstrap 4] - Build responsive, mobile-first projects

- [Gulp] - Gulp is a toolkit for automating painful or time-consuming tasks in your development workflow, so you can stop messing around and build something.

### Notable Nuget Packages

- [OdeToCode.UseNodeModules] - ASP.NET Core middleware to serve files from the node_modules directory in the root of the project.

- [Humanizer.Core] - Humanizer meets all your .NET needs for manipulating and displaying strings, enums, dates, times, timespans, numbers and quantities.

---

## Related Projects

- [noteworx-cli-fs]

  A basic note application that uses a CLI (Command Line Interface) frontend to capture and manage notes, and a file system to store notes

- [noteworx-cli-mongodb]

  A basic note application that uses a CLI (Command Line Interface) frontend to capture and manage notes, and mongodb to store notes.

- [noteworx-cli-mongoose]

  A basic note application that uses a CLI (Command Line Interface) frontend to capture and manage notes, Mongoose ODM to manage MongoDB interaction, and mongodb to store notes.

- [noteworx-cli-couchbase]

  A basic note application that uses a CLI (Command Line Interface) frontend to capture and manage notes, and couchbase as a data store.

- [noteworx-cli-express-mongodb]

  A basic note application that uses a CLI (Command Line Interface) frontend to capture and manage notes, an express note management API built using Express, and Mongodb to store notes.

- [noteworx-expressui-mongodb]

  A basic note application that uses an Express frontend to capture and manage notes, and mongodb to store notes.

- [noteworx-react-mongodb]

  A basic note application that uses React frontend to capture and manage notes, an api written in ExpressJS, and mongodb to store notes.

---

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

The following software is required to be installed on your system:

- Dotnet Core

  Version 5 is required.

  Run the following command from the terminal to verify version of dotnet:

  ```bash
  # get dotnet version
  dotnet --version
  ```

- NodeJS

  The following version of Node and Npm are required:

  - Node 14.6.x
  - Npm 7.9.x

  Type the following commands in the terminal to verify your node and npm versions

  ```bash
  # get node version
  node -v

  # get npm version
  npm -v
  ```

- Docker

  Version 20.x is required.

  Run the following command from the terminal to verify version of Docker:

  ```bash
  # get docker version
  docker -v
  ```

- Docker-Compose

  Version 1.29.x is required.

  Run the following command from the terminal to verify version of Docker-Compose:

  ```bash
  # get docker version
  docker-compose -v
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

1. Install gulp-cli

   Please ensure that you have the `gulp-cli` installed globally.

   ```bash
   npm install --global gulp-cli
   ```

### Build

This project uses _Gulp_ to manage web assets (javascript, css, fonts). The gulp process prepares client assets to be included in wwwroot folder. It does this by processing the `gulpfile.js` file.

Please ensure that you have the `gulp-cli` installed globally.

```bash
npm install --global gulp-cli
```

[Find more information on _Gulp_ here](https://gulpjs.com/docs/en/getting-started/quick-start)

It should be noted that everytime that the project solution is built, the _Gulp_ process will run. This is configured in the project file `NoteWorx.Web.csproj`.

```xml
FILE: NoteWorx.Web.csproj

<Target Name="MyPreCompileTarget" BeforeTargets="Build">
  <Exec Command="gulp" />
</Target>
```

### Run

The NoteWorx application is configured to seed it's database with test data. Therefore, to sign into the NoteWorx application, one can use any of the users that are specified in the _'/NoteWorx.Web/Infrastructure/SeedFiles/users.json'_ file. The password for all users is _'P@ssword123!'_.

#### Step 1 - Start Stack

Before running NoteWorx from source, you need to have a running Postgres database instance. For that you can type the following command to start a Postgres container and a pgAdmin container.

```bash
cd noteworx-aspnetcore

# start stack
docker-compose -f ./fabric/docker-compose.yml up --detach

# stop stack
docker-compose -f ./fabric/docker-compose.yml down --volumes
```

Next, type the following to verify that the Postgres database has started in a container

```bash
docker-compose -f ./fabric/docker-compose.yml ps
```

#### Step 2 - Run database migrations

There is currently a single migration in the `NoteWorx.Notes.Database.Postgres` project that can be use to update the database.

Run the following command to update database:

```bash
dotnet ef database update --project .\NoteWorx.Notes.Database.Postgres\
```

#### Step 3 - Start Web Application

Next, run the NoteWorx web application.

```bash
cd noteworx-aspnetcore/src/NoteWorx.Web
dotnet run
```

Take note that the database will be seeded with data on the first run.

```csharp
//
// Program.cs
//

public static void Main(string[] args)
{
    var host = BuildWebHost(args);
    SeedDb(host);
    host.Run();
}

private static void SeedDb(IHost host)
{
    var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();

    using var scope = scopeFactory.CreateScope();

    var environment = scope.ServiceProvider.GetService<IWebHostEnvironment>();

    var executingPath = Path
        .GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        ?? string.Empty;

    var usersFilePath = Path.Combine(executingPath, "users.json");

    var notesFilePath = Path.Combine(executingPath, "notes.json");

    var seeder = scope
        .ServiceProvider
        .GetRequiredService<Seeder>()
        .IncludeUsers(usersFilePath)
        .IncludeNotes(notesFilePath);

    seeder.Seed();
}
```

After the application starts, open the web browser and type the following address:

```bash
http://localhost:5000
```

When you're done running the application, type the following command to stop and cleanup containers.

```bash
docker-compose -f ./fabric/docker-compose.yml down --volumes
```

---

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

- **Douglas Minnaar** - *Initial work* - [drminnaar](https://github.com/drminnaar)

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
