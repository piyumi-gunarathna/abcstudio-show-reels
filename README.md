# abcstudio-show-reels

## Description
A show reel is a compilation of video clips characterized by its name, video standard (PAL or NTSC), video definition (SD or HD), and total duration represented as timecode in the format of hh:mm:ss:ff. The video standard can be either PAL or NTSC, while the video definition can be SD or HD. Show reels may consist of one or multiple video clips, each featuring a name, description, video standard, video definition, start timecode, and end timecode. Timecode follows the format HH:MM:ss:ff, where HH denotes hours, MM represents minutes, ss stands for seconds, and ff signifies frames. PAL video operates at 25 frames per second (equivalent to 1 frame every 40 milliseconds), while NTSC video runs at 30 frames per second.

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

  
