1. Build project

2. Open powershell in admin mode and 'cd' to the asp.net core project's root. Then run (run only once each) the following commands for the local database to be created:

dotnet tool install --global dotnet-ef
dotnet ef migrations add "Initial" -o "Data/Migrations"
dotnet ef database update

3. Make sure to select to start both projects from the 'Configure Startup Projects option of the start button'

4. Click start to run the app (this action will also seed the local database with dummy data)

# TpsClient

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 17.3.8.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.
