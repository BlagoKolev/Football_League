# Football_League
 ### :bulb: This is simple football league simulator API where customer can:
 #### 1. Create his own Football leagues;
 #### 2. He can Simulate the Games for the whole Season in the League he creates. There are 10 teams for each League which means 18 Rounds for the Season. Games are played on exchanged visits (after 9th Round Homes and Guest has changed their places). For every game the result is on random principle; 
 #### 3. He can see the Statistics for Played maches;
 #### 4. He can see the Statistics for Fixtures before the Season is started;
 #### 5. He can see the Statistics for the Rankings before and after the Season ends;
 #### 6. Change the names of the teams his League and create really custom league;
---
### :bulb: In this project is used Prototype Design Pattern for creating a Teams for every League.
---
### Short API User Manual:
##### 1. Go to League section "api/League/Create" Enter the name of Your choice and the New League with this name will be created. Along with this the teams for League will be created too. Every League has 10 teams created out of the box. The Customer just have to click on the next tab in League section "/api/League/Generate-Fixtures";
##### 2. Go to League section "/api/League/Generate-Fixtures" to create a Fixtures (Games Shedule) by enter the name of the League you have alredy created; 
### :bulb:You are ready to Play!
##### 3. Go to Game section on "/api/Game/autoplay-season". Enter the name of created League and automatically all the Season(games) will be played. Every new league created produce a different result for every single game and a different Standings;
##### 4. After Season ends you can check all Statistics in Statistic section. For this you just should enter the name of League in the different Statistic tabs;
### The final section here is Team section
##### 5. In the Team section you can change all the names of Teams participating in the League no matter it is ends or not started yet. You should enter:
##### -League name
##### -Old team name
##### -New team name
##### Team names are auto generated when League is created. There are 10 teams with names: Team-1, Team-2.... Team-10. So you can easy guess it or just check it in the Statistic section.
---
### :hammer_and_wrench: Languages and Tools :
- C#
- ASP.NET 6
- Entity Framework Core
- MSSQL Server
---
### :bulb: Unit tests are included in the project.

