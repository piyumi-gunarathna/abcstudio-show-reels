# abcstudio-show-reels

## Prerequisites
* Api: VS 2022, dotnet core 6
* Web App: VS Code, angular 14.
* DB: MSSQL

## Running the code
* To run Web app run `npm install` then `ng serve` in terminal from the path `src/ABCStudio.ShowReels.Web`.
* To run Api run `dotnet run` from path `src/ABCStudio.ShowReels.Api`.
* Open Web API  `https://localhost:7106/swagger/index.html`
* Open Web app `http://localhost:4200` on the browser to view/create reels

## Run using `docker compose`
* From terminal go into `src` folder.
* Run `docker compose build --no-cache` 
* Then run `docker compose up` 
* Open `http://localhost:4200` on the browser

## Notes
- This solution aims to provide a starting point for XML string validation without using specific XML parsing libraries or Regular Expressions.
- Solution can extend or modify the XMLValidator class based on specific requirements or additional validation needs.
  
