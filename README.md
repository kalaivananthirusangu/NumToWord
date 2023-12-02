# Number to Words Converter

This is a React with ASP.NET Core project that converts a currency value in numbers to words. For example, if you enter 123456789,99, the app will output "one hundred twenty-three million four hundred fifty-six thousand seven hundred eighty-nine dollars and ninety-nine cents".

## Features

- The app uses a custom API that converts a decimal number to words using a recursive algorithm.
- The app validates the input value using a regular expression and displays an error message if the input is invalid.
- The app uses the `axios` library to send a GET request to the backend and receive the response data.
- The app uses the `custom.css` file to style the components and add some animations.

## Requirements

To run this project, you need to have the following tools installed on your machine:

- Node.js and npm
- .NET 7
- Microsoft.AspNetCore.App 7.0.0
- Microsoft.NETCore.App 7.0.0
- React 18.2.0

## Instructions

You also need to clone this repository to your local machine using the following command:
git clone https://github.com/kalaivananthirusangu/NumToWord.git

The project can be run by either opening the NumToWord.sln in Visual Studio or using command line.

### Command Line Method
- Open a Terminal and navigate to the folder ClientApp folder inside the project folder. Run the following command to instll the dependencies:

  npm install

- Run the following the command to start the react app:

  npm start

- Open another terminal and navigate to the root project folder. Rund the following command to start the Backend ASP.NET Core app:

  dotnet run

-  Open your browser and go to http://localhost:44496 to see the app in action.
